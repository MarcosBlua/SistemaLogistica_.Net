Imports System.Data.SqlClient
Partial Class Provincias_ModProvincia
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

                comando = New SqlCommand("SELECT * FROM Provincias WHERE IdProvincia = @id and Baja = 0", conexion)

                comando.Parameters.AddWithValue("@id", Request.QueryString("id"))

                lector = comando.ExecuteReader()

                If lector.Read() Then
                    Provincia.Text = lector("Provincia")
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
                Dim lector As SqlDataReader
                Dim conexion As SqlConnection
                Dim comando As SqlCommand

                conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

                conexion.Open()

                comando = New SqlCommand("Select IdProvincia From Provincias Where Provincia = @Prov", conexion)

                comando.Parameters.AddWithValue("@Prov", Provincia.Text)

                lector = comando.ExecuteReader()

                If lector.Read() And lector("IdProvincia") <> Request.QueryString("id") Then
                    Response.Write("<script language=""javascript"">alert('Ya existe esta provincia!');</script>")
                Else
                    conexion.Close()
                    conexion.Open()

                    comando = New SqlCommand("UPDATE Provincias SET Provincia = @Prov WHERE IdProvincia = @id", conexion)

                    comando.Parameters.AddWithValue("@Prov", Provincia.Text)
                    comando.Parameters.AddWithValue("@id", Request.QueryString("id"))

                    comando.ExecuteNonQuery()

                    conexion.Close()

                    Response.Redirect("PrincipalProvincias.aspx")
                End If
                conexion.Close()
            End If
        End If
    End Sub
End Class
