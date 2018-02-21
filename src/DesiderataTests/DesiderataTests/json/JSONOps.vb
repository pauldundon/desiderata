Imports System.IO
Imports System.Reflection
Imports Newtonsoft.Json.Linq

Public Class JSONOps
    Public Shared Function LoadJSON(filename As String) As JObject
        Dim testPath As String = Assembly.GetExecutingAssembly.Location
        testPath = Path.GetDirectoryName(testPath)
        testPath = Path.GetDirectoryName(testPath)
        testPath = Path.GetDirectoryName(testPath)
        testPath = Path.Combine(testPath, "json")
        filename = String.Format("{0}\{1}.json", testPath, filename)

        Dim sr As New StreamReader(filename)
        Dim content As String = sr.ReadToEnd
        sr.Close()
        Dim result As JObject = JObject.Parse(content)
        Return result




    End Function
End Class
