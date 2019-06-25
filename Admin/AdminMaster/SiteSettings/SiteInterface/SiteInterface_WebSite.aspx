<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SiteInterface_WebSite.aspx.cs"
    Inherits="SiteInterface_WebSite" %>

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
                            ≈⁄œ«œ«  ⁄«„…
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            HasWebsiteBaseControls
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSiteInterface_HasWebsiteBaseControls" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings" />
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHeader" colspan="2">
                            ≈⁄œ«œ«  «·œ«Œ·Ì« 
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Inner Width
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSiteInterface_InnerWebsiteWidth" runat="server" CssClass="SmallControls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHeader" colspan="2">
                            ≈⁄œ«œ«  «·’Ê—
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Vertical List
                        </td>
                        <td class="Control">
                            <table>
                                <tr>
                                    <td class="">
                                        Width
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_VListWidth" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                    <td class="">
                                        Height
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_VListHeight" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Horizontal List
                        </td>
                        <td class="Control">
                            <table>
                                <tr>
                                    <td class="">
                                        Width
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_HListWidth" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                    <td class="">
                                        Height
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_HListHeight" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Details Page
                        </td>
                        <td class="Control">
                            <table>
                                <tr>
                                    <td class="">
                                        Width
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_DetailsPageWidth" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                    <td class="">
                                        Height
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_DetailsPageHeight" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHeader" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Micro Thumnail
                        </td>
                        <td class="Control">
                            <table>
                                <tr>
                                    <td class="">
                                        Width
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_MicroThumnailWidth" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                    <td class="">
                                        Height
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_MicroThumnailHeight" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Mini Thumnail
                        </td>
                        <td class="Control">
                            <table>
                                <tr>
                                    <td class="">
                                        Width
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_MiniThumnailWidth" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                    <td class="">
                                        Height
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_MiniThumnailHeight" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Normal Thumnail
                        </td>
                        <td class="Control">
                            <table>
                                <tr>
                                    <td class="">
                                        Width
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_NormalThumnailWidth" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                    <td class="">
                                        Height
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_NormalThumnailHeight" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Big Thumnail
                        </td>
                        <td class="Control">
                            <table>
                                <tr>
                                    <td class="">
                                        Width
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_BigThumnailWidth" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                    <td class="">
                                        Height
                                    </td>
                                    <td class="">
                                        <asp:TextBox ID="txtPhotos_WebSite_BigThumnailHeight" runat="server" CssClass="SmallControls"
                                            ValidationGroup="SiteSettings"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHeader" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            «·Õ›«Ÿ ⁄·Ï «·√»⁄«œ
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbPhotos_SavePhotoDimensions" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Availble Extensions
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtPhotos_PhotosAvailbleExtensions" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHeader" colspan="2">
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
