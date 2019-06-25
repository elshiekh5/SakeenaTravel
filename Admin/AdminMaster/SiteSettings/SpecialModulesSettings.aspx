<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SpecialModulesSettings.aspx.cs"
    Inherits="AdminSiteSettings_SpecialModulesSettings" %>

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
                            ≈⁄œ«œ«  «·„ÊœÌÊ·«  «·Œ«’…
                        </td>
                    </tr>
                     <tr>
                        <td class="text">
                             ›⁄Ì· «·ﬁ«∆„… «·»—ÌœÌ…
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbMailList_HasMaillist" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                             ›⁄Ì· Œœ„… ÃÊ«· «·„Êﬁ⁄
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSms_HasSms" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                             ›⁄Ì· «· ’ÊÌ 
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbVote_Enabled" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                             ›⁄Ì· «·≈⁄·«‰« 
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSpecialModules_AdvertismentsEnabled" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                             ›⁄Ì· „ÊœÌÊ· «·„œ‰
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSpecialModules_CitisEnabled" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                             ›⁄Ì· „ÊœÌÊ· —Ê«»ÿ «·„‘«—ﬂ…
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSpecialModules_ShareLinksEnabled" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                             ›⁄Ì· „ÊœÌÊ· √„‰ «·‰Ÿ«„
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSpecialModules_SecurityEnabled" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                             ›⁄Ì· „ÊœÌÊ· ⁄œ«œ «·“Ê—«—
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSpecialModules_VisitorsCountEnabled" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                             ›⁄Ì· „ÊœÌÊ· «·≈Õ’«∆Ì« 
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSpecialModules_StatisticsEnabled" Text=" ›⁄Ì· „ÊœÌÊ· «·≈Õ’«∆Ì« " CssClass="Controls" ValidationGroup="SiteSettings" runat="server" />
                            <asp:CheckBox ID="cbSpecialModules_GoogleStatisticsEnabled" Text=" ›⁄Ì· ≈Õ’«∆Ì«  ÃÊÃ·" CssClass="Controls" ValidationGroup="SiteSettings" runat="server" />
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
