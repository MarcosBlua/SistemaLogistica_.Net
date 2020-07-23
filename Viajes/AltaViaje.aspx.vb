Imports System.Data.SqlClient
Partial Class Viajes_AltaViaje
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

                lector.Close()

                comando = New SqlCommand("SELECT IdCamion, Patente FROM Camiones WHERE Baja=0", conexion)

                lector = comando.ExecuteReader()

                DDCamiones.DataSource = lector

                DDCamiones.DataValueField = "IdCamion"

                DDCamiones.DataTextField = "Patente"

                DDCamiones.DataBind()

                DDCamiones.Items.Insert(0, New ListItem("", 0))

                lector.Close()

                comando = New SqlCommand("SELECT IdCamionero, NombreApellido FROM Camioneros WHERE Baja=0", conexion)

                lector = comando.ExecuteReader()

                DDCamioneros.DataSource = lector

                DDCamioneros.DataValueField = "IdCamionero"

                DDCamioneros.DataTextField = "NombreApellido"

                DDCamioneros.DataBind()

                DDCamioneros.Items.Insert(0, New ListItem("", 0))

                conexion.Close()

                DDEstado.Items.Add(New ListItem("Preparandose", 1))
                DDEstado.Items.Add(New ListItem("Viajando", 2))
                DDEstado.Items.Add(New ListItem("Terminado", 3))

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
                comando = New SqlCommand("INSERT INTO Viaje(IdProvinciaDestino, IdCiudadDestino, IdCamion, IdCamionero, Estado, Fecha, Baja) VALUES (@Prov, @Ciud, @Camion, @Camionero, @Est, @Fech , @Baja)", conexion)

                comando.Parameters.AddWithValue("@Fech", Today)
                comando.Parameters.AddWithValue("@Est", DDEstado.SelectedItem.Text)
                comando.Parameters.AddWithValue("@Prov", DDProvincias.SelectedValue)
                comando.Parameters.AddWithValue("@Ciud", DDCiudades.SelectedValue)
                comando.Parameters.AddWithValue("@Camion", DDCamiones.SelectedValue)
                comando.Parameters.AddWithValue("@Camionero", DDCamioneros.SelectedValue)
                If (DDEstado.SelectedValue = 1) Then
                    comando.Parameters.AddWithValue("@Baja", 0)
                ElseIf (DDEstado.SelectedValue = 2) Then
                    comando.Parameters.AddWithValue("@Baja", 0)
                ElseIf (DDEstado.SelectedValue = 3) Then
                    comando.Parameters.AddWithValue("@Baja", 1)
                End If
                comando.ExecuteNonQuery()

                conexion.Close()

                Response.Redirect("PrincipalViaje.aspx")
            End If
        End If
    End Sub

    Protected Sub ProvinciasValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles ProvinciasValidator.ServerValidate
        If DDProvincias.SelectedValue = 0 Then
            args.IsValid = False
        End If
    End Sub

    Protected Sub CamionesValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CamionesValidator.ServerValidate
        If DDCamiones.SelectedValue = 0 Then
            args.IsValid = False
        End If
    End Sub

    Protected Sub CamionerosValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CamionerosValidator.ServerValidate
        If DDCamioneros.SelectedValue = 0 Then
            args.IsValid = False
        End If
    End Sub
End Class
