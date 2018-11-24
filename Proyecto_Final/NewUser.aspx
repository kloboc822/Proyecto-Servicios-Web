<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="NewUser" %>

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
								<h2>Easy Exams - Adding a new user</h2>
								<form method="post" action="#">
									<div class="field half first">
                                        <asp:TextBox ID="firstnameTxt" runat="server" placeholder="First Name"></asp:TextBox>
									</div>
									<div class="field half">
                                        <asp:TextBox ID="surname1Txt" runat="server" placeholder="First Surname" TextMode="SingleLine"></asp:TextBox>
									</div>
                                    <div class="field half first">
                                        <asp:TextBox ID="surname2Txt" runat="server" placeholder="Second Surname"></asp:TextBox>
									</div>
									<div class="field half">
                                        <asp:TextBox ID="idTxt" runat="server" placeholder="ID" TextMode="SingleLine"></asp:TextBox>
									</div>
                                    <div class="field half first">
                                        <asp:TextBox ID="emailTxt" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
									</div>
									<div class="field half">
                                        <asp:DropDownList ID="tipouserTxt" placeholder="Type of User" runat="server">
                                            <asp:ListItem>Admin</asp:ListItem>
                                            <asp:ListItem>User</asp:ListItem>
                                        </asp:DropDownList>
									</div>
                                    <div class="field half first">
                                        <asp:TextBox ID="passwordTxt" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
									</div>
									<ul class="actions">
                                        <asp:Button ID="createBtn" runat="server" type= "submit" class="special" Text="Create User" OnClick="createBtn_Click" />
                                        <asp:Button ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click" />
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
        </div>
    </form>
</body>
</html>
