Imports System.Data.SqlClient
Partial Class Reporte_5
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

                comando = New SqlCommand("Select Format(Fecha, 'MMMM', 'es-es') Month, Count(*) Count From Viaje Where Year(Fecha) = @anio Group By Format(Fecha, 'MMMM', 'es-es');", conexion)

                comando.Parameters.AddWithValue("@anio", Today.Year)

                lector = comando.ExecuteReader()

                While lector.Read()
                    Chart1.Series("Series1").Points.AddXY(lector("Month"), lector("Count"))
                End While

                conexion.Close()
            End If
        End If
    End Sub
End Class
