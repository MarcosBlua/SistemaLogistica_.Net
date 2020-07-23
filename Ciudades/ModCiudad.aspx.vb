Imports System.Data.SqlClient
Partial Class Ciudades_ModCiudad
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

                comando = New SqlCommand("SELECT IdProvincia, Provincia FROM Provincias WHERE Baja=0", conexion)

                lector = comando.ExecuteReader()

                DDProvincias.DataSource = lector

                DDProvincias.DataValueField = "IdProvincia"

                DDProvincias.DataTextField = "Provincia"

                DDProvincias.DataBind()

                lector.Close()

                comando = New SqlCommand("SELECT * FROM Ciudad WHERE IdCiudad = @id and Baja = 0", conexion)

                comando.Parameters.AddWithValue("@id", Request.QueryString("id"))

                lector = comando.ExecuteReader()

                If lector.Read() Then
                    Ciudad.Text = lector("Ciudad")
                    DDProvincias.SelectedValue = lector("IdProvincia")
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

                comando = New SqlCommand("Select IdCiudad From Ciudad Where Ciudad = @Ciudad And IdProvincia = @Prov", conexion)

                comando.Parameters.AddWithValue("@Ciudad", Ciudad.Text)
                comando.Parameters.AddWithValue("@Prov", DDProvincias.SelectedValue)

                lector = comando.ExecuteReader()

                If lector.Read() And lector("IdCiudad") <> Request.QueryString("id") Then
                    Response.Write("<script language=""javascript"">alert('Ya existe esta ciudad!');</script>")
                Else
                    conexion.Close()
                    conexion.Open()

                    comando = New SqlCommand("UPDATE Ciudad SET Ciudad = @Ciudad, IdProvincia = @Prov WHERE IdCiudad = @id", conexion)

                    comando.Parameters.AddWithValue("@id", Request.QueryString("id"))
                    comando.Parameters.AddWithValue("@Ciudad", Ciudad.Text)
                    comando.Parameters.AddWithValue("@Prov", DDProvincias.SelectedValue)
                    comando.ExecuteNonQuery()

                    conexion.Close()

                    Response.Redirect("PrincipalCiudad.aspx")
                End If
                conexion.Close()
            End If
        End If
    End Sub
End Class
