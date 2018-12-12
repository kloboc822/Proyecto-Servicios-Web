
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgregarPais.aspx.cs" Inherits="AgregarPais" %>

<!DOCTYPE html>

<form id="form1" runat="server">
<html>
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
								<a href="index.aspx" class="logo">
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
							<li><a href="IndexAdmin.aspx">Página principal</a></li>
                            <li><a href="Login.aspx">Log Out</a></li>
                            <li><a href="About.aspx">About Us</a></li>
						</ul>
					</nav>

				<!-- Footer -->
					<footer id="footer">
						<div class="inner">
							<section>
                                <h1>Agregar País: </h1>
								<h2>Seleccione el código del país que desea agregar:   </h2>
                                <div class="field half first">
                                <asp:DropDownList ID="Cod_pais" placeholder="Seleccionar" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" AutoPostBack="True">
                                    <asp:ListItem>Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="SELECT codigo FROM consecutivo WHERE descripcion = 'Paises'">
                                    </asp:SqlDataSource>
                                </div>
				                <div class="field">
                                        <asp:TextBox ID="Nombretxt" runat="server" placeholder="Nombre del país"></asp:TextBox>                                  
								</div>
                                <div class="field half first">
                                    Archivo:
                                    <br />
                                    <%--<asp:Button ID="SelecBtn" runat="server" type= "submit" class="special" Text="Seleccionar" />--%>
                                        <asp:FileUpload ID="SelectImag" accept=".jpg"  runat="server" />
              
                                        
                                        
								</div>
                                <%--<div class="field half first">
                                    <asp:TextBox ID="Imagen" runat="server" placeholder="Título de la imagen:"></asp:TextBox>
								</div>--%>
                    
                                <div class="field">
                                    Imagen agregada:
                                    <br />
                                    <asp:Image ID="ImagenPais" runat="server" Height="170px" ImageUrl="~/images/search-engine-optimisation-settings-17.png" Width="170px" />
                                </div>
                                <div class="first half field">
                                       <asp:Button ID="SubirBtn" runat="server" type= "submit" class="special" Text="Subir Imagen" OnClick="SubirBtn_Click" />                                 
								</div>
                                <div class="first half field">
                                    <asp:Button ID="cancelarBtn" runat="server" Text="Cancelar" OnClick="cancelarBtn_Click" />
                                </div>
                                <ul class="actions">
                                    
                                        <asp:Button ID="AgregarBtn" runat="server" type= "submit" class="special" Text="Agregar País" OnClick="AgregarBtn_Click" Visible="False" />
									</ul>
							</section>
							<asp:Label ID="Label1Txt" runat="server" Visible="False"></asp:Label>
							<ul class="copyright">
								<li>&copy; V-Vuelos Inc. 2018. All rights reserved</li>
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
</html>
    </form>
