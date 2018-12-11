<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tarjeta.aspx.cs" Inherits="Tarjeta" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>  

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
           <script src="https://www.google.com/recaptcha/api.js" async defer></script>
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
							<li><a href="IndexUser.aspx">Página principal</a></li>
                            <li><a href="Login.aspx">Log Out</a></li>
                            <li><a href="About.aspx">About Us</a></li>
						</ul>
					</nav>

				<!-- Main -->
                <asp:Panel ID="main" runat="server">
                    <asp:Panel ID="Panel1" class="inner" runat="server">
                        <h1>Pago por tarjeta</h1>
                        <div class="field">
                            <h2>Nombre del tarjethabiente</h2>
                            <asp:TextBox ID="nombreTxt" runat="server" placeholder="Dueño"></asp:TextBox>
                        </div>
                        <div class="field">
                            <h2>Número de tarjeta</h2>
                            <asp:TextBox ID="tarjetaTxt" runat="server" placeholder="Número de tarjeta"></asp:TextBox>
                        </div>
                        <div class="field">
                            <h2>Código de seguridad de la tarjeta</h2>
                            <asp:TextBox ID="codTxt" runat="server" placeholder="CVV" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="field">
                            <h2>Seleccione el método de pago</h2>
                             <asp:DropDownList ID="TipoTxt" runat="server">
                                 <asp:ListItem>Tipo de tarjeta</asp:ListItem>
                                 <asp:ListItem>VISA</asp:ListItem>
                                 <asp:ListItem>Mastercard</asp:ListItem>
                                 <asp:ListItem>American Express</asp:ListItem>
                             </asp:DropDownList>
						</div>
                        <br />
                        <h2>Seleccione el mes y año de expiración de la tarjeta</h2>
                        <div class="field half first">
                            <asp:DropDownList ID="mesTxt" runat="server">
                                <asp:ListItem>Mes de expiración</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="field half second">
                            <asp:DropDownList ID="annoTxt" runat="server">
                                <asp:ListItem>Año de expiración</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>
                                <asp:ListItem>2021</asp:ListItem>
                                <asp:ListItem>2022</asp:ListItem>
                                <asp:ListItem>2023</asp:ListItem>
                                <asp:ListItem>2024</asp:ListItem>
                                <asp:ListItem>2024</asp:ListItem>
                                <asp:ListItem>2025</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="field">
                                    <div class="g-recaptcha" data-sitekey="6LfnN4AUAAAAAObMA2Er2Mgb7EdqdgtTiSOoBK1W"></div>
                                    <asp:Button ID="btntest" runat="server" OnClick="btntest_Click" Text="Enviar" Visible="False" />
                                    <asp:Label ID="lbltest" runat="server" Text="Label" Visible="False"></asp:Label>                           
                        </div>
                        <div class="first half field">
                            <asp:Button ID="pagar" runat="server" class="special" OnClick="pagar_Click" Text="Realizar pago" />
                        </div>
                        <div class="second half field">
                            <asp:Button ID="cancelar" runat="server" Text="Cancelar" />
                        </div>
                         <br />
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
        <footer align="center">

 <div id="google_translate_element"></div><script type="text/javascript">
function googleTranslateElementInit() {
  new google.translate.TranslateElement({pageLanguage: 'es', includedLanguages: 'de,en,es,it', layout: google.translate.TranslateElement.InlineLayout.SIMPLE}, 'google_translate_element');
}
</script><script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
    <style type="text/css">
		.goog-te-banner-frame.skiptranslate{display:none!important;}
		body{top:0px!important;}
		</style>
</footer>
</body>
</html>

