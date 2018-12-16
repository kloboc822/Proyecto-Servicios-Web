<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompraBoleto.aspx.cs" Inherits="CompraBoleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
	<head>
		<title>V-Vuelos</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
		<link rel="stylesheet" href="assets/css/main.css" />
		<!--[if lte IE 9]><link rel="stylesheet" href="assets/css/ie9.css" /><![endif]-->
		<!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
	</head>
	<body>
		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Header -->
					<header id="header">
						<div class="inner">
							<!-- Logo -->
								<a href="IndexUser.aspx" class="logo">
									<span class="symbol"><img src="images/travel.png" alt="" /></span><span class="title">V-Vuelos</span>
								</a>

						</div>
					</header>
                	<nav id="menu">
						<h2>Menu</h2>
						<ul>
							<li><a href="IndexUser.aspx">Página principal</a></li>
                            <li><a href="Login.aspx">Log Out</a></li>
                            <li><a href="About.aspx">About Us</a></li>
						</ul>
					</nav>

				<!-- Footer -->
					<footer id="footer">
						<div class="inner">
							<section>
								<h2>V-Vuelos - Seleccione el destino al que desea Viajar</h2>
									<div class="field half first">
                                        <asp:Label ID="salidaLbl" runat="server" Text="Seleccione Destino"></asp:Label>
                                        <asp:DropDownList ID="destinoTxt" runat="server" DataSourceID="SqlDataSource1" DataTextField="lugar" DataValueField="lugar"></asp:DropDownList>
									    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="SELECT [lugar] FROM [VUELO]"></asp:SqlDataSource>
									</div>
                                    <div class="field half">
                                        <asp:Label ID="Label1" runat="server" Text="Seleccione Fecha de Salida"></asp:Label>
                                        <asp:TextBox ID="fechaSalidaTxt" runat="server" TextMode="Date"></asp:TextBox>
									</div>
                                <div class="field"></div>
                                    <div class="field half first">
                                        <asp:Button ID="volverBtn" runat="server" Text="Volver" OnClick="volverBtn_Click" />
									</div>
									<div class="field half">
                                        <asp:Button ID="buscarBtn" runat="server" Text="Buscar Vuelos" OnClick="buscarBtn_Click" />
									</div>
							</section>
							<ul class="copyright">
								<li>&copy; V-Vuelos Inc. 2018. All rights reserved</li>
							</ul>
						</div>
					</footer>
		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/skel.min.js"></script>
			<script src="assets/js/util.js"></script>
			<!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
			<script src="assets/js/main.js"></script>

	</body>
    </form>
</body>
</html>
