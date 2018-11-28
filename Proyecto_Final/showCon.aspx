<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showCon.aspx.cs" Inherits="showCon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Consecutivos<br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="140px" Width="401px" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <%--<asp:BoundField DataField="prefijo" HeaderText="Prefijo" />--%>
                <asp:TemplateField  HeaderText="Prefijo">
                    <ItemTemplate>
                      <asp:Label ID="stlbl" runat="server" Text='<%# Eval("prefijo") %>' />

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="rango_inic" HeaderText="Rango Inicial" />
                <asp:BoundField DataField="rango_fin" HeaderText="Rango Final" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="b1" runat="server" CommandName="Delete" Text="Delete"/>  
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Crear Consecutivo" />
        </p>
        <p>
            Codigos Creados</p>
        <p>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                </Columns>
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
