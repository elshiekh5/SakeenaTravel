<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Add-Admin.aspx.cs"
    Inherits="MasterAdmin_Add_Admin" %>
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
                    <tr>
                        <td class="SubHeader" colspan="2">
                            ≈÷«›… √œ„‰
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ≈”„ «·„” Œœ„
                        </td>
                        <td class="Control">
                            <asp:TextBox MaxLength="10" ID="txtUserName" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ﬂ·„… «·„—Ê—
                        </td>
                        <td class="Control">
                            <asp:TextBox MaxLength="10" ID="txtPassword" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            «·»—Ìœ «·≈·ﬂ —Ê‰Ì
                        </td>
                        <td class="Control">
                            <asp:TextBox MaxLength="10" ID="txtEmail" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="vertical-align:top; padding-top:8px;">
                            Site Roles
                        </td>
                        <td class="Control">
                            <asp:CheckBoxList ID="cblRoels" runat="server">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="SiteSettings" OnClick="btnSave_Click"
                                SkinID="btnSave" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
