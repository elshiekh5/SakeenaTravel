<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SmsSettings.aspx.cs"
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
                            ≈⁄œ«œ«  ÃÊ«· «·„Êﬁ⁄
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="text">
                             ›⁄Ì· «·„Ã„Ê⁄« <span class="RequiredField"><asp:Label ID="Label33" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSms_HasGroups" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ⁄—÷ √—‘Ì› «·—”«∆·<span class="RequiredField"><asp:Label ID="Label34" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSms_HasArchive" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                           «·≈” Ì—«œ „‰ „·›  ﬂ” <span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSms_HasImportFromTxtFile" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                           «·≈” Ì—«œ „‰ „·› ≈ﬂ”·<span class="RequiredField"><asp:Label ID="Label3" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSms_HasImportFromExcellFile" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td class="text">
                          «· ’œÌ— ·„·› ≈ﬂ”·<span class="RequiredField"><asp:Label ID="Label14" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbSms_HasExportToExcellFile" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Provider Url <span class="RequiredField">
                                <asp:Label ID="Label39" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSms_URL" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator12" runat="server"
                                ErrorMessage="*" ControlToValidate="txtSms_URL" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            «”„ «·„” Œœ„ <span class="RequiredField">
                                <asp:Label ID="Label40" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSms_AccountUserName" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSms_AccountUserName" Display="Dynamic"
                                ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ﬂ·„… «·„—Ê—<span class="RequiredField"><asp:Label ID="Label50" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSms_AccountPassword" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSms_AccountPassword" Display="Dynamic"
                                ID="RequiredFieldValidator24" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Web Service Key
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSms_SMSKey" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSms_SMSKey" Display="Dynamic"
                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td class="text">
                            √—ﬁ«„ «·≈ ’«·<span class="RequiredField"><asp:Label ID="Label51" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSms_Numbers" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSms_Numbers" Display="Dynamic"
                                ID="RequiredFieldValidator25" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                            ***»≈„ﬂ«‰ﬂ Ê÷⁄ «ﬂÀ— „‰ —ﬁ„ ≈ ’«· Ì›’· »Ì‰Â„ «·⁄·«„… ","
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            —ﬁ„ «·ÃÊ«· «·„ ’· <span class="RequiredField">
                                <asp:Label ID="Label52" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSms_Sender" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSms_Sender" Display="Dynamic" ID="RequiredFieldValidator26"
                                runat="server" ErrorMessage="*" ValidationGroup="SiteSettings" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ‰’ «·—”«·… <span class="RequiredField">
                                <asp:Label ID="Label53" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtSms_Message" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSms_Message" Display="Dynamic"
                                ID="RequiredFieldValidator27" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
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
