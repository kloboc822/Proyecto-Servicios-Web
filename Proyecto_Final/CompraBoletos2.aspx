<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompraBoletos2.aspx.cs" Inherits="CompraBoletos2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
	<head>
		<title>V-Vuelos</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<link rel="stylesheet" href="assets/css/main.css" />
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
						</div>
					</header>
                    <nav id="menu">
						<h2>Menu</h2>
						<ul>
							<li><a href="IndexUser.aspx">Página principal</a></li>
                            <li><a href="Login.aspx">Log Out</a></li>
                            <li><a href="About.aspx">About Us</a></li>
						</ul>
					</nav>
                </div>
				<!-- Footer -->
					<footer id="footer">
						<div class="inner">
							<section>
								<h2>V-Vuelos - Vuelos Disponibles en la Fecha Seleccionada</h2>
									<div class="field half first">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_vuelo" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True">
                                            <Columns>
                                                <asp:BoundField DataField="cod_vuelo" HeaderText="cod_vuelo" ReadOnly="True" SortExpression="cod_vuelo" />
                                                <asp:BoundField DataField="aerolinea" HeaderText="aerolinea" SortExpression="aerolinea" />
                                                <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                                                <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                                                <asp:BoundField DataField="puerta" HeaderText="puerta" SortExpression="puerta" />
                                            </Columns>
                                        </asp:GridView>
									    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="SELECT [cod_vuelo], [aerolinea], [fecha], [precio], [puerta] FROM [VUELO] WHERE (([fecha] = @fecha) AND ([lugar] = @lugar))">
                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="fecha" QueryStringField="Global.fechaSalida" Type="String" />
                                                <asp:QueryStringParameter Name="lugar" QueryStringField="Global.lugar" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
									</div>
                                <div class="field">
                                    <asp:Label ID="Label1" runat="server" Text="Seleccione Metodo de Pago"></asp:Label>
                                    <asp:DropDownList ID="metodoPagoTxt" runat="server">
                                        <asp:ListItem>Seleccione</asp:ListItem>
                                        <asp:ListItem>Tarjeta</asp:ListItem>
                                        <asp:ListItem>EasyPay</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
									<div class="field half first">
                                        <asp:Button ID="comprarBtn" runat="server" Text="Realizar Compra" OnClick="comprarBtn_Click" />
									</div>
                                    <div class="field half">
                                        <asp:Button ID="volverBtn" runat="server" Text="Volver" OnClick="volverBtn_Click" />
									</div>
							</section>
							<ul class="copyright">
								<li>&copy; V-Vuelos Inc. 2018. All rights reserved</li>
							</ul>
						</div>
					</footer>

		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/skel.min.js"></script>
			<script src="assets/js/util.js"></script>
			<script src="assets/js/main.js"></script>
	</body>
    </form>
</body>
</html>
