Imports System.Data.SqlClient
Partial Class Viajes_PrincipalViaje
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

                comando = New SqlCommand("Select V.IdViaje, P.Provincia, CD.Ciudad, CM.Patente, CA.NombreApellido, V.Estado From Viaje V Join Provincias P On V.IdProvinciaDestino = P.IdProvincia Join Ciudad CD On V.IdCiudadDestino = CD.IdCiudad join Camiones CM On V.IdCamion = CM.IdCamion Join Camioneros CA On V.IdCamionero = CA.IdCamionero Where V.Baja = 0", conexion)

                lector = comando.ExecuteReader()

                listado.DataSource = lector

                listado.DataBind()

                conexion.Close()

            End If
        End If
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        Response.Redirect("AltaViaje.aspx")
    End Sub
End Class
