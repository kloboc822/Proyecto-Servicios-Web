<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consecutivos.aspx.cs" Inherits="Consecutivos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        
    <html>
	<head>
		<title>Generic - Phantom by HTML5 UP</title>
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
								<a href="index.aspx" class="logo">
									<span class="symbol"><img src="images/test.svg" alt="" /></span><span class="title">V-Vuelos</span>
								</a>

							<!-- Nav -->
								<nav>
									<ul>
										<li><a href="#menu">Menu</a></li>
									</ul>
								</nav>

						</div>
					</header>

				<!-- Menu -->
					<nav id="menu">
						<h2>Menu</h2>
						<ul>
							<li><a href="index.html">Home</a></li>
							<li><a href="generic.html">Ipsum veroeros</a></li>
							<li><a href="generic.html">Tempus etiam</a></li>
							<li><a href="generic.html">Consequat dolor</a></li>
							<li><a href="elements.html">Elements</a></li>
						</ul>
					</nav>
            <!-- Main -->
       <asp:Panel ID="main" runat="server">
           <asp:Panel ID="Panel1" class="inner" runat="server">
                  <h1>Información del consecutivo</h1>
                  <div class="field">
                        <h2>Descripcion:</h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="dplDesc" runat="server">
                            <asp:ListItem Value="Aerolinea">Aerolinea</asp:ListItem>
                            <asp:ListItem Value="Paises">Paises</asp:ListItem>
                            <asp:ListItem Value="Puertas del Aeropuerto">Puertas del Aeropuerto</asp:ListItem>
                            <asp:ListItem Value="Compra de Boletos">Compra de Boletos</asp:ListItem>
                            <asp:ListItem Value="Reservacion de Boletos">Reservacion de Boletos</asp:ListItem>
                            <asp:ListItem Value="Vuelos">Vuelos</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </div>
                    <div class="field">
                        <h2>Consecutivo:</h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:TextBox ID="txtCon" runat="server"></asp:TextBox>
                        <br />
                    </div>
                    <div class="field">
                        <h2>Prefijo Existente:</h2>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnEna" runat="server" OnClick="btnEna_Click" Text="Si"  />
                &nbsp;<asp:DropDownList ID="dplPre" runat="server" DataSourceID="SqlDataSource1" DataTextField="prefijo" DataValueField="prefijo" Enabled="False">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="SELECT [prefijo] FROM [CONSECUTIVO]"></asp:SqlDataSource>
                        <br />
                    </div>
                    <div class="field">
                        <h2>Prefijo:</h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtPre" runat="server"></asp:TextBox>
                        <br />
                    </div>
                    <div class="field">
                        <h2>Rango Inicial:</h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtRanIni" runat="server"></asp:TextBox>
                        <br />
                    </div>
                    <div class="field">
                        <h2>Rango Final:</h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtRanFin" runat="server"></asp:TextBox>
                        <br />
                    </div>
                        <br />
                    <div class="field">
                        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" class="special" />
    
                    &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnVerDa" runat="server" Enabled="False" OnClick="btnVerDa_Click" Text="VerDatos" class="special" />
    
                    &nbsp;
                        <asp:Button ID="btnVer" runat="server" OnClick="btnVer_Click" Text="Ver Consecutivos" class="special"/>
                    </div>
                    </asp:Panel>
                </asp:Panel>

				<!-- Footer -->
                
			</div>

		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/skel.min.js"></script>
			<script src="assets/js/util.js"></script>
			<!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
			<script src="assets/js/main.js"></script>

	</body>
</html>

    </form>
</body>
</html>
