<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consecutivos.aspx.cs" Inherits="Consecutivos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Informacion del consecutivo
        <br />
        <br />
        Descripcion:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dplDesc" runat="server">
            <asp:ListItem Value="Aerolinea">Aerolinea</asp:ListItem>
            <asp:ListItem Value="Paises">Paises</asp:ListItem>
            <asp:ListItem Value="Puertas del Aeropuerto">Puertas del Aeropuerto</asp:ListItem>
            <asp:ListItem Value="Compra de Boletos">Compra de Boletos</asp:ListItem>
            <asp:ListItem Value="Reservacion de Boletos">Reservacion de Boletos</asp:ListItem>
            <asp:ListItem Value="Vuelos">Vuelos</asp:ListItem>
        </asp:DropDownList>
        <br />
        Consecutivo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtCon" runat="server"></asp:TextBox>
        <br />
        Prefijo Existente:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEna" runat="server" Height="22px" OnClick="btnEna_Click" Text="Si" Width="42px" />
&nbsp;<asp:DropDownList ID="dplPre" runat="server" DataSourceID="SqlDataSource1" DataTextField="prefijo" DataValueField="prefijo" Enabled="False">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="SELECT [prefijo] FROM [CONSECUTIVO]"></asp:SqlDataSource>
        <br />
        Prefijo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPre" runat="server"></asp:TextBox>
        <br />
        Rango Inicial:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRanIni" runat="server"></asp:TextBox>
        <br />
        Rango Final:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRanFin" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" Width="80px" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVerDa" runat="server" Enabled="False" OnClick="btnVerDa_Click" Text="VerDatos" />
    
    &nbsp;
        <asp:Button ID="btnVer" runat="server" OnClick="btnVer_Click" Text="Ver Consecutivos" />
    
    </div>
    </form>
</body>
</html>
