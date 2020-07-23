Imports System.Data.SqlClient

Partial Class Reporte_1
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

                comando = New SqlCommand("SELECT C.NombreApellido, count(V.IdCamionero) AS cantViajesCamionero FROM Viaje V INNER JOIN Camioneros C ON C.IdCamionero = v.IdCamionero WHERE C.Baja = 0 And V.Fecha > @Fech GROUP BY C.NombreApellido", conexion)

                comando.Parameters.AddWithValue("@Fech", Today.AddYears(-1))

                lector = comando.ExecuteReader()

                While lector.Read()
                    Chart1.Series("Series1").Points.AddXY(lector("NombreApellido"), lector("cantViajesCamionero"))
                End While

                conexion.Close()
            End If
        End If
    End Sub
End Class
