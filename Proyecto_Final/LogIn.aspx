<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<!DOCTYPE html>

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
								<h2>Welcome to Easy Exams - Please Log In</h2>
								<form method="post" action="#">
									<div class="field half first">
                                        <asp:TextBox ID="usernameTxt" runat="server" placeholder="Username"></asp:TextBox>
									</div>
									<div class="field half">
                                        <asp:TextBox ID="passwordTxt" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
									</div>
									<ul class="actions">
                                        <asp:Button ID="loginBtn" runat="server" type= "submit" class="special" Text="Log In" OnClick="loginBtn_Click" />
									</ul>
								</form>
							</section>
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
