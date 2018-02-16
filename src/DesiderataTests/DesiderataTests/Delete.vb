Imports System.Net
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json.Linq
Imports Raffles

<TestClass()> Public Class Delete
    <TestInitialize> Public Sub InitAjax()
        Raffles.Ajax.Server = "http://localhost:904/"

        Raffles.Ajax.CredentialMode = Raffles.Ajax.CredentialModes.Unauthenticated

    End Sub
    <TestMethod()> Public Sub Deletion()
        Dim pl As New Ajax.Payload From {{"Hello", "World"}}
        Dim id As String = Ajax.MakeApiRequest("/Hellos", Ajax.Methods.POST, pl)
        Dim posted As JObject = Ajax.MakeRequest(id, Ajax.Methods.GET)
        Assert.AreEqual("World", posted("Hello").Value(Of String))
        Dim id2 As String = Ajax.MakeRequest(id, Ajax.Methods.DELETE)
        Assert.AreEqual(id, id2)
        Dim exceptionThrown As Boolean
        Try
            Ajax.MakeRequest(id, Ajax.Methods.GET)
        Catch ex As WebException
            exceptionThrown = True
            Dim resp As HttpWebResponse = ex.Response
            Assert.AreEqual(HttpStatusCode.NotFound, resp.StatusCode)
        End Try
        Assert.IsTrue(exceptionThrown)
    End Sub
End Class