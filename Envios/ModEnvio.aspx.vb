Imports System.Data.SqlClient
Partial Class Envios_ModEnvio
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

                comando = New SqlCommand("SELECT IdViaje FROM Viaje WHERE Baja=0", conexion)

                lector = comando.ExecuteReader()

                DDViajes.DataSource = lector

                DDViajes.DataValueField = "IdViaje"

                DDViajes.DataTextField = "IdViaje"

                DDViajes.DataBind()

                lector.Close()

                comando = New SqlCommand("SELECT IdCliente, Nombre FROM Clientes WHERE Baja=0", conexion)

                lector = comando.ExecuteReader()

                DDClientes.DataSource = lector

                DDClientes.DataValueField = "IdCliente"

                DDClientes.DataTextField = "Nombre"

                DDClientes.DataBind()

                DDClientes.Items.Insert(0, New ListItem("", 0))

                lector.Close()

                DDEstado.Items.Add(New ListItem("En proceso", 1))
                DDEstado.Items.Add(New ListItem("En camino", 2))
                DDEstado.Items.Add(New ListItem("Entregado", 3))

                comando = New SqlCommand("SELECT * FROM Envios WHERE IdEnvio = @id and Baja = 0", conexion)

                comando.Parameters.AddWithValue("@id", Request.QueryString("id"))

                lector = comando.ExecuteReader()

                If lector.Read() Then
                    DDViajes.SelectedValue = lector("IdViaje")
                    DDEstado.SelectedItem.Text = lector("Estado")
                    DDClientes.SelectedValue = lector("IdCliente")
                    Des.Text = lector("Descripcion")
                End If

                conexion.Close()
            End If
        End If
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
                comando = New SqlCommand("UPDATE Envios SET IdViaje = @Viaje, Estado = @Est, Descripcion = @Desc, Baja = @Baja, IdCliente = @Clie WHERE IdEnvio = @id", conexion)

                comando.Parameters.AddWithValue("@id", Request.QueryString("id"))
                comando.Parameters.AddWithValue("@Est", DDEstado.SelectedItem.Text)
                comando.Parameters.AddWithValue("@Viaje", DDViajes.SelectedValue)
                comando.Parameters.AddWithValue("@Desc", Des.Text)
                comando.Parameters.AddWithValue("@Clie", DDClientes.SelectedValue)
                If (DDEstado.SelectedValue = 1) Then
                    comando.Parameters.AddWithValue("@Baja", 0)
                ElseIf (DDEstado.SelectedValue = 2) Then
                    comando.Parameters.AddWithValue("@Baja", 0)
                ElseIf (DDEstado.SelectedValue = 3) Then
                    comando.Parameters.AddWithValue("@Baja", 1)
                End If
                comando.ExecuteNonQuery()

                conexion.Close()

                Response.Redirect("PrincipalEnvio.aspx")
            End If
        End If
    End Sub

    Protected Sub ClientesValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles ClientesValidator.ServerValidate
        If DDClientes.SelectedValue = 0 Then
            args.IsValid = False
        End If
    End Sub

    Protected Sub ViajesValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles ViajesValidator.ServerValidate
        If DDViajes.SelectedValue = 0 Then
            args.IsValid = False
        End If
    End Sub
End Class
