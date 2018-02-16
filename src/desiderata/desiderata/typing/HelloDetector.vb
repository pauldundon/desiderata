Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class HelloDetector
    Inherits TypeInspector

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Hello"
        End Get
    End Property

    Public Overrides Function ObjectIsOfType(localPath As String, obj As JObject) As Boolean
        Return localPath.ToLower.StartsWith("/hellos")
    End Function
End Class
