<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EASY_PAY.aspx.cs" Inherits="EASY_PAY" %>
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
                        <div class="field">
                                    <div class="g-recaptcha" data-sitekey="6LfnN4AUAAAAAObMA2Er2Mgb7EdqdgtTiSOoBK1W"></div>
                                    <asp:Button ID="btntest" runat="server" OnClick="btntest_Click" Text="Enviar" Visible="False" />
                                    <asp:Label ID="lbltest" runat="server" Text="Label" Visible="False"></asp:Label>                           
                        </div>
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