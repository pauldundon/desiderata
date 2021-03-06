﻿Imports System.Net
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json.Linq
Imports Raffles

<TestClass()> Public Class Post
    <TestInitialize> Public Sub InitAjax()
        Raffles.Ajax.Server = "http://localhost:904/"

        Raffles.Ajax.CredentialMode = Raffles.Ajax.CredentialModes.Unauthenticated

    End Sub
    <TestMethod()> Public Sub VerifyCreation()
        Dim pl As New Ajax.Payload From {{"Hello", "World"}}
        Dim id As String = Ajax.MakeApiRequest("/Hellos", Ajax.Methods.POST, pl)
        Dim posted As JObject = Ajax.MakeRequest(id, Ajax.Methods.GET)
        Assert.AreEqual("World", posted("Hello").Value(Of String))

    End Sub

    <TestMethod()> Public Sub Verify404()
        Dim pl As New Ajax.Payload From {{"Hello", "World"}}
        Dim id As String = Ajax.MakeApiRequest("/Hellos", Ajax.Methods.POST, pl)
        id = id & "abcde"
        Try
            Dim posted As JObject = Ajax.MakeRequest(id, Ajax.Methods.GET)

        Catch ex As Exception
            ex = ex

        End Try
    End Sub

    <TestMethod()> Public Sub VerifyList()
        Dim posted As JObject = Ajax.MakeApiRequest("/Hellos", Ajax.Methods.GET)
    End Sub

    <TestMethod()> Public Sub VerifySchema()
        Dim pl As New Ajax.Payload From {{"Hello", "World"}}
        Dim id As String = Ajax.MakeApiRequest("/Hellos", Ajax.Methods.POST, pl)
        Dim created As JObject = Ajax.MakeRequest(id, Ajax.Methods.GET)
        Dim link As String = Ajax.LastResponseHeaders("Link")
        link = link.Split(";")(0).Replace("<", "").Replace(">", "").Trim

        Dim schema As JObject = Ajax.MakeRequest(link, Ajax.Methods.GET)
    End Sub
End Class