<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Inicio.aspx.vb" Inherits="Inicio" MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FidoEx</title>
    <meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"></script>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" runat="server" />
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
	<link rel="stylesheet" type="text/css" href="Estilos.css" runat="server" />
</head>
<body>

    <div class="header" style="text-align:center; height: 100px; margin-bottom: 80px;">
		<img src="Fidoex.png" width="270" />
	</div>

    <form id="form1" runat="server">
		<div class="container">
			<div class="row">
				<div class="col-md-6" style="text-align:center">
					<h1> Inicio sesión </h1>
					<div class="form-group"> 
						<label> Usuario </label> 
						<asp:TextBox ID="Usuario" runat="server" placeholder="Elmox" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ValidationGroup="Inicio_Group" runat="server" ErrorMessage=" *Requerido" ControlToValidate="Usuario" ForeColor="red"></asp:RequiredFieldValidator>
					</div> 
					<div class="form-group"> 
						<label> Contraseña </label> 
						<asp:TextBox ID="Contrasenia" runat="server" type="password" placeholder="******" class="form-control"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ValidationGroup="Inicio_Group" runat="server" ErrorMessage=" *Requerido" ControlToValidate="Contrasenia" ForeColor="red"></asp:RequiredFieldValidator>
					</div> 
					<div class="form-group"> 
						<asp:Button ID="btn_Iniciar" runat="server" Text="Iniciar sesión" ValidationGroup="Inicio_Group"/>
					</div>
				</div>

				<div class="col-md-6" style="text-align:center">
					<h1> Registrarse </h1>
					<div class="form-group"> 
						<label> Nombre </label>
                        <asp:TextBox ID="Nombre" runat="server" class="form-control" placeholder="Elmo Perez"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Registro_Group" runat="server" ErrorMessage=" *Requerido" ControlToValidate="Nombre" ForeColor="red"></asp:RequiredFieldValidator>
					</div> 
					<div class="form-group"> 
						<label> Nombre de usuario </label>
                        <asp:TextBox ID="NombreUs" runat="server" class="form-control" placeholder="Elmox"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Registro_Group" runat="server" ErrorMessage=" *Requerido" ControlToValidate="NombreUs" ForeColor="red"></asp:RequiredFieldValidator>
					</div>
					<div class="form-group"> 
						<label> Correo electronico </label>
                        <asp:TextBox ID="Email" runat="server" type="email" class="form-control" placeholder="Elmothor@juanmeil.com"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="Registro_Group" runat="server" ErrorMessage=" *Requerido" ControlToValidate="Email" ForeColor="red"></asp:RequiredFieldValidator>
					</div>
					<div class="form-group"> 
						<label> Contraseña </label> 
						<asp:TextBox ID="ContraRegistro" type="password" runat="server" class="form-control" placeholder="******"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Registro_Group" runat="server" ErrorMessage=" *Requerido" ControlToValidate="ContraRegistro" ForeColor="red"></asp:RequiredFieldValidator>
					</div>
					<div class="form-group"> 
						<label> Confirmar contraseña </label> 
						<asp:TextBox ID="ContraConfirmRegistro" type="password" runat="server" class="form-control" placeholder="******"></asp:TextBox>
						<asp:CustomValidator runat="server" ID="ContraseñaValidator" ControlToValidate="ContraConfirmRegistro" ValidationGroup="Registro_Group" ErrorMessage=" *Las contraseñas no coinciden" ForeColor="red" OnServerValidate="ContraseñaValidator_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
					</div>
					<div class="form-group">
                        <asp:Button ID="btn_Registrar" runat="server" Text="Registrarme" ValidationGroup="Registro_Group"/>
					</div>
				</div>
			</div>
		</div>
    </form>

    <div class="footer">
        <br />
		<div class="centro">
			<h1 style="font-size:30px"> FidoEx, El mundo a tiempo </h1>
	    </div>
	</div>

	<script runat="server">

	</script>

</body>
</html>
