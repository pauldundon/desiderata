Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json.Linq
Imports Raffles

<TestClass()> Public Class Schema
    <TestInitialize> Public Sub InitAjax()
        Raffles.Ajax.Server = "http://localhost:904/"

        Raffles.Ajax.CredentialMode = Raffles.Ajax.CredentialModes.Unauthenticated

    End Sub
    <TestMethod()> Public Sub Load()

        ' Create an instance of a well-known type and verify that
        ' when we fetch it we get the right schema
        Dim obj As JObject = JSONOps.LoadJSON("organisation")
        Dim requiredSchema As JObject = JSONOps.LoadJSON("organisation-schema")


        Dim id As String = Ajax.MakeApiRequest("/Organisations", Ajax.Methods.POST, obj.ToString)
        Dim created As JObject = Ajax.MakeRequest(id, Ajax.Methods.GET)
        Dim link As String = Ajax.LastResponseHeaders("Link")
        link = link.Split(";")(0).Replace("<", "").Replace(">", "").Trim
        Dim schema As JObject = Ajax.MakeRequest(link, Ajax.Methods.GET)

        Assert.AreEqual(requiredSchema.ToString, schema.ToString)

        ' Now create an instance of a modified type
        obj = JSONOps.LoadJSON("organisation2")
        requiredSchema = JSONOps.LoadJSON("organisation2-schema")


        id = Ajax.MakeApiRequest("/Organisations", Ajax.Methods.POST, obj.ToString)
        created = Ajax.MakeRequest(id, Ajax.Methods.GET)
        link = Ajax.LastResponseHeaders("Link")
        link = link.Split(";")(0).Replace("<", "").Replace(">", "").Trim
        schema = Ajax.MakeRequest(link, Ajax.Methods.GET)

        Assert.AreEqual(requiredSchema.ToString, schema.ToString)

    End Sub

End Class


