Imports System.Data.SqlClient
Partial Class Clientes_AltaCliente
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

                DDProvincias.DataSource = lector

                DDProvincias.DataValueField = "IdProvincia"

                DDProvincias.DataTextField = "Provincia"

                DDProvincias.DataBind()

                DDProvincias.Items.Insert(0, New ListItem("", 0))

                conexion.Close()
            End If
        End If
    End Sub

    Private Sub DDProvincias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDProvincias.SelectedIndexChanged
        Dim lector As SqlDataReader
        Dim conexion As SqlConnection
        Dim comando As SqlCommand

        conexion = New SqlConnection(ConfigurationManager.AppSettings("conSTR"))

        conexion.Open()

        comando = New SqlCommand("SELECT IdCiudad, Ciudad FROM Ciudad WHERE IdProvincia = @id and Baja=0", conexion)

        comando.Parameters.AddWithValue("@id", DDProvincias.SelectedValue)

        lector = comando.ExecuteReader()

        DDCiudades.DataSource = lector

        DDCiudades.DataValueField = "IdCiudad"

        DDCiudades.DataTextField = "Ciudad"

        DDCiudades.DataBind()

        conexion.Close()
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
                comando = New SqlCommand("INSERT INTO Clientes(Nombre, Direccion, Telefono, Cuit, IdProvincia, IdCiudad, Baja) VALUES (@NA, @Dir, @Tel, @CUIT, @Prov, @Ciud, 0)", conexion)

                comando.Parameters.AddWithValue("@NA", NyA.Text)
                comando.Parameters.AddWithValue("@Dir", Dir.Text)
                comando.Parameters.AddWithValue("@Tel", Tel.Text)
                comando.Parameters.AddWithValue("@CUIT", txt_CUIT.Text)
                comando.Parameters.AddWithValue("@Prov", DDProvincias.SelectedValue)
                comando.Parameters.AddWithValue("@Ciud", DDCiudades.SelectedValue)
                comando.ExecuteNonQuery()

                conexion.Close()

                Response.Redirect("PrincipalCliente.aspx")
            End If
        End If
    End Sub

    Protected Sub ProvinciasValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles ProvinciasValidator.ServerValidate
        If DDProvincias.SelectedValue = 0 Then
            args.IsValid = False
        End If
    End Sub

    Protected Sub CuitValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CuitValidator.ServerValidate
        Dim Sen As Integer, S As Integer, i As Integer
        Dim Coef As String, CUIT As String
        Dim R%
        'Dim cuitx As String = txt_CUIT.Text.Replace("-", "")

        Coef = "5432765432" ' Destinado a la verificación del CUIT

        CUIT = Left(txt_CUIT.Text, 2) + Mid(txt_CUIT.Text, 4, 8) + Right(txt_CUIT.Text, 1)
        S = 0
        ' Efectuo suma en S de los productos de cada dígito del Coeficiente (COEF) * los del CUIT
        For i = 1 To 10
            S = S + Val(Mid(CUIT, i, 1)) * Val(Mid(Coef, i, 1))
        Next

        R = S Mod 11 ' Averiguo el remanente de dividir S / 11

        If R > 1 Then ' Si el remanente es > 1 divido en R 11/R
            R = 11 - R
        End If

        If R = Right(CUIT, 1) Then ' Si R=Código de verificación (dígito derecho del CUIT)
        Else
            args.IsValid = False
        End If
    End Sub
End Class
