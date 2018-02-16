' Our way of managing schemas assumes that any given collection
' holds documents of a single type. However, there are cases
' (esp with polymorphism in play) where this may not be the case.
' This means we need a way to discriminate between different types
' in a single collection. The plan is to do this using an object
' which exposes some functions we can call to do any necessary work.
' This means we end up with a "rule" entity of type text/javascript.
' We expose a link to this when we GET the collection, so the caller
' can update it to modify the rules
Imports System.Text

Public Class CollectionDiscriminator
    Public Function GetDiscriminator(collectionPath As String) As String
        ' Discriminators will look something like the following:
        Dim sb As New StringBuilder
        sb.AppendLine("{")
        sb.AppendLine("getSchemaPath: function (collectionPath, documentContent) {")
        sb.AppendLine("return '/dsschema/1234';")
        sb.AppendLine("}}")
        Return sb.ToString
    End Function
End Class
