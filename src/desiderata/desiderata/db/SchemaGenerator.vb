Imports Newtonsoft.Json.Linq

Public Class SchemaGenerator

    Public Enum InferenceModes
        ' If we have a schema and get a new document, we can infer a schema
        ' for the new document and compare it to the schema already inferred.
        ' This gives us three lists: additions, removals and changes.
        ' The only change which we can make by inference is a type change, and
        ' we can't ignore that because it might add or remove substructure.
        ' If we add a field, then we would expect to see that field appear if
        ' we were using the schema to generate a UI, so additions can't be
        ' ignored. We do have a choice, however as to whether or not to ignore
        ' removals. And, of course, we might be using the schema to validate
        ' documents in which case we don't want to make any changes at all
        IgnoreAllChanges
        IgnoreDeletions
        AcceptAllChanges
    End Enum
    Public Function GetSchema(forDocument As String) As String
        Return "{}"
    End Function
    Protected Function GetSchema(forProperty As JProperty) As String
        Dim name As String = forProperty.Name
        Dim value As JToken = forProperty(name)
        If TypeOf (value) Is JValue Then
            ' Some kind of scalar, including null
        End If
        If TypeOf (value) Is JObject Then
            ' Nested object
        End If
        If TypeOf (value) Is JArray Then
            ' Nested array
        End If
    End Function
End Class
