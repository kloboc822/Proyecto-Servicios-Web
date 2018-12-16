<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editConsecutivo.aspx.cs" Inherits="Consecutivos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
            height: 79px;
        }
        .auto-style2 {
            left: 0px;
            top: 0px;
            height: 116px;
        }
        .auto-style3 {
            left: 0px;
            top: 0px;
            height: 155px;
        }
        .auto-style4 {
            left: 0px;
            top: 0px;
            height: 146px;
        }
        .auto-style5 {
            left: 0px;
            top: 0px;
            height: 113px;
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

                <!-- Main -->
                 <asp:Panel ID="main" runat="server">
           <asp:Panel ID="Panel1" class="inner" runat="server">
               <h1>Editar consecutivo</h1>

               <div class="auto-style1">
                    <h2>Descripcion:<asp:Label ID="lblDes" runat="server"></asp:Label>
                    </h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtCon" runat="server" Height="19px" Width="281px"></asp:TextBox>
     
               </div>
               <div class="auto-style2">
                         
                     <h2>Consecutivo:</h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                       
               </div>
               <div class="auto-style3">

                     <asp:CheckBox ID="chkPrefijo" runat="server" AutoPostBack="true" OnCheckedChanged="chkPrefijo_CheckedChanged" Text="UsarPrefijo" />
                     <br />
                     <h2>Prefijo:<asp:TextBox ID="txtPre" runat="server" Height="19px" Width="276px"></asp:TextBox>
                     </h2> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 </div>

               <div class="auto-style4">
                   
                 <asp:CheckBox ID="chkRango" runat="server" AutoPostBack="true" Text="UsarRango" OnCheckedChanged="chkRango_CheckedChanged" />
                 <br />
                 <h2>Rango Inicial:<asp:TextBox ID="txtRanIni" runat="server" Height="24px" Width="271px"></asp:TextBox>
                   </h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 
               </div>
               <div class="auto-style5">
                      
                <h2>Rango Final:<asp:TextBox ID="txtRanFin" runat="server" Height="17px" Width="284px"></asp:TextBox>
                   </h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
               <div class="field">

                   <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click"  class="special" />
    
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancelar"  class="special"/>

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
