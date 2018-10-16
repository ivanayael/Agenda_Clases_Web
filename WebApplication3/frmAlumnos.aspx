<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAlumnos.aspx.cs" Inherits="WebApplication3.frmClases" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hfIDAlumno" runat="server" />
        <table>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Telefono"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblSuccess" runat="server" ForeColor="#66FF33"></asp:Label>
                </td>
                <td>
                  <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                   
                   <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                   <asp:Button ID="btnBorrar" runat="server" Text="Borrar" OnClick="btnBorrar_Click" />
                   <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                   
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvAlumnos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
              

                <asp:BoundField DataField="nombre" HeaderText="nombre" />
                <asp:BoundField DataField="telefono" HeaderText="telefono" />
                <asp:BoundField DataField="email" HeaderText="email" />
              

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="inkView" runat ="server" commandargument='<%# Eval("id")%>' OnClick="lnk_OnClick">Ver</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
              

            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        
    </div>
    </form>
</body>
</html>
