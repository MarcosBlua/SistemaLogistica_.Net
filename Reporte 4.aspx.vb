Imports System.Data.SqlClient
Partial Class Reporte_4
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

                DDProvincia.DataSource = lector

                DDProvincia.DataValueField = "IdProvincia"

                DDProvincia.DataTextField = "Provincia"

                DDProvincia.DataBind()

                conexion.Close()

                DDProvincia_SelectedIndexChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub DDProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDProvincia.SelectedIndexChanged
        If Session("Id_Usuario") Is Nothing Then
            Response.Redirect("/Inicio.aspx")
        Else
            Dim lector As SqlDataReader
            Dim conexion As SqlConnection
            Dim comando As SqlCommand

            conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

            conexion.Open()

            comando = New SqlCommand("SELECT C.Ciudad, count(V.IdCiudadDestino) AS cantViajesCiudad FROM Viaje V INNER JOIN Ciudad C ON C.IdCiudad = v.IdCiudadDestino WHERE C.Baja = 0 AND V.IdProvinciaDestino = @idProv And V.Fecha > @Fech GROUP BY C.Ciudad", conexion)

            comando.Parameters.AddWithValue("@idProv", DDProvincia.SelectedValue)
            comando.Parameters.AddWithValue("@Fech", Today.AddYears(-1))

            lector = comando.ExecuteReader()

            While lector.Read()
                Chart1.Series("Series1").Points.AddXY(lector("Ciudad"), lector("cantViajesCiudad"))
            End While

            conexion.Close()
        End If
    End Sub
End Class
