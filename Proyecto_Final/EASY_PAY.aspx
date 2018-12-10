<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EASY_PAY.aspx.cs" Inherits="EASY_PAY" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <<html>
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
                        <h1>Pago EasyPay</h1>
						<div class="field half first">
                             <asp:TextBox ID="CuentaTxt" runat="server" placeholder="Número de cuenta"></asp:TextBox> 
						</div>
						<div class="field">
                            <asp:TextBox ID="CodTxt" runat="server" placeholder="Código de seguridad"></asp:TextBox>
						</div>
                        <div class="field">
                            <asp:TextBox ID="ContrasenaTxt" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
						</div>
                        <br />
                        <div class="first half field">
                                <asp:Button ID="pagar" class="special" runat="server" Text="Realizar pago" OnClick="pagar_Click"  />
                            </div>
                            <div class="first half field">
                                <asp:Button ID="cancelar" runat="server" Text="Cancelar"  />

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
        </div>
    </form>
</body>
</html>