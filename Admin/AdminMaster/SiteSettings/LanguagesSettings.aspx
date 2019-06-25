<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="LanguagesSettings.aspx.cs"
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
                            ≈⁄œ«œ«  «··€…
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            DefaultLanguageID<span class="RequiredField"><asp:Label ID="Label31" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:DropDownList ID="ddlDefaultLanguageID" runat="server">
                                <%--<asp:ListItem Text="≈Œ —" Value="-1"></asp:ListItem>--%>
                                <asp:ListItem Text="⁄—»Ì" Value="1"></asp:ListItem>
                                <asp:ListItem Text="English" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ·€«  «·„Êﬁ⁄
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbLanguages_HasArabicLanguages" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" Text="⁄—»Ì" />
                            <asp:CheckBox ID="cbLanguages_HasEnglishLanguages" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" Text="English" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ·€… ·ÊÕ… «· Õﬂ„<span class="RequiredField"><asp:Label ID="Label1" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:DropDownList ID="ddlAdminLanguageID" runat="server">
                                <asp:ListItem Text="Dynamic" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="⁄—»Ì" Value="1"></asp:ListItem>
                                <asp:ListItem Text="English" Value="2"></asp:ListItem>
                            </asp:DropDownList>
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
