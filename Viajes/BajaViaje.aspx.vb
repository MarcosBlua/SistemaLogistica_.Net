Imports System.Data.SqlClient
Partial Class Viajes_BajaViaje
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not isPostBack Then
            If Session("Id_Usuario") Is Nothing Then
                Response.Redirect("/Inicio.aspx")
            End If
        End If
    End Sub

    Private Sub No_Click(sender As Object, e As EventArgs) Handles No.Click
        Response.Redirect("PrincipalViaje.aspx")
    End Sub

    Private Sub Si_Click(sender As Object, e As EventArgs) Handles Si.Click
        If Session("Id_Usuario") Is Nothing Then
            Response.Redirect("/Inicio.aspx")
        Else
            Dim conexion As SqlConnection
            Dim comando As SqlCommand

            conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

            conexion.Open()

            comando = New SqlCommand("DELETE FROM Viaje WHERE IdViaje = @id", conexion)

            comando.Parameters.AddWithValue("@id", Request.QueryString("id"))

            comando.ExecuteNonQuery()

            conexion.Close()

            Response.Redirect("PrincipalViaje.aspx")
        End If
    End Sub

End Class
