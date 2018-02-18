
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

        ' Actually: we can treat a type change in two ways, either allowing only
        ' the most recent type, or accumulating allowed types. The latter is easier
        ' to correct manually

        IgnoreAllChanges
        IgnoreDeletions
        AcceptAllChanges
    End Enum
    Public Function GetSchema(forDocument As String) As String
        Dim obj As JObject = JObject.Parse(forDocument)
        Return GetSchema(CType(obj, JToken)).ToString
    End Function
    Protected Function GetSchema(forArray As JArray) As JObject

        If forArray.Any Then
            Return GetSchema(forArray(0))
        Else
            Dim defaultToString As New JObject
            defaultToString("type") = "string"
            Return defaultToString
        End If

    End Function
    Protected Function GetSchema(forValue As JToken) As JObject
        Dim result As New JObject
        Select Case forValue.Type
            Case JTokenType.Array
                result("type") = "array"
                result("items") = GetSchema(CType(forValue, JArray))
            Case JTokenType.Boolean
                result("type") = "boolean"
            Case JTokenType.Integer, JTokenType.Float
                result("type") = "number"
            Case JTokenType.Null
                result("type") = "null"
            Case JTokenType.Object
                result("type") = "object"
                result("properties") = GetSchema(CType(forValue, JObject))
            Case JTokenType.String
                result("type") = "string"
            Case Else

        End Select
        Return result

    End Function

    Protected Function GetSchema(forProperty As JProperty) As JObject
        Dim name As String = forProperty.Name
        Dim value As JToken = forProperty.Value
        Return GetSchema(value)
    End Function

    Protected Function GetSchema(forObject As JObject) As JObject
        Dim result As New JObject

        For Each prop As JProperty In forObject.Properties
            result(prop.Name) = GetSchema(prop)
        Next

        Return result
    End Function
End Class
