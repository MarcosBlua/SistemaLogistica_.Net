Imports System.Data.SqlClient
Partial Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Session("Id_Usuario") Is Nothing Then
                Session.Abandon()
            End If
        End If
    End Sub

    Private Sub btn_Iniciar_Click(sender As Object, e As EventArgs) Handles btn_Iniciar.Click
        If Page.IsValid Then
            Dim lector As SqlDataReader
            Dim conexion As SqlConnection
            Dim comando As SqlCommand

            conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

            conexion.Open()

            comando = New SqlCommand("SELECT  Id_Usuario, Contrasenia FROM Usuarios WHERE Username = @username", conexion)

            comando.Parameters.AddWithValue("@username", Usuario.Text.Trim)

            lector = comando.ExecuteReader()

            If lector.Read() Then
                If (Contrasenia.Text.Trim = lector("Contrasenia")) Then
                    Session("Id_Usuario") = lector("Id_Usuario")
                    Response.Redirect("MenuPrincipal.aspx")
                Else
                    Response.Write("<script language=""javascript"">alert('Contraseña incorrecta!');</script>")
                End If
            Else
                Response.Write("<script language=""javascript"">alert('Usuario no existente!');</script>")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub btn_Registrar_Click(sender As Object, e As EventArgs) Handles btn_Registrar.Click
        If Page.IsValid Then
            Dim lector As SqlDataReader
            Dim conexion As SqlConnection
            Dim comando As SqlCommand

            conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

            conexion.Open()

            comando = New SqlCommand("SELECT  Id_Usuario FROM Usuarios WHERE Username = @username", conexion)

            comando.Parameters.AddWithValue("@username", NombreUs.Text)

            lector = comando.ExecuteReader()

            If lector.Read() Then
                Response.Write("<script language=""javascript"">alert('Ya existe este nombre de usuario!');</script>")
            Else
                conexion.Close()
                conexion.Open()

                comando = New SqlCommand("INSERT INTO Usuarios(Nombre, Username, Email, Contrasenia) VALUES (@NA, @Username, @Email, @Contrasenia)", conexion)

                comando.Parameters.AddWithValue("@NA", Nombre.Text.Trim)
                comando.Parameters.AddWithValue("@Username", NombreUs.Text.Trim)
                comando.Parameters.AddWithValue("@Email", Email.Text.Trim)
                comando.Parameters.AddWithValue("@Contrasenia", ContraRegistro.Text.Trim)

                comando.ExecuteNonQuery()

                Response.Write("<script language=""javascript"">alert('Registrado con exito!');</script>")

                Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
            End If
            conexion.Close()
        End If
    End Sub

    Protected Sub ContraseñaValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles ContraseñaValidator.ServerValidate
        If ContraConfirmRegistro.Text.Trim <> ContraRegistro.Text.Trim Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If
    End Sub

End Class
