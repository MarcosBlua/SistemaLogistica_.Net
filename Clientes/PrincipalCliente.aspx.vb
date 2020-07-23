Imports System.Data.SqlClient
Partial Class Clientes_PrincipalCliente
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

                comando = New SqlCommand("Select C.IdCliente, C.Nombre, C.Direccion, C.Telefono, C.Cuit, P.Provincia, CD.Ciudad From Clientes C Join Provincias P On C.IdProvincia = P.IdProvincia Join Ciudad CD On C.IdCiudad = CD.IdCiudad Where C.Baja = 0", conexion)

                lector = comando.ExecuteReader()

                listado.DataSource = lector

                listado.DataBind()

                conexion.Close()

            End If
        End If
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        Response.Redirect("AltaCliente.aspx")
    End Sub
End Class
