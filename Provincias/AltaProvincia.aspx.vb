Imports System.Data.SqlClient
Partial Class Provincias_AltaProvincia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not isPostBack Then
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
                Dim lector As SqlDataReader
                Dim conexion As SqlConnection
                Dim comando As SqlCommand

                conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

                conexion.Open()

                comando = New SqlCommand("Select Baja From Provincias Where Provincia = @Prov", conexion)

                comando.Parameters.AddWithValue("@Prov", Provincia.Text)

                lector = comando.ExecuteReader()

                If lector.Read() Then
                    Response.Write("<script language=""javascript"">alert('Ya existe esta provincia!');</script>")
                Else
                    conexion.Close()
                    conexion.Open()

                    comando = New SqlCommand("INSERT INTO Provincias(Provincia, Baja) VALUES (@Prov, 0)", conexion)

                    comando.Parameters.AddWithValue("@Prov", Provincia.Text)
                    comando.ExecuteNonQuery()

                    conexion.Close()

                    Response.Redirect("PrincipalProvincias.aspx")
                End If
                conexion.Close()
            End If
        End If
    End Sub

End Class
