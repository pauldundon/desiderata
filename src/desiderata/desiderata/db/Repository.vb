Imports System.IO

Public Class DocumentRepository
    Protected Property ctx As New DesiderataDataContext
    Protected Property Schemas As New SchemaRepository("/dsschema")


    Protected Function IsSchemaDocument(localPath As String) As Boolean
        Return Schemas.IsSchemaDocument(localPath)
    End Function
    Protected Function FindCollection(collectionPath As String, create As Boolean) As Collection
        Dim coll As Collection = (From item In ctx.Collections
                                  Where item.Path = collectionPath
                                  Select item).SingleOrDefault

        If coll Is Nothing And create Then
            coll = New Collection
            coll.Path = collectionPath
            ctx.Collections.InsertOnSubmit(coll)
            ctx.SubmitChanges()
        End If

        Return coll
    End Function

    Public Sub DeleteDocument(localPath As String)

        If IsSchemaDocument(localPath) Then
            Schemas.DeleteSchema(localPath)
            Exit Sub
        End If

        Dim result As Desideratum = (From item In ctx.Desideratums
                                     Where item.Path = localPath
                                     Select item).SingleOrDefault

        If result Is Nothing Then
            Throw New DocumentNotFoundException
        Else
            ctx.Desideratums.DeleteOnSubmit(result)
            ctx.SubmitChanges()
        End If
    End Sub
    Public Function CreateDocument(content As String,
                                   mediaType As String,
                                   collectionPath As String,
                                   Optional documentPath As String = "") As String

        If documentPath <> "" And Not documentPath.StartsWith(collectionPath) Then
            Throw New ArgumentException("documentPath must be within collectionPath")
        End If

        Dim coll As Collection = FindCollection(collectionPath, True)

        Dim post As New Desideratum
        post.CollectionID = coll.CollectionID
        post.Content = content
        post.MediaType = mediaType
        post.Path = documentPath
        ctx.Desideratums.InsertOnSubmit(post)

        ctx.SubmitChanges()

        If documentPath = "" Then
            post.Path = collectionPath & "/" & post.DesideratumID
            ctx.SubmitChanges()
        End If


        Return post.Path

    End Function

    Public Sub UpdateDocument(content As String,
                                   mediaType As String,
                                   documentPath As String)

        If IsSchemaDocument(documentPath) Then
            Schemas.UpdateSchema(content, documentPath)
            Exit Sub
        End If

        Dim collectionPath As String = Path.GetDirectoryName(documentPath)

        Dim coll As Collection = FindCollection(collectionPath, True)

        Dim put As Desideratum = (From item In ctx.Desideratums
                                  Where item.Path = documentPath
                                  Select item).SingleOrDefault

        If put Is Nothing Then
            Throw New DocumentNotFoundException
        Else
            put.Content = content
            put.MediaType = mediaType
            ctx.SubmitChanges()
        End If
    End Sub

    Public Function ReadDocument(documentPath As String) As Desideratum
        If IsSchemaDocument(documentPath) Then
            Dim s As Schema = Schemas.ReadSchema(documentPath)
            Return New Desideratum With
                {.Content = s.Content,
                .Path = s.Path}
        End If

        Dim doc As Desideratum = (From item In ctx.Desideratums
                                  Where item.Path = documentPath
                                  Select item).SingleOrDefault

        If Not doc Is Nothing Then
            Return doc
        Else
            Throw New DocumentNotFoundException
        End If
    End Function
    Public Function ListDocuments(collectionPath As String) As IEnumerable(Of Desideratum)
        Dim coll As Collection = FindCollection(collectionPath, False)

        If coll Is Nothing Then
            Throw New DocumentNotFoundException
        Else
            Return From item In ctx.Desideratums
                   Where item.CollectionID = coll.CollectionID
                   Select item
        End If



    End Function
    Public Function DocumentExists(documentPath As String) As Boolean

        If IsSchemaDocument(documentPath) Then
            Return Schemas.SchemaExists(documentPath)
        End If
        Dim doc As Integer = (From item In ctx.Desideratums
                              Where item.Path = documentPath
                              Select item.DesideratumID).SingleOrDefault
        Return doc <> 0

    End Function

    Public Function IsCollectionPath(path As String) As Boolean
        Return Not FindCollection(path, False) Is Nothing
    End Function
End Class

Public Class DocumentNotFoundException
    Inherits ApplicationException

End Class

Public Class Repository
    Inherits DocumentRepository
End Class