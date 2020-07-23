Imports System.Data.SqlClient
Partial Class Envios_PrincipalEnvio
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

                comando = New SqlCommand("Select E.IdEnvio, E.IdViaje, C.Nombre, E.Estado, E.Descripcion From Envios E Join Clientes C On E.IdCliente = C.IdCliente Where E.Baja = 0", conexion)

                lector = comando.ExecuteReader()

                listado.DataSource = lector

                listado.DataBind()

                conexion.Close()

            End If
        End If
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        Response.Redirect("AltaEnvio.aspx")
    End Sub
End Class
