Imports System.Data.SqlClient
Partial Class Ciudades_AltaCiudad
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

                DDProvincias.Items.Insert(0, New ListItem("", 0))

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

                comando = New SqlCommand("Select Baja From Ciudad Where Ciudad = @Ciudad And IdProvincia = @Prov", conexion)

                comando.Parameters.AddWithValue("@Ciudad", Ciudad.Text)
                comando.Parameters.AddWithValue("@Prov", DDProvincias.SelectedValue)

                lector = comando.ExecuteReader()

                If lector.Read() Then
                    Response.Write("<script language=""javascript"">alert('Ya existe esta ciudad!');</script>")
                Else
                    conexion.Close()
                    conexion.Open()

                    comando = New SqlCommand("INSERT INTO Ciudad(Ciudad, IdProvincia, Baja) VALUES (@Ciudad, @Prov, 0)", conexion)

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
