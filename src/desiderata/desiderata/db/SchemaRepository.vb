Public Class SchemaRepository
    Protected Property ctx As New DesiderataDataContext
    Public Property PathRoot As String
    Protected Property Generator As New SchemaGenerator

    Public Sub New(pathRoot As String)
        Me.PathRoot = pathRoot
    End Sub
    Public Function IsSchemaDocument(schemaPath As String) As Boolean
        Return schemaPath.ToLower.StartsWith(PathRoot)
    End Function
    Public Sub DeleteSchema(schemaPath As String)
        Dim result As Schema = (From item In ctx.Schemas
                                Where item.Path = schemaPath
                                Select item).SingleOrDefault

        If result Is Nothing Then
            Throw New DocumentNotFoundException
        Else
            ctx.Schemas.DeleteOnSubmit(result)
            ctx.SubmitChanges()
        End If
    End Sub

    Public Function CreateSchema(content As String, inferenceMode As Integer) As String

        Dim post As New Schema
        post.Content = content
        post.Path = ""
        post.InferenceMode = inferenceMode
        ctx.Schemas.InsertOnSubmit(post)

        ctx.SubmitChanges()

        post.Path = PathRoot & "/" & post.SchemaID

        ctx.SubmitChanges()

        Return post.Path

    End Function
    Public Function CreateSchema(content As String, inferenceMode As Integer, name As String) As String

        Dim post As New Schema
        post.Content = content
        post.Path = PathRoot & "/" & name
        post.InferenceMode = inferenceMode
        ctx.Schemas.InsertOnSubmit(post)

        ctx.SubmitChanges()

        Return post.Path

    End Function
    Public Sub UpdateSchema(content As String,
                                schemaPath As String)


        Dim put As Schema = (From item In ctx.Schemas
                             Where item.Path = schemaPath
                             Select item).SingleOrDefault

        If put Is Nothing Then
            Throw New DocumentNotFoundException
        Else
            put.Content = content
            ctx.SubmitChanges()
        End If
    End Sub

    Public Function ReadSchema(schemaPath As String) As Schema
        Dim doc As Schema = (From item In ctx.Schemas
                             Where item.Path = schemaPath
                             Select item).SingleOrDefault

        If Not doc Is Nothing Then
            Return doc
        Else
            Throw New DocumentNotFoundException
        End If
    End Function

    Public Function SchemaExists(schemaPath As String) As Boolean
        Dim doc As Integer = (From item In ctx.Desideratums
                              Where item.Path = schemaPath
                              Select item.DesideratumID).SingleOrDefault
        Return doc <> 0

    End Function

    Public Function InferCollectionSchema(initialDocument As String) As Integer
        Dim inferred As String = Generator.GetSchema(initialDocument)
        Dim ctx As New DesiderataDataContext

        Dim s As New Schema With {
            .Content = inferred,
            .Path = "",
            .InferenceMode = 1}

        ctx.Schemas.InsertOnSubmit(s)
        ctx.SubmitChanges()
        s.Path = PathRoot & "/" & s.SchemaID
        ctx.SubmitChanges()

        Return s.SchemaID

    End Function

    Public Function GetSchemaPath(forDocumentPath As String) As String
        Dim id As Integer = (From item In ctx.Desideratums
                             Where item.Path = forDocumentPath
                             Select item.SchemaID).SingleOrDefault

        If id = 0 Then
            Throw New DocumentNotFoundException
        Else
            Dim schemaPath As String = (From item In ctx.Schemas
                                        Where item.SchemaID = id
                                        Select item.Path).SingleOrDefault
            Return schemaPath
        End If
    End Function

    Public Sub ReviseInferredSchema(forDocument As Desideratum)
        Dim schemaContent As String = Generator.GetSchema(forDocument.Content)

        Dim currentSchema As Schema = (From item In ctx.Schemas
                                       Where item.SchemaID = forDocument.SchemaID
                                       Select item).Single
        currentSchema.Content = schemaContent

        ctx.SubmitChanges()


    End Sub
End Class
