<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showCon.aspx.cs" Inherits="showCon" %>

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
							<li><a href="Index.aspx">Página principal</a></li>
                            <li><a href="Login.aspx">Log Out</a></li>
                            <li><a href="About.aspx">About Us</a></li>
						</ul>
					</nav>

 <!-- Main -->
 <asp:Panel ID="main" runat="server">
           <asp:Panel ID="Panel1" class="inner" runat="server">

    <div  class="field">
    
        <h2>Consecutivos</h2>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="140px" Width="401px" OnRowCommand="GridView1_RowCommand">
            <Columns>
                
                <asp:BoundField DataField="cod_consecutivo" HeaderText="Codigo" />
                
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="codigo" HeaderText="Consecutivo" />
                <asp:ButtonField CommandName="seditar" Text="Editar" />

            </Columns>
        </asp:GridView>
    
    </div>
        <div class="field">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Crear Consecutivo" class="special"/>
        </div>
               <div class="field">
           <h2>Codigos Asignados</h2> 
       
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                </Columns>
            </asp:GridView>
       
            &nbsp;
                   </div>
                          </asp:Panel>
              </asp:Panel>  
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
