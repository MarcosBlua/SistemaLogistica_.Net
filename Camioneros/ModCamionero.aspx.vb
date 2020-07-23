Imports System.Data.SqlClient
Partial Class Camioneros_ModCamionero
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

                comando = New SqlCommand("SELECT * FROM Camioneros WHERE IdCamionero = @id and Baja = 0", conexion)

                comando.Parameters.AddWithValue("@id", Request.QueryString("id"))

                lector = comando.ExecuteReader()

                If lector.Read() Then
                    NyA.Text = lector("NombreApellido")
                    Dir.Text = lector("Direccion")
                    Tel.Text = lector("Telefono")
                    DNI.Text = lector("Dni")
                    DDProvincias.SelectedValue = lector("IdProvincia")
                    DDProvincias_SelectedIndexChanged(DDProvincias, e)
                    DDCiudades.SelectedValue = lector("IdCiudad")
                End If

                conexion.Close()
            End If
        End If
    End Sub

    Private Sub DDProvincias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDProvincias.SelectedIndexChanged
        Dim lector As SqlDataReader
        Dim conexion As SqlConnection
        Dim comando As SqlCommand

        conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

        conexion.Open()

        comando = New SqlCommand("SELECT IdCiudad, Ciudad FROM Ciudad WHERE IdProvincia = @id and Baja=0", conexion)

        comando.Parameters.AddWithValue("@id", DDProvincias.SelectedValue)

        lector = comando.ExecuteReader()

        DDCiudades.DataSource = lector

        DDCiudades.DataValueField = "IdCiudad"

        DDCiudades.DataTextField = "Ciudad"

        DDCiudades.DataBind()

        conexion.Close()
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
                comando = New SqlCommand("UPDATE Camioneros SET NombreApellido = @NA, Direccion = @Dir, Telefono = @Tel, Dni = @DNI, IdProvincia = @Prov, IdCiudad = @Ciud WHERE IdCamionero = @id", conexion)

                comando.Parameters.AddWithValue("@id", Request.QueryString("id"))
                comando.Parameters.AddWithValue("@NA", NyA.Text)
                comando.Parameters.AddWithValue("@Dir", Dir.Text)
                comando.Parameters.AddWithValue("@Tel", Tel.Text)
                comando.Parameters.AddWithValue("@DNI", DNI.Text)
                comando.Parameters.AddWithValue("@Prov", DDProvincias.SelectedValue)
                comando.Parameters.AddWithValue("@Ciud", DDCiudades.SelectedValue)
                comando.ExecuteNonQuery()

                conexion.Close()

                Response.Redirect("PrincipalCamioneros.aspx")
            End If
        End If
    End Sub

    Protected Sub ProvinciasValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles ProvinciasValidator.ServerValidate
        If DDProvincias.SelectedValue = 0 Then
            args.IsValid = False
        End If
    End Sub
End Class
