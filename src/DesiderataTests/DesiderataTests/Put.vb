Imports System.Net
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json.Linq
Imports Raffles

<TestClass()> Public Class Put
    <TestInitialize> Public Sub InitAjax()
        Raffles.Ajax.Server = "http://localhost:904/"

        Raffles.Ajax.CredentialMode = Raffles.Ajax.CredentialModes.Unauthenticated

    End Sub
    <TestMethod()> Public Sub PutCreation()
        Dim pl As New Ajax.Payload From {{"Hello", "World"}}
        Dim id As String = Ajax.MakeApiRequest("/Hellos/ToWorld", Ajax.Methods.PUT, pl)
        Assert.AreEqual(id, Raffles.Ajax.Server & "Hellos/ToWorld")
        Dim posted As JObject = Ajax.MakeRequest(id, Ajax.Methods.GET)
        Assert.AreEqual("World", posted("Hello").Value(Of String))
    End Sub
    <TestMethod()> Public Sub Overwrite()
        Dim pl As New Ajax.Payload From {{"Hello", "World"}}
        Dim id As String = Ajax.MakeApiRequest("/Hellos", Ajax.Methods.POST, pl)
        Dim posted As JObject = Ajax.MakeRequest(id, Ajax.Methods.GET)
        Assert.AreEqual("World", posted("Hello").Value(Of String))
        pl("Hello") = "Everyone"
        Dim id2 As String = Ajax.MakeRequest(id, Ajax.Methods.PUT, pl)
        Assert.AreEqual(id, id2)
        posted = Ajax.MakeRequest(id, Ajax.Methods.GET)
        Assert.AreEqual("Everyone", posted("Hello").Value(Of String))
    End Sub

End Class