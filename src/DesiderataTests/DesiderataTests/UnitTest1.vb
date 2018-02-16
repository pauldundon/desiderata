Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json.Linq

<TestClass()> Public Class JSON

    <TestMethod()> Public Sub Iterate()
        Dim sb As New StringBuilder
        sb.AppendLine("{")
        sb.AppendLine("NumberProperty:100,")
        sb.AppendLine("StringProperty:'text',")
        sb.AppendLine("BoolProperty:true,")
        sb.AppendLine("NullProperty:null,")
        sb.AppendLine("ObjectProperty: {")
        sb.AppendLine("NestedProperty:100")
        sb.AppendLine("},")
        sb.AppendLine("ArrayProperty: [100]")
        sb.AppendLine("}")

        Dim json As String = sb.ToString
        Dim obj As JObject = JObject.Parse(json)

        sb.Clear()
        Dim o As Object
        Dim t As String
        For Each prop As JProperty In obj.Properties
            sb.AppendLine(prop.Name)
            o = obj(prop.Name)
            t = o.GetType.Name

        Next

        Dim x As String = sb.ToString

    End Sub

End Class