<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMisClases.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hfIDClase" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Modalidad"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlModalidad" runat="server">
                        <asp:ListItem Value="Presencial"></asp:ListItem>
                        <asp:ListItem>A Distancia</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Fecha"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFecha" runat="server" TextMode="DateTime"></asp:TextBox>
                </td>
            </tr>
         
             <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Horas"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtHora" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Cantidad"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Alumno"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAlumno" runat="server">
                    </asp:DropDownList>
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
        <asp:GridView ID="gvClases" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
              

                <asp:BoundField DataField="modalidad" HeaderText="modalidad" />
                <asp:BoundField DataField="fecha" HeaderText="fecha" />
                <asp:BoundField DataField="horas" HeaderText="horas" />
              

                <asp:BoundField DataField="cantidad" HeaderText="cantidad" />
                <asp:BoundField DataField="alumno" HeaderText="alumno" />
              

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