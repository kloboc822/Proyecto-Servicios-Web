<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CrearVuelo.aspx.cs" Inherits="CrearVuelo" %>

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
							<li><a href="IndexAdmin.aspx">Página principal</a></li>
                            <li><a href="Login.aspx">Log Out</a></li>
                            <li><a href="About.aspx">About Us</a></li>
						</ul>
					</nav>

 <!-- Main -->
 <asp:Panel ID="main" runat="server">
           <asp:Panel ID="Panel1" class="inner" runat="server">
        
        
       <h1> <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></h1>
        
    <div class ="field">
        <h2>Codigo:<asp:DropDownList ID="dplCod" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo">
            </asp:DropDownList>
        </h2>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="select codigo from consecutivo where descripcion = 'Vuelos'"></asp:SqlDataSource>
    
    </div>
       <div class ="field">
            <h2>Aerolinea:<asp:DropDownList ID="dplAero" runat="server" DataSourceID="SqlDataSource2" DataTextField="cod_aerol" DataValueField="cod_aerol">
                </asp:DropDownList>
            </h2>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="SELECT [cod_aerol] FROM [AEROLINEA]"></asp:SqlDataSource>
       </div>
               <div class ="field">
            <h2><asp:Label ID="lblTipo" runat="server" Text="Label"></asp:Label>
            :</h2><asp:DropDownList ID="dplluga" runat="server" DataSourceID="SqlDataSource4" DataTextField="nombre" DataValueField="nombre">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="SELECT [nombre] FROM [PAIS]"></asp:SqlDataSource>
                   
       </div>
<div class ="field">
            <h2>Fecha:<asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
            </h2>
        </div>
<div class ="field half first"> 

            <h2>Hora:</h2><asp:DropDownList ID="dplHoras" runat="server" > 
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem Value="02"></asp:ListItem>
                <asp:ListItem Value="03"></asp:ListItem>
                <asp:ListItem Value="04"></asp:ListItem>
                <asp:ListItem Value="05"></asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem Value="07"></asp:ListItem>
                <asp:ListItem Value="08"></asp:ListItem>
                <asp:ListItem Value="09"></asp:ListItem>
                <asp:ListItem Value="10"></asp:ListItem>
                <asp:ListItem Value="11"></asp:ListItem>
                <asp:ListItem Value="12"></asp:ListItem>
                <asp:ListItem Value="13"></asp:ListItem>
                <asp:ListItem Value="14"></asp:ListItem>
                <asp:ListItem Value="15"></asp:ListItem>
                <asp:ListItem Value="16"></asp:ListItem>
                <asp:ListItem Value="17"></asp:ListItem>
                <asp:ListItem Value="18"></asp:ListItem>
                <asp:ListItem Value="19"></asp:ListItem>
                <asp:ListItem Value="20"></asp:ListItem>
                <asp:ListItem Value="21"></asp:ListItem>
                <asp:ListItem Value="22"></asp:ListItem>
                <asp:ListItem Value="23"></asp:ListItem>
                <asp:ListItem Value="24"></asp:ListItem>
                </asp:DropDownList>
             </div>

              <div class="field half">
                  <asp:DropDownList ID="dplMin" runat="server" >
                 <asp:ListItem Value="00"></asp:ListItem>
                 <asp:ListItem Value="05"></asp:ListItem>
                 <asp:ListItem Value="10"></asp:ListItem>
                 <asp:ListItem Value="15"></asp:ListItem>
                 <asp:ListItem Value="20"></asp:ListItem>
                 <asp:ListItem Value="25"></asp:ListItem>
                 <asp:ListItem Value="30"></asp:ListItem>
                 <asp:ListItem Value="35"></asp:ListItem>
                 <asp:ListItem Value="40"></asp:ListItem>
                 <asp:ListItem Value="45"></asp:ListItem>
                 <asp:ListItem Value="50"></asp:ListItem>
                 <asp:ListItem Value="50"></asp:ListItem>
            </asp:DropDownList>
            </div>
<div class ="field">
           <h2>Estado:<asp:DropDownList ID="dpdEstado" runat="server">
               </asp:DropDownList>
           </h2> 
        </div>
<div class ="field">
           <h2>Puerta:<asp:DropDownList ID="dpdPuerta" runat="server" DataSourceID="SqlDataSource3" DataTextField="cod_puerta" DataValueField="cod_puerta">
               </asp:DropDownList>
           </h2> 
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="SELECT [cod_puerta] FROM [PUERTA]"></asp:SqlDataSource>
         </div>
<div class ="field">
           <h2>Precio:<asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
           </h2> 
        </div>

<div class ="field">
        <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" Text="Insertar" class="special"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancelar" class="special" />
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
</body>
</html>
