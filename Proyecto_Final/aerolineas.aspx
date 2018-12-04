<%@ Page Language="C#" AutoEventWireup="true" CodeFile="aerolineas.aspx.cs" Inherits="aerolineas" %>

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
									<span class="symbol"><img src="images/test.svg" alt="" /></span><span class="title">V-Vuelos</span>
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
							<li><a href="index.html">Home</a></li>
							<li><a href="generic.html">Ipsum veroeros</a></li>
							<li><a href="generic.html">Tempus etiam</a></li>
							<li><a href="generic.html">Consequat dolor</a></li>
							<li><a href="elements.html">Elements</a></li>
						</ul>
					</nav>
            <!-- Main -->
                <asp:Panel ID="main" runat="server">
                    <asp:Panel ID="Panel1" class="inner" runat="server">
                        <h1>Aerolínea</h1>
                        <div class="field">
                            <h2>Codigo:</h2>&nbsp;&nbsp; 
                            <asp:DropDownList ID="dplCodi" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="select codigo from codigos where descripcion = 'Aerolinea'"></asp:SqlDataSource>
                            <br />
                        </div>
                        <div class="field first half">
                            <h2>Nombre:</h2>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <h2>Imagen:</h2>&nbsp;&nbsp;
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <br />
                                <br />
                        
                        
                        &nbsp;<asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Add New" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                            </div>
                            &nbsp;
                        <div class="field align-center">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="392px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Codigo Aerolinea">
                                        <ItemTemplate>
                                            <asp:Label ID="stlbl" runat="server" Text='<%# Eval("cod_aerol") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:BoundField DataField="cod_aerol" HeaderText="Codigo Aerolinea"/>--%>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                    <asp:TemplateField HeaderText="Image">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("imagen")) %>' Width="100px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="b1" runat="server" CommandName="Delete" Text="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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

    </form>
</body>
</html>
