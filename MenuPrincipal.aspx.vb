
Partial Class MenuPrincipal
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Id_Usuario") Is Nothing Then
                Response.Redirect("/Inicio.aspx")
            End If
        End If
    End Sub
End Class
