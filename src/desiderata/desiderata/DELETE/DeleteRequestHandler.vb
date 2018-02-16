Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class DeleteRequestHandler
    Inherits RequestHandler
    Public Sub New(context As HttpListenerContext)
        MyBase.New(context)
    End Sub
    Protected Overrides Sub ProcessRequest()


        Repository.DeleteDocument(LocalPath)

        SetStringResult(RequestEntityURL)



    End Sub

    Protected Sub ProcessGetEntity(context As HttpListenerContext)
        Dim ctx As New DesiderataDataContext
        Dim result As Desideratum = (From item In ctx.Desideratums
                                     Where item.Path = context.Request.Url.LocalPath
                                     Select item).SingleOrDefault
        If result Is Nothing Then
            context.Response.StatusCode = 404
            SetStringResult("Not Found")
        Else
            SetStringResult(result.Content)
            context.Response.ContentType = result.MediaType

        End If
    End Sub
    Protected Sub ProcessGetCollection(context As HttpListenerContext, collectionID As Integer)
        Dim links As New List(Of LinkResult)
        Dim ctx As New DesiderataDataContext
        For Each des As Desideratum In From item In ctx.Desideratums
                                       Where item.CollectionID = collectionID
                                       Select item

            links.Add(New LinkResult With {.href = URLFromPath(des.Path)})

        Next
        Dim dict As New Dictionary(Of String, Object) From {{"links", links}}
        SetStringResult(JObject.FromObject(dict).ToString)

    End Sub
End Class
