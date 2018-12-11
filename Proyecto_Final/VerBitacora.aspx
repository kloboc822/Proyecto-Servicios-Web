<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerBitacora.aspx.cs" Inherits="VerBitacora" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
								<a href="IndexConsultas.aspx" class="logo">
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
							<li><a href="IndexConsultas.aspx">Página principal</a></li>
                            <li><a href="Login.aspx">Log Out</a></li>
                            <li><a href="About.aspx">About Us</a></li>
						</ul>
					</nav>

				<!-- Main -->
                <asp:Panel ID="main" runat="server">
                    <asp:Panel ID="Panel1" class="inner" runat="server">
                        <h1>Registros de Bitácora</h1>
						<div class="field">
                            <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_bitacora" DataSourceID="SqlDataSource1"  >
                                <Columns>
                                    <asp:BoundField DataField="cod_bitacora" HeaderText="cod_bitacora" ReadOnly="True" SortExpression="cod_bitacora" InsertVisible="False" />
                                    <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                    <asp:BoundField DataField="id_usuario" HeaderText="id_usuario" SortExpression="id_usuario" />
                                </Columns>
                            </asp:GridView>
						    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="SELECT * FROM [BITACORA]"></asp:SqlDataSource>
						</div>
                        <br />
                        <div class="field align-center">
                                <asp:Button ID="volver" runat="server" Text="Volver" OnClick="volver_Click" />
                            </div>
                        <div class="half">
                            </div>
                            <div class="first half field">
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

