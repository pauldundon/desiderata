﻿Public Class SchemaRepository
    Protected Property ctx As New DesiderataDataContext
    Public Property PathRoot As String

    Public Sub New(pathRoot As String)
        Me.PathRoot = pathRoot
    End Sub
    Public Function IsSchemaDocument(localPath As String) As Boolean
        Return localPath.ToLower.StartsWith(PathRoot)
    End Function
    Public Sub DeleteSchema(localPath As String)
        Dim result As Schema = (From item In ctx.Schemas
                                Where item.Path = localPath
                                Select item).SingleOrDefault

        If result Is Nothing Then
            Throw New DocumentNotFoundException
        Else
            ctx.Schemas.DeleteOnSubmit(result)
            ctx.SubmitChanges()
        End If
    End Sub

    Public Function CreateSchema(content As String, isInferred As Boolean) As String

        Dim post As New Schema
        post.Content = content
        post.Path = ""
        post.IsInferred = isInferred
        ctx.Schemas.InsertOnSubmit(post)

        ctx.SubmitChanges()

        post.Path = PathRoot & "/" & post.SchemaID

        ctx.SubmitChanges()

        Return post.Path

    End Function
    Public Function CreateSchema(content As String, isInferred As Boolean, name As String) As String

        Dim post As New Schema
        post.Content = content
        post.Path = PathRoot & "/" & name
        post.IsInferred = isInferred
        ctx.Schemas.InsertOnSubmit(post)

        ctx.SubmitChanges()

        Return post.Path

    End Function
    Public Sub UpdateSchema(content As String,
                                documentPath As String)


        Dim put As Schema = (From item In ctx.Schemas
                             Where item.Path = documentPath
                             Select item).SingleOrDefault

        If put Is Nothing Then
            Throw New DocumentNotFoundException
        Else
            put.Content = content
            ctx.SubmitChanges()
        End If
    End Sub

    Public Function ReadSchema(documentPath As String) As Schema
        Dim doc As Schema = (From item In ctx.Schemas
                             Where item.Path = documentPath
                             Select item).SingleOrDefault

        If Not doc Is Nothing Then
            Return doc
        Else
            Throw New DocumentNotFoundException
        End If
    End Function

    Public Function SchemaExists(documentPath As String) As Boolean
        Dim doc As Integer = (From item In ctx.Desideratums
                              Where item.Path = documentPath
                              Select item.DesideratumID).SingleOrDefault
        Return doc <> 0

    End Function
End Class
