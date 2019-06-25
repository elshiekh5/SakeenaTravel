<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SiteSettings.aspx.cs"
    Inherits="AdminSiteSettings_Comments" %>

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
                            »Ì«‰«  «·„Êﬁ⁄
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            SiteTitle<span class="RequiredField"><asp:Label ID="Label22" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSite_SiteTitle" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSite_SiteTitle" Display="Dynamic"
                                ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Comment<span class="RequiredField"><asp:Label ID="Label30" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSite_Comment" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSite_Comment" Display="Dynamic"
                                ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Site Cookie Name<span class="RequiredField"><asp:Label ID="Label9" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSite_CookieName" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSite_SiteTitle" Display="Dynamic"
                                ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Website domain<span class="RequiredField">*</span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSite_WebsiteDomain" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSite_WebsiteDomain" Display="Dynamic"
                                ID="RequiredFieldValidator210" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                           Website Design<span class="RequiredField"><asp:Label ID="Label1" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSite_WebsiteDesignFolder" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                             Admin Url<span class="RequiredField">*</span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSite_AdminUrl" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                   
                    <tr>
                        <td class="text">
                            AdminPageSize<span class="RequiredField"><asp:Label ID="Label28" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSite_AdminPageSize" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            HasMultiLanguageDesign<span class="RequiredField"><asp:Label ID="Label2" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSite_HasMultiLanguageDesign" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            HasAdminMainImages<span class="RequiredField"><asp:Label ID="Label3" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSite_HasAdminMainImages" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            AllowDublicateTitles<span class="RequiredField"><asp:Label ID="Label29" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSite_AllowDublicateTitles" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            IpCountryService<span class="RequiredField"><asp:Label ID="Label5" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSite_IpCountryService" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            IpWebServicePassword<span class="RequiredField"><asp:Label ID="Label4" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSite_IpWebServicePassword" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
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
