﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AltaCamionero.aspx.vb" Inherits="Camioneros_AltaCamionero" %>

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
	<link rel="stylesheet" type="text/css" href="/Estilos.css" runat="server" />
</head>

<body>

    <div class="header" style="text-align:center">
		<img src="/Fidoex.png" width="170" />
	</div>

    <nav class="navbar navbar-expand-md navbar-light bg-light sticky-top">
			<button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#myNavbar">
			<span class="navbar-toggler-icon"></span>
			</button>
	
		<div class="collapse navbar-collapse" id="myNavbar">
			<ul class="navbar-nav mr-auto mx-auto mt-2 mt-md-0">
				<li class="nav-item"><a class="nav-link" href="/MenuPrincipal.aspx">Menu</a></li>
				<li class="nav-item"><a class="nav-link" href="/Envios/PrincipalEnvio.aspx">Envios</a></li>
				<li class="nav-item"><a class="nav-link" href="/Viajes/PrincipalViaje.aspx">Viajes</a></li>
				<li class="nav-item"><a class="nav-link" href="/Clientes/PrincipalCliente.aspx">Clientes</a></li>
				<li class="nav-item activa"><a class="nav-link" href="/Camioneros/PrincipalCamioneros.aspx">Camioneros</a></li>
                <li class="nav-item"><a class="nav-link" href="/Camiones/PrincipalCamion.aspx">Camiones</a></li>
                <li class="nav-item"><a class="nav-link" href="/Ciudades/PrincipalCiudad.aspx">Cuidades Soportadas</a></li>
			</ul>
            <ul class="nav navbar-nav navbar-right">
				<li class="nav-item"><a  class="nav-link" href="/Inicio.aspx"><i class="fas fa-edit"></i>Cerrar Sesión</a></li>
			</ul>
		</div>
	</nav>

    <form id="form1" runat="server">
        <div class="container">
            <br />
            <br />
            <br />
            <table class ="table table-hover">
                <tr>
                    <td>Nombre y Apellido</td>
                    <td>
                        <asp:TextBox ID="NyA" runat="server" placeholder="Juanito Mangelo"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" *Requerido" ControlToValidate="NyA" ForeColor="red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>DNI</td>
                    <td>
                        <asp:TextBox ID="DNI" runat="server" placeholder="40.279.078"></asp:TextBox>     
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" *Requerido" ControlToValidate="DNI" ForeColor="red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="DNI" ValidationExpression="\d{2}.\d{3}.\d{3}" EnableClientScript="False" ErrorMessage=" *Formato de DNI no correcto" ForeColor="red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Provincia</td>
                    <td>
                        <asp:DropDownList ID="DDProvincias" runat="server" AutoPostBack="True"></asp:DropDownList>
                        <asp:CustomValidator ID="ProvinciasValidator" runat="server" ErrorMessage=" *Requerido" ControlToValidate="DDProvincias" ForeColor="red" OnServerValidate="ProvinciasValidator_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>Ciudad</td>
                    <td>
                        <asp:DropDownList ID="DDCiudades" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" *Requerido" ControlToValidate="DDCiudades" ForeColor="red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Dirección</td>
                    <td>
                        <asp:TextBox ID="Dir" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage=" *Requerido" ControlToValidate="Dir" ForeColor="red"></asp:RequiredFieldValidator>
                    </td>
                </tr>            
                <tr>
                    <td>Teléfono</td>
                    <td>
                        <asp:TextBox ID="Tel" runat="server" placeholder="3492-000000"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" *Requerido" ControlToValidate="Tel" ForeColor="red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Tel" ValidationExpression="\d{4}-\d{6}" EnableClientScript="False" ErrorMessage=" *Formato de telefono no correcto" ForeColor="red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>           
            </table>
            
            <asp:Button ID="Guardar" runat="server" Text="Guardar Nuevo Camionero" class="boton"/>
            
        </div>
    </form>

    <div class="footer">
        <br />
		<div class="centro">
			<h1 style="font-size:30px"> FidoEx, El mundo a tiempo </h1>
	    </div>
	</div>

</body>

</html>
