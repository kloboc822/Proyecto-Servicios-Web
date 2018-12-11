<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UltimoCaptcha.aspx.cs" Inherits="UltimoCaptcha" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>  

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>

        <div class="g-recaptcha" data-sitekey="6LfnN4AUAAAAAObMA2Er2Mgb7EdqdgtTiSOoBK1W"></div>
        <asp:Button ID="btntest" runat="server" OnClick="btntest_Click" Text="btnTets" />
        <asp:Label ID="lbltest" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
