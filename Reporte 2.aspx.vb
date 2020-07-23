Imports System.Data.SqlClient
Partial Class Reporte2
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

                comando = New SqlCommand("SELECT P.Provincia, count(V.IdProvinciaDestino) AS cantViajes FROM Viaje V INNER JOIN Provincias P ON P.IdProvincia = v.IdProvinciaDestino WHERE P.Baja = 0 And V.Fecha > @Fech GROUP BY P.Provincia", conexion)

                comando.Parameters.AddWithValue("@Fech", Today.AddYears(-1))

                lector = comando.ExecuteReader()

                While lector.Read()
                    Chart1.Series("Series1").Points.AddXY(lector("Provincia"), lector("cantViajes"))
                End While

                conexion.Close()
            End If
        End If

    End Sub
End Class
