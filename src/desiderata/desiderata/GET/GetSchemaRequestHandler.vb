Imports System.IO
Imports System.Net
Imports System.Reflection
Imports Newtonsoft.Json.Linq

Public Class GetSchemaRequestHandler
    Inherits RequestHandler

    Public Sub New(context As HttpListenerContext)
        MyBase.New(context)
    End Sub

    Protected Overrides Sub ProcessRequest()
        ' The path takes the form /schema?id=url where url is the identity of 
        ' an entity in our database

        Dim entityID As String = Context.Request.QueryString("id")
        Dim entityUrl As New Uri(WebUtility.UrlDecode(entityID))

        Dim ctx As New DesiderataDataContext
        Dim result As Desideratum = (From item In ctx.Desideratums
                                     Where item.Path = entityUrl.LocalPath
                                     Select item).SingleOrDefault

        Dim obj As JObject = JObject.Parse(result.Content)
        Dim typeName As String = TypeInspector.GetTypeName(entityUrl.LocalPath, obj)

        Dim folder As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location)
        folder = Path.GetDirectoryName(folder)
        folder = Path.GetDirectoryName(folder)
        folder = Path.Combine(folder, "schema")

        Dim schemaFile As String = String.Format("{0}\{1}.json", folder, typeName)
        Dim schemaContent As String
        Dim sr As New StreamReader(schemaFile)
        schemaContent = sr.ReadToEnd
        sr.Close()

        SetStringResult(schemaContent)


    End Sub
End Class
