﻿Imports System.Data.SqlClient
Partial Class Camioneros_BajaCamionero
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Id_Usuario") Is Nothing Then
                Response.Redirect("/Inicio.aspx")
            End If
        End If
    End Sub

    Private Sub No_Click(sender As Object, e As EventArgs) Handles No.Click
        Response.Redirect("PrincipalCamioneros.aspx")
    End Sub

    Private Sub Si_Click(sender As Object, e As EventArgs) Handles Si.Click
        If Session("Id_Usuario") Is Nothing Then
            Response.Redirect("/Inicio.aspx")
        Else
            Dim conexion As SqlConnection
            Dim comando As SqlCommand

            conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

            conexion.Open()

            comando = New SqlCommand("DELETE FROM Camioneros WHERE IdCamionero = @id", conexion)

            comando.Parameters.AddWithValue("@id", Request.QueryString("id"))

            comando.ExecuteNonQuery()

            conexion.Close()

            Response.Redirect("PrincipalCamioneros.aspx")
        End If
    End Sub

End Class
