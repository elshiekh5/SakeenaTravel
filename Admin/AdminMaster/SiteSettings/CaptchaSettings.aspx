<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="CaptchaSettings.aspx.cs"
    Inherits="AdminSiteSettings_Captcha" %>

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
                            ≈⁄œ«œ«  «·ﬂ«» ‘«
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            „ÊœÌÊ·«  «·—”«∆·
                        </td>
                        <td class="Control">
                         <asp:CheckBox ID="cbCaptcha_AllowInMessagesModules" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                           ≈—”«· «· ⁄·Ìﬁ« 
                        </td>
                        <td class="Control">
                         <asp:CheckBox ID="cbCaptcha_AllowInSendComment" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                           √Œ»— ’œÌﬁ
                        </td>
                        <td class="Control">
                         <asp:CheckBox ID="cbCaptcha_AllowInTellAFfiend" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
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
