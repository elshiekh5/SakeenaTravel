<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="AdminEmail.aspx.cs"
    Inherits="AdminEmailPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Label ID="lblResult" runat="server"></asp:Label>
                        </td>
                    </tr>
                   
                    <tr id="trAdminEmail" runat="server">
                        <td class="text">
                          <asp:Label ID="Label1" Text="<%$ Resources:AdmininstrationData,AdminEmail %>" runat="server"></asp:Label>
                        </td>
                        <td class="Control">
                            <asp:TextBox  ID="txtAdmininstration_AdminEmail" runat="server" CssClass="Controls-en"
                                ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdentifire" ControlToValidate="txtAdmininstration_AdminEmail" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator> 
                             
                        </td>
                    </tr>
            <tr id="trAdminBccEmail" runat="server">
                        <td class="text">
                          <asp:Label ID="Label2" Text="<%$ Resources:AdmininstrationData,AdminBccEmail %>" runat="server"></asp:Label>
                        </td>
                        <td class="Control">
                            <asp:TextBox  ID="txtAdmininstration_AdminBccEmail" runat="server" CssClass="Controls-en"
                                ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAdmininstration_AdminBccEmail" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator> 
                             
                        </td>
                    </tr>
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click"
                                SkinID="btnSave" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

