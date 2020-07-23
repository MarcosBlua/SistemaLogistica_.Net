Imports System.Data.SqlClient
Partial Class Camiones_AltaCamion
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Id_Usuario") Is Nothing Then
                Response.Redirect("/Inicio.aspx")
            End If
        End If
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        If Session("Id_Usuario") Is Nothing Then
            Response.Redirect("/Inicio.aspx")
        Else
            If Page.IsValid Then
                Dim conexion As SqlConnection
                Dim comando As SqlCommand

                conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

                conexion.Open()
                comando = New SqlCommand("INSERT INTO Camiones(Patente, NumeroDeChasis, Baja) VALUES (@Patente, @NumChasis, 0)", conexion)

                comando.Parameters.AddWithValue("@Patente", Patente.Text)
                comando.Parameters.AddWithValue("@NumChasis", NumChasis.Text)
                comando.ExecuteNonQuery()

                conexion.Close()

                Response.Redirect("PrincipalCamion.aspx")
            End If
        End If
    End Sub

End Class
