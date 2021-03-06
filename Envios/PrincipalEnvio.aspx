﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrincipalEnvio.aspx.vb" Inherits="Envios_PrincipalEnvio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FidoEx</title>
    <meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
	<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"></script>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" runat="server" />
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <link href="/your-path-to-fontawesome/css/all.css" rel="stylesheet" />
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
				<li class="nav-item activa"><a class="nav-link" href="/Envios/PrincipalEnvio.aspx">Envios</a></li>
				<li class="nav-item"><a class="nav-link" href="/Viajes/PrincipalViaje.aspx">Viajes</a></li>
				<li class="nav-item"><a class="nav-link" href="/Clientes/PrincipalCliente.aspx">Clientes</a></li>
				<li class="nav-item"><a class="nav-link" href="/Camioneros/PrincipalCamioneros.aspx">Camioneros</a></li>
                <li class="nav-item"><a class="nav-link" href="/Camiones/PrincipalCamion.aspx">Camiones</a></li>
                <li class="nav-item"><a class="nav-link" href="/Ciudades/PrincipalCiudad.aspx">Cuidades Soportadas</a></li>
			</ul>
            <ul class="nav navbar-nav navbar-right">
				<li class="nav-item"><a  class="nav-link" href="/Inicio.aspx"><i class="fas fa-edit"></i>Cerrar Sesión</a></li>
			</ul>
		</div>
	</nav>

    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Agregar" runat="server" Text="Crear Nuevo Envio" class="boton"/>
            
            <h1 style="margin-left: 30px;"> Envios Activos </h1>

            <div class="container-table">
                <table class ="table table-hover">
                    <tr>
                        <th>ID</th>
                        <th>ID del Viaje</th>
                        <th>ID del Cliente</th>
                        <th>Estado</th>
                        <th>Descripcion</th>
                        <th></th>
                        <th></th>
                    </tr>
                    <asp:Repeater ID="listado" runat="server">
                        <itemtemplate>
                            <tr>
                                <td><%# Container.DataItem("IdEnvio") %></td>
                                <td><%# Container.DataItem("IdViaje") %></td>
                                <td><%# Container.DataItem("Nombre") %></td>
                                <td><%# Container.DataItem("Estado") %></td>
                                <td><%# Container.DataItem("Descripcion") %></td>
                                <td><a href="ModEnvio.aspx?id=<%# Container.DataItem("IdEnvio") %>"><i class="fas fa-edit"></i></a></td>  
                                <td><a href="BajaEnvio.aspx?id=<%# Container.DataItem("IdEnvio") %>"><i class="fas fa-trash"></i></a></td> 
                            </tr>
                        </itemtemplate>
                    </asp:Repeater>
                </table>
            </div>

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
