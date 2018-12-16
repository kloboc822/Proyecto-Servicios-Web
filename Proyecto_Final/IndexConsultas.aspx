<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndexConsultas.aspx.cs" Inherits="IndexConsultas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <html>
	<head>
		<title>V-Vuelos-Menu de Consultas</title>
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
								<a href="IndexAdmin.aspx" class="logo">
									<span class="symbol"><img src="images/travel.png" alt="" /></span><span class="title">V-Vuelos</span>
								</a>
							<!-- Nav -->
								<nav>
									<ul>
										<li><a href="#menu">Menú</a></li>
									</ul>
								</nav>
						</div>
					</header>

				<!-- Menu -->
					<nav id="menu">
						<h2>Menu</h2>
						<ul>
							<li><a href="IndexAdmin.aspx">Página principal</a></li>
                            <li><a href="Login.aspx">Log Out</a></li>
                            <li><a href="About.aspx">About Us</a></li>
						</ul>
					</nav>

				<!-- Main -->
					<div id="main">
						<div class="inner">
							<header>
								<h1>Menú</h1>
								<p>Por favor, elija una opción</p>
							</header>
							
                            <!--EXAMENES -->
                            <section class="tiles">
                              	<article class="style1">
									<span class="image">                                        
										<img src="images/pic14.jpg" alt="" />
									</span>
									<a> 
										<h2>Consultar Bitácora</h2>
										<div class="content">
											 <asp:Button ID="bitacBtn" runat="server" class = "special" Text="Ir" OnClick="bitacBtn_Click" />
										</div>
                                       
									</a>
								</article>
								<article class="style2">
									<span class="image">
										<img src="images/pic02.jpg" alt="" />
									</span>
									<a>
										<h2>Consultar Aerolíneas</h2>
										<div class="content">
											<asp:Button ID="aeroBtn" runat="server" class = "special" Text="Ir" OnClick="aeroBtn_Click"/>
										</div>
                                         
									</a>
								</article>
                                <article class="style2">
									<span class="image">
										<img src="images/pic11.jpg" alt="" />
									</span>
									<a>
										<h2>Consultar Puertas</h2>
										<div class="content">
											<asp:Button ID="puertaBtn" runat="server" class = "special" Text="Ir" OnClick="puertaBtn_Click" />
										</div>
                                         
									</a>
								</article>
								<%--<article class="style3">
									<span class="image">
										<img src="images/pic03.jpg" alt="" />
									</span>
									<a>
										<h2>Math</h2>
										<div class="content">
											 <asp:Button ID="applyMathBtn" runat="server" class = "special" Text="Apply" OnClick="applyMathBtn_Click"/>
										</div>
                                        
									</a>
								</article>--%>
							</section>

						</div>
					</div>

				<!-- Footer -->
					<footer id="footer">
						<div class="inner">
                           
							<ul class="copyright">
								<li>&copy; V-Vuelos Inc. All rights reserved</li><%--<li>Design: <a href="http://html5up.net">HTML5 UP</a></li>--%>
							</ul>
						</div>
					</footer>
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

