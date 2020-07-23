Imports System.Data.SqlClient
Partial Class Reporte_3
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

                comando = New SqlCommand("Select C.Nombre, count(E.IdEnvio) As cantEnvios From Envios E Join Clientes C On E.IdCliente = C.IdCliente Join Viaje V On E.IdViaje = V.IdViaje Where C.Baja = 0 And V.Fecha > @Fech Group By C.Nombre", conexion)

                comando.Parameters.AddWithValue("@Fech", Today.AddYears(-1))

                lector = comando.ExecuteReader()

                While lector.Read()
                    Chart1.Series("Series1").Points.AddXY(lector("Nombre"), lector("cantEnvios"))
                End While

                conexion.Close()
            End If
        End If

    End Sub
End Class
