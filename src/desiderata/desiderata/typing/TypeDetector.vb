Imports System.Net
Imports Newtonsoft.Json.Linq

Public MustInherit Class TypeInspector

    Public MustOverride ReadOnly Property Name As String

    Public MustOverride Function ObjectIsOfType(localPath As String, obj As JObject) As Boolean

    Public Shared Inspectors As New List(Of TypeInspector)

    Public Shared Function GetTypeName(localPath As String, obj As JObject) As String
        For Each inspector As TypeInspector In Inspectors
            If inspector.ObjectIsOfType(localPath, obj) Then
                Return inspector.Name
            End If
        Next
        Return "Object"
    End Function

    Public Shared Sub Register(inspector As TypeInspector, Optional insertAfter As String = Nothing)

        If Not insertAfter Is Nothing Then
            Dim oInsertAfter As TypeInspector = (From item In Inspectors
                                                 Where item.Name = insertAfter
                                                 Select item).Single
            Dim iInsertAfter As Integer = Inspectors.IndexOf(oInsertAfter)
            If iInsertAfter = Inspectors.Count - 1 Then
                Inspectors.Add(inspector)
            Else
                Inspectors.Insert(iInsertAfter + 1, inspector)
            End If
        Else
            Inspectors.Insert(0, inspector)
        End If

    End Sub

End Class
