<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Roles.aspx.cs"
    Inherits="AdminSitesUsers_Create"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td align="center" class="text" colspan="2">
               <%= Resources.MemberShip.SiteRoles%>
            </td>
        </tr>
        <tr>
            <td>
                <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                     <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Label ID="lblResult" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                          <td class="text"><%= Resources.MemberShip.NewRole%></td>
                        <td class="Control">
                            <asp:TextBox CssClass="Controls" ID="txtNewRole" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNewRoleRequired" runat="server" ControlToValidate="txtNewRole"
                                 ValidationGroup="txtNewRole_Create">*</asp:RequiredFieldValidator>
                            <asp:Button ID="btnCreate" runat="server" Width="100px" Text="<%$ Resources:MemberShip,AddNewRole %>"
                                CssClass="Button"  ValidationGroup="txtNewRole_Create" 
                                onclick="btnCreate_Click">
                            </asp:Button>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="GridControl" align="center" colspan="2">
                            <asp:DataGrid ID="dgRoles" runat="server" SkinID="GridViewSkin" 
                                >
                                <Columns>
                                   
                                    <asp:BoundColumn ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleTitle" DataField="RoleName"
                                        HeaderText="<%$ Resources:MemberShip,RoleName %>"></asp:BoundColumn>
                                  
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td class="PagerControl" align="center" colspan="2">
                        
                         
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


