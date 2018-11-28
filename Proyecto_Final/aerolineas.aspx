<%@ Page Language="C#" AutoEventWireup="true" CodeFile="aerolineas.aspx.cs" Inherits="aerolineas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Aerolinea
        <br />
        <br />
        Codigo:&nbsp;&nbsp; 
        <asp:DropDownList ID="dplCodi" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VuelosConnectionString2 %>" SelectCommand="select codigo from codigos where descripcion = 'Aerolinea'"></asp:SqlDataSource>
        <br />
        Nombre:
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <br />
        Imagen:&nbsp;&nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
    
    </div>
&nbsp;<asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" style="height: 26px" Text="Add New" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" Width="392px">
            <Columns>
                 <asp:TemplateField  HeaderText="Codigo Aerolinea">
                    <ItemTemplate>
                      <asp:Label ID="stlbl" runat="server" Text='<%# Eval("cod_aerol") %>' />

                    </ItemTemplate>
                    
                </asp:TemplateField>
               <%-- <asp:BoundField DataField="cod_aerol" HeaderText="Codigo Aerolinea"/>--%>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" 
                            ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("imagen")) %>' />
                        
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="b1" runat="server" CommandName="Delete" Text="Delete"/>  

                    </ItemTemplate>
                    
                </asp:TemplateField>

                
            </Columns>
        </asp:GridView >
    </form>
</body>
</html>
