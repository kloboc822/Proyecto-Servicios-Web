<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoExam.aspx.cs" Inherits="DoExam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
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
								<a href="index.aspx" class="logo">
									<span class="symbol"><img src="images/test.svg" alt="" /></span><span class="title">EASY EXAMS</span>
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
                        <h1>Good Luck!</h1>
                        <div class="field">
						    <asp:TextBox ID="preguntaTxt" runat="server" placeholder="Error Loading Data, please contact your software administrator" TextMode="MultiLine" Enabled="False" EnableTheming="False"></asp:TextBox>
						</div>
                        <asp:RadioButtonList ID="respuestasRB" runat="server">
                            <asp:ListItem Value="1"></asp:ListItem>
                            <asp:ListItem Value="2"></asp:ListItem>
                            <asp:ListItem Value="3"></asp:ListItem>
                            <asp:ListItem Value="4"></asp:ListItem>
                        </asp:RadioButtonList>
						<%--<div class="field half first">
                               <asp:TextBox ID="" runat="server" placeholder="Exam Code"></asp:TextBox>
						</div>--%>
						<%--<div class="field half">
						    <asp:TextBox ID="nombreTxt" runat="server" placeholder="Exam Name"></asp:TextBox>
						</div>--%>
						
                           <%--<div class="field half first">
						    <asp:TextBox ID="cantpreguntasTxt" runat="server" placeholder="# of Questions"></asp:TextBox>
						</div>
						<div class="field half">
						    <asp:TextBox ID="puntajeTxt" runat="server" placeholder="Total Available Points"></asp:TextBox>
						</div>--%>
                        <%--<asp:DropDownList ID="materiaTxt" runat="server">
                            <asp:ListItem>--Please select the Subject--</asp:ListItem>
                            <asp:ListItem>Maths</asp:ListItem>
                            <asp:ListItem>Geography</asp:ListItem>
                            <asp:ListItem>Science</asp:ListItem>
                        </asp:DropDownList>--%>
                        <%--<br />--%>
                        <div>
                            <ul>
                               <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
						    </ul>
                        </div>
                    </asp:Panel>
                </asp:Panel>

				<!-- Footer -->
                <asp:Panel ID="Panel2" runat="server" class="inner" Visible="False">
                    <div class="align-center">
                        <asp:Label ID="numPregTxt" runat="server" class="title" Text="Question #"></asp:Label>
                        <br />
                    </div>
                    <table class="auto-style1">
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="descripcionPregTxt" runat="server" placeholder="Your Question Here"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="puntajePregTxt" runat="server" placeholder="Value"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="resp1Txt" runat="server" placeholder="Answer #1"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="resp2Txt" runat="server" placeholder="Answer #2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="resp3Txt" runat="server" placeholder="Answer #3"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="resp4Txt" runat="server" placeholder="Answer #4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="align-center" colspan="2">Select the correct answer</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RadioButtonList ID="respCorrectaTxt" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Answer #1</asp:ListItem>
                                    <asp:ListItem>Answer #2</asp:ListItem>
                                    <asp:ListItem>Answer #3</asp:ListItem>
                                    <asp:ListItem>Answer #4</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
					<div class="align-center">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:Button ID="addBtn" runat="server" class="special" Text="Add" Height="71px" OnClick="addBtn_Click" />
                        <asp:Button ID="finishBtn" runat="server" Text="Finish" Visible="False" OnClick="finishBtn_Click" />--%>
					</div>
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
        </div>
    </form>
</body>
</html>

