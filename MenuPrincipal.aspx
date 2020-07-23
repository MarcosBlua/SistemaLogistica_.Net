<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MenuPrincipal.aspx.vb" Inherits="MenuPrincipal" %>

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

<body class="body">

    <div class="header" style="text-align:center">
		<img src="Fidoex.png" width="170" />
	</div>

	<nav class="navbar navbar-expand-md navbar-light bg-light sticky-top">
			<button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#myNavbar">
			<span class="navbar-toggler-icon"></span>
			</button>
	
		<div class="collapse navbar-collapse" id="myNavbar">
			<ul class="navbar-nav mr-auto mx-auto mt-2 mt-md-0">
				<li class="nav-item activa"><a class="nav-link" href="MenuPrincipal.aspx">Menu</a></li>
				<li class="nav-item"><a class="nav-link" href="Envios/PrincipalEnvio.aspx">Envios</a></li>
				<li class="nav-item"><a class="nav-link" href="Viajes/PrincipalViaje.aspx">Viajes</a></li>
				<li class="nav-item"><a class="nav-link" href="Clientes/PrincipalCliente.aspx">Clientes</a></li>
				<li class="nav-item"><a class="nav-link" href="Camioneros/PrincipalCamioneros.aspx">Camioneros</a></li>
                <li class="nav-item"><a class="nav-link" href="Camiones/PrincipalCamion.aspx">Camiones</a></li>
                <li class="nav-item"><a class="nav-link" href="Ciudades/PrincipalCiudad.aspx">Cuidades Soportadas</a></li>
			</ul>
			<ul class="nav navbar-nav navbar-right">
				<li class="nav-item"><a  class="nav-link" href="/Inicio.aspx"><i class="fas fa-edit"></i>Cerrar Sesión</a></li>
			</ul>
		</div>
	</nav>

	<br />

    <div class="container" style="margin-bottom: 100px;">
		<div class="jumbotron" style="text-align:center">
			<img src="Fidoex.png" width="200" />
			<p style="text-align:center; font-size: 20px;"> FidoEx somos una empresa que trabaja desde el 1500 A.C (Por nuestra fundadora la señorita Mirtha Legrand), conformada por un grupo humano con fuerte vocacion de servicio y trabajo, con la mision de satisfacer las expectativas de nuestros clientes y acompañarlos en su crecimiento. </p>
		</div>

		<br />
		<br />
		<br />

		<div class="reportes">
			<div class="row" style="margin-bottom:100px; margin-top:70px;">
				<div class="col-md-4" style="text-align: center">
					<a class="reporte" href="Reporte 1.aspx">Viajes por camionero</a>
				</div>

				<div class="col-md-4" style="text-align: center">
					<a class="reporte" href="Reporte 2.aspx">Viajes a provincias</a>
				</div>

				<div class="col-md-4" style="text-align: center">
					<a class="reporte" href="Reporte 3.aspx">Envíos por clientes</a>
				</div>
			</div>

			<div class="row" style="margin-bottom:100px;">
				<div class="col-md-6" style="text-align: center">
					<a class="reporte" href="Reporte 4.aspx">Viajes a cuidades por provincias</a>
				</div>
		
				<div class="col-md-6" style="text-align: center">
					<a class="reporte" href="Reporte 5.aspx">Viajes por mes</a>
				</div>
			</div>
		</div>
		
	</div>

	<div class="footer">
        <br />
		<div class="centro">
			<h1 style="font-size:30px"> FidoEx, El mundo a tiempo </h1>
	    </div>
	</div>

</body>

</html>
