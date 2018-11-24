<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TakeExam.aspx.cs" Inherits="TakeExam" %>

<form id="form1" runat="server">
<html>
	<head>
		<title>EasyExams</title>
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
									<span class="symbol"><img src="images/test.svg" alt="" /></span><span class="title">EasyExams</span>
								</a>

						</div>
					</header>

				<!-- Footer -->
					<footer id="footer">
						<div class="inner">
							<section>
                                <h1>Assignature: <asp:Label ID="assignatureLabel" runat="server"></asp:Label></h1>
								<h2>Select the exam you want to take:   </h2>
                                <asp:RadioButtonList ID="rbtTakeExam" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="nombre" OnSelectedIndexChanged="rbtTakeExam_SelectedIndexChanged">
                                    
                                    <asp:ListItem Value=""></asp:ListItem>



                                </asp:RadioButtonList>
								
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Proyecto_finalConnectionString %>" SelectCommand="SELECT [nombre] FROM [Prueba] WHERE ([topico] = @topico)">
                                    <SelectParameters>
                                        <asp:QueryStringParameter DefaultValue="" Name="topico" QueryStringField="Global.examName" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
								
                                <ul class="actions">
                                        <asp:Button ID="TakeExamBtn" runat="server" type= "submit" class="special" Text="Take Exam!" OnClick="TakeExamBtn_Click" />
									</ul>
							</section>
							<asp:Label ID="Label1Txt" runat="server" Visible="False"></asp:Label>
							<ul class="copyright">
								<li>&copy; Easy Exams Inc. 2018. All rights reserved</li>
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
    </form>