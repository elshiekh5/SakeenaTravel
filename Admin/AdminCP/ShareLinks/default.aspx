<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs"
    Inherits="AdminSiteSettings_OtherLinks" %>

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
                   
                    <tr id="Tr1" runat="server" visible="true">
                        <td class="text">
                           Facebook
                        </td>
                        <td class="Control">
                             <asp:TextBox  ID="txtOtherLinks_Facebook" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator25" runat="server" ErrorMessage="*"
                                ControlToValidate="txtOtherLinks_Facebook" ValidationGroup="SiteSettings" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" visible="true">
                        <td class="text">Twitter
                        </td>
                        <td class="Control">
                            <asp:TextBox  ID="txtOtherLinks_Twitter" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvValue" runat="server" ErrorMessage="*"
                                ControlToValidate="txtOtherLinks_Twitter" ValidationGroup="SiteSettings" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server"  visible="true">
                        <td class="text" >YouTube
                        </td>
                        <td class="Control">
                            <asp:TextBox  ID="txtOtherLinks_YouTube" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage="*" ControlToValidate="txtOtherLinks_YouTube" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="TrLinkedIn"  runat="server" visible="false">
                        <td class="text">
                           LinkedIn
                        </td>
                        <td class="Control">
                             <asp:TextBox  ID="txtOtherLinks_LinkedIn" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtOtherLinks_LinkedIn" ValidationGroup="SiteSettings" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="TrGooglePlus" runat="server" visible="true" >
                        <td class="text">
                           Google Plus
                        </td>
                        <td class="Control">
                             <asp:TextBox  ID="txtOtherLinks_GooglePlus" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtOtherLinks_GooglePlus" ValidationGroup="SiteSettings" Text="*"></asp:RequiredFieldValidator>
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

