Imports System.Net

Module Module1

    Sub Main()
        With New Repository
            '.Reset()
        End With
        SimpleListenerExample({"http://localhost:904/"})

    End Sub

    Public Sub SimpleListenerExample(ByVal prefixes As String())
        If Not HttpListener.IsSupported Then
            Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.")
            Return
        End If

        If prefixes Is Nothing OrElse prefixes.Length = 0 Then Throw New ArgumentException("prefixes")
        Dim listener As HttpListener = New HttpListener()
        For Each s As String In prefixes
            listener.Prefixes.Add(s)
        Next

        Dim ins1 As New HelloDetector
        TypeInspector.Register(ins1)

        listener.Start()
        Console.WriteLine("Listening...")
        Do
            Dim context As HttpListenerContext = listener.GetContext()
            Dim request As HttpListenerRequest = context.Request
            Dim handler As IRequestHandler = Nothing
            Select Case request.HttpMethod
                Case "POST"
                    handler = New PostRequestHandler(context)
                Case "GET"
                    handler = New GetRequestHandler(context)
                Case "PUT"
                    handler = New PutRequestHandler(context)
                Case "DELETE"
                    handler = New DeleteRequestHandler(context)
                Case Else
                    Dim response As HttpListenerResponse = context.Response
                    Dim responseString As String = "<HTML><BODY> Hello world!</BODY></HTML>"
                    Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(responseString)
                    response.ContentLength64 = buffer.Length
                    Dim output As System.IO.Stream = response.OutputStream
                    output.Write(buffer, 0, buffer.Length)
                    output.Close()
            End Select

            If Not handler Is Nothing Then
                handler.ProcessRequest()
            End If

        Loop
        listener.[Stop]()
    End Sub

End Module
