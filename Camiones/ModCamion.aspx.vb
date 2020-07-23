Imports System.Data.SqlClient
Partial Class Camiones_ModCamion
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Id_Usuario") Is Nothing Then
                Response.Redirect("/Inicio.aspx")
            Else
                Dim lector As SqlDataReader
                Dim conexion As SqlConnection
                Dim comando As SqlCommand

                conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

                conexion.Open()

                comando = New SqlCommand("SELECT * FROM Camiones WHERE IdCamion = @id and Baja = 0", conexion)

                comando.Parameters.AddWithValue("@id", Request.QueryString("id"))

                lector = comando.ExecuteReader()

                If lector.Read() Then
                    Patente.Text = lector("Patente")
                    NumChasis.Text = lector("NumeroDeChasis")
                End If

                conexion.Close()
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
                comando = New SqlCommand("UPDATE Camiones SET Patente = @Patente, NumeroDeChasis = @NumChasis WHERE IdCamion = @id", conexion)

                comando.Parameters.AddWithValue("@id", Request.QueryString("id"))
                comando.Parameters.AddWithValue("@Patente", Patente.Text)
                comando.Parameters.AddWithValue("@NumChasis", NumChasis.Text)
                comando.ExecuteNonQuery()

                conexion.Close()

                Response.Redirect("PrincipalCamion.aspx")
            End If
        End If
    End Sub
End Class
