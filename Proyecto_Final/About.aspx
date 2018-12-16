<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

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
		<title>V-Vuelos Bienvenido!</title>
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
							<li><a href="IndexUser.aspx">Página principal</a></li>
                            <li><a href="Login.aspx">Log Out</a></li>
                            <li><a href="About.aspx">About Us</a></li>
						</ul>
					</nav>

				<!-- Main -->
					<div id="main">
						<div class="inner">
							<header>
								<h1>Desarrolladores</h1>
								<p>Diseñada y desarrollada por los desarrolladores:</p>
							</header>
							
                            <!--EXAMENES -->
                            <section class="tiles">
                              	<article class="style1">
									<span class="image">                                        
										<img src="images/Solano.jpg" alt="" />
									</span>
									<a> 
										<h2>Jorge Solano</h2>
										<div class="content">
											 <asp:Button ID="contactoBtn" runat="server" class = "special" Text="Ver" OnClick="contactoBtn_Click"/>
										</div>
                                       
									</a>
								</article>
                                <article class="style1">
									<span class="image">                                        
										<img src="images/Ugalde.jpg" alt="" />
									</span>
									<a> 
										<h2>Jorge Ugalde</h2>
										<div class="content">
											 <asp:Button ID="contacto2Btn" runat="server" class = "special" Text="Ver" OnClick="contacto2Btn_Click"/>
										</div>
                                       
									</a>
								</article>
								<article class="style2">
									<span class="image">
										<img src="images/Kevin.jpg" alt="" />
									</span>
									<a>
										<h2>Kevin Lobo</h2>
										<div class="content">
											<asp:Button ID="contacto3Btn" runat="server" class = "special" Text="Ver" OnClick="contacto3Btn_Click"/>
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
