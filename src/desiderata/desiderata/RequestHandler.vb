Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Interface IRequestHandler
    Sub ProcessRequest()

End Interface
Public MustInherit Class RequestHandler
    Implements IRequestHandler
    Public Property Context As HttpListenerContext
    Public Property Repository As New Repository

    Public Sub New(context As HttpListenerContext)
        Me.Context = context
    End Sub
    Sub PublicProcessRequest() Implements IRequestHandler.ProcessRequest
        Try
            Context.Response.AddHeader("Access-Control-Allow-Origin", "*")
            ProcessRequest()
        Catch ex As DocumentNotFoundException
            Context.Response.StatusCode = 404
            SetStringResult("Not Found")
        End Try

    End Sub
    Protected MustOverride Sub ProcessRequest()
    Protected Sub SetStringResult(content As String)
        Dim response As HttpListenerResponse = Context.Response

        Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(content)
        response.ContentLength64 = buffer.Length
        Dim output As System.IO.Stream = response.OutputStream
        output.Write(buffer, 0, buffer.Length)
        output.Close()


    End Sub
    Protected Sub SetJSONResult(content As Dictionary(Of String, Object))
        SetJSONResult(JObject.FromObject(content))
    End Sub
    Protected Sub SetJSONResult(content As JObject)
        SetStringResult(content.ToString)
    End Sub
    Protected Function URLFromPath(path As String) As String
        Dim requestUrl As Uri = Context.Request.Url
        Return requestUrl.AbsoluteUri.Substring(0, requestUrl.AbsoluteUri.Length - requestUrl.PathAndQuery.Length) & path
    End Function

    Protected Function RequestContent() As String
        Dim sr As New StreamReader(Context.Request.InputStream)
        Dim content As String = sr.ReadToEnd
        sr.Close()
        Return content
    End Function
    Protected ReadOnly Property LocalPath As String
        Get
            Return Context.Request.Url.LocalPath
        End Get
    End Property

    Protected ReadOnly Property RequestEntityURL As String
        Get
            Return URLFromPath(LocalPath)
        End Get
    End Property

    Protected ReadOnly Property RequestMediaType As String
        Get
            Return Context.Request.ContentType
        End Get
    End Property
End Class
