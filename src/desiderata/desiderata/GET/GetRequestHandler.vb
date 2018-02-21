Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class GetRequestHandler
    Inherits RequestHandler
    Public Sub New(context As HttpListenerContext)
        MyBase.New(context)
    End Sub
    Protected Overrides Sub ProcessRequest()

        If Not Repository.IsCollectionPath(LocalPath) Then
            GetEntity()
        Else
            GetCollection()
        End If

    End Sub

    Protected Sub GetEntity()

        Dim result As Desideratum

        result = Repository.ReadDocument(LocalPath)
        Context.Response.ContentType = result.MediaType

        If result.MediaType = "text/json" Then
            Dim schemaUrl As String = URLFromPath(Repository.GetSchemaPath(LocalPath))
            Dim link As String = String.Format("<{0}>; REL=describedBy", schemaUrl)
            Context.Response.AddHeader("Link", link)

            ' There is a IANA-registered "type" relationship which we can leverage
            ' to provide richer type information than that provided by JSON Schema
            ' We haven't done this yet, but what follows is a placeholder so we
            ' know where to do it. In reality we would not use schemaUrl but some
            ' other url which provides more information
            link = String.Format("<{0}>; REL=type", schemaUrl)
            Context.Response.AddHeader("Link", link)
        End If
        SetStringResult(result.Content)
    End Sub


    Protected Sub GetCollection()
        Dim links As New List(Of LinkResult)
        For Each des As Desideratum In Repository.ListDocuments(LocalPath)
            links.Add(New LinkResult With {.href = URLFromPath(des.Path)})
        Next
        'This is a placeholder; see CollectionDiscriminator for more info
        Dim ruleUrl As String = URLFromPath(Repository.GetSchemaPath(Repository.GetDiscriminatorPath(LocalPath)))
        Dim link As String = String.Format("<{0}>; REL=discriminatedBy", ruleUrl)
        Context.Response.AddHeader("Link", link)


        Dim dict As New Dictionary(Of String, Object) From {{"links", links}}
        SetJSONResult(dict)


    End Sub
End Class
