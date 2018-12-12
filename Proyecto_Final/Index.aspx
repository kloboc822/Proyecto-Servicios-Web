<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

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
		<title>V-Vuelos-Menu de Administracion</title>
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
								<a href="About.aspx" class="logo">
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
								<h1>Menú de Administración</h1>
								<p>Opciones disponibles para el menú administrativo.</p>
							</header>
							
                            <!--EXAMENES -->
                            <section class="tiles">
                              	<article class="style1">
									<span class="image">                                        
										<img src="images/pic14.jpg" alt="" />
									</span>
									<a> 
										<h2>Administrar Países</h2>
										<div class="content">
											 <asp:Button ID="BtnPaises" runat="server" class = "special" Text="Ir" OnClick="BtnPaises_Click"  />
										</div>
                                       
									</a>
								</article>
								<article class="style2">
									<span class="image">
										<img src="images/pic02.jpg" alt="" />
									</span>
									<a>
										<h2>Administrar Puertas</h2>
										<div class="content">
											<asp:Button ID="BtnPuertas" runat="server" class = "special" Text="Ir" OnClick="BtnPuertas_Click"/>
										</div>
                                         
									</a>
								</article>
								<article class="style3">
									<span class="image">
										<img src="images/pic03.jpg" alt="" />
									</span>
									<a>
										<h2>Consecutivos</h2>
										<div class="content">
											 <asp:Button ID="btnConsecutivos" runat="server" class = "special" Text="Ir" OnClick="btnConsecutivos_Click" />
										</div>
                                        
									</a>
								</article>
                                <article class="style4">
									<span class="image">
										<img src="images/pic04.jpg" alt="" />
									</span>
									<a>
										<h2>Aerolineas</h2>
										<div class="content">
											 <asp:Button ID="btnAerolineas" runat="server" class = "special" Text="Ir" OnClick="btnAerolineas_Click" />
										</div>
                                        
									</a>
								</article>
                                       <article class="style5">
									<span class="image">
										<img src="images/pic05.jpg" alt="" />
									</span>
									<a>
										<h2>Vuelos</h2>
										<div class="content">
											 <asp:Button ID="btnVuelos" runat="server" class = "special" Text="Ir" OnClick="btnVuelos_Click" />
										</div>
                                        
									</a>
								</article>
                                       <article class="style5">
									<span class="image">
										<img src="images/pic11.jpg" alt="" />
									</span>
									<a>
										<h2>Crear usuario</h2>
										<div class="content">
											 <asp:Button ID="BtnUsuario" runat="server" class = "special" Text="Ir" OnClick="BtnUsuario_Click" />
										</div>
                                        
									</a>
								</article>
							</section>

						</div>
					</div>

				<!-- Footer -->
					<footer id="footer">
						<div class="inner">
                            <%--<section>
								<h2>Get in touch</h2>
								<form method="post" action="#">
									<div class="field half first">
										<input type="text" name="name" id="name" placeholder="Name" />
									</div>
									<div class="field half">
										<input type="email" name="email" id="email" placeholder="Email" />
									</div>
									<div class="field">
										<textarea name="message" id="message" placeholder="Message"></textarea>
									</div>
									<ul class="actions">
										<li><input type="submit" value="Send" class="special" /></li>
									</ul>
								</form>
							</section>
							<section>
								<h2>Follow</h2>
								<ul class="icons">
									<li><a href="#" class="icon style2 fa-twitter"><span class="label">Twitter</span></a></li>
									<li><a href="#" class="icon style2 fa-facebook"><span class="label">Facebook</span></a></li>
									<li><a href="#" class="icon style2 fa-instagram"><span class="label">Instagram</span></a></li>
									<li><a href="#" class="icon style2 fa-dribbble"><span class="label">Dribbble</span></a></li>
									<li><a href="#" class="icon style2 fa-github"><span class="label">GitHub</span></a></li>
									<li><a href="#" class="icon style2 fa-500px"><span class="label">500px</span></a></li>
									<li><a href="#" class="icon style2 fa-phone"><span class="label">Phone</span></a></li>
									<li><a href="#" class="icon style2 fa-envelope-o"><span class="label">Email</span></a></li>
								</ul>
							</section>
                            --%>
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
