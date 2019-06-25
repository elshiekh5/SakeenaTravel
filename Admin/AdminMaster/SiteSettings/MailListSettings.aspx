<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="MailListSettings.aspx.cs"
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
                            ≈⁄œ«œ«  «·ﬁ«∆„… «·»—ÌœÌ…
                        </td>
                    </tr>
                    
                     <tr>
                        <td class="text">
                            Has Groups<span class="RequiredField"><asp:Label ID="Label15" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbMailList_HasGroups" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Has Archive<span class="RequiredField"><asp:Label ID="Label0015" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbMailList_HasArchive" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <td class="text">
                           «·≈” Ì—«œ „‰ „·›  ﬂ” <span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbMailList_HasImportFromTxtFile" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                           «·≈” Ì—«œ „‰ „·› ≈ﬂ”·<span class="RequiredField"><asp:Label ID="Label3" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbMailList_HasImportFromExcellFile" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td class="text">
                          «· ’œÌ— ·„·› ≈ﬂ”·<span class="RequiredField"><asp:Label ID="Label14" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbMailList_HasExportToExcellFile" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                           Has Email Design<span class="RequiredField"><asp:Label ID="Label12" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbMailList_HasEmailDesign" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            SMTP<span class="RequiredField"><asp:Label ID="Label1" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MailSMTP" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                ErrorMessage="*" ControlToValidate="txtMailList_MailSMTP" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            SMTP Port<span class="RequiredField"><asp:Label ID="Label4" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MailSMTPPort" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_MailSMTPPort" Display="Dynamic"
                                ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Mail UserName<span class="RequiredField"><asp:Label ID="Label5" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MailUserName" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_MailUserName" Display="Dynamic"
                                ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Mail PassWord<span class="RequiredField"><asp:Label ID="Label6" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MailPassWord" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_MailPassWord" Display="Dynamic"
                                ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Mail From<span class="RequiredField"><asp:Label ID="Label7" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MailFrom" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_MailFrom" Display="Dynamic"
                                ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            MailFromCon<span class="RequiredField"><asp:Label ID="Label8" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MailFromCon" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_MailFromCon" Display="Dynamic"
                                ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Mail From Name<span class="RequiredField"><asp:Label ID="Label9" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MailFromName" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_MailFromName" Display="Dynamic"
                                ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Max Of Tries<span class="RequiredField"><asp:Label ID="Label10" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MailMaxNoOfTries" MaxLength="2" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_MailMaxNoOfTries" Display="Dynamic"
                                ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    
                    
                   
                    <tr>
                        <td class="text">
                            Max Bcc Count<span class="RequiredField"><asp:Label ID="Label16" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MaxBccCount" MaxLength="2" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_MaxBccCount" Display="Dynamic"
                                ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Sending To(for sending as bcc)<span class="RequiredField"><asp:Label ID="Label20"
                                runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_SendingTo" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_SendingTo" Display="Dynamic"
                                ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Has Attachments<span class="RequiredField"><asp:Label ID="Label17" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbMailList_HasAttachments" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Max Attach Files Count(per megabyte)<span class="RequiredField"><asp:Label ID="Label18"
                                runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MaxAttachFilesCount" MaxLength="2" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_MaxAttachFilesCount" Display="Dynamic"
                                ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Max All Attach Size<span class="RequiredField"><asp:Label ID="Label21" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_MaxAllAttachSize" MaxLength="2" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_MaxAllAttachSize" Display="Dynamic"
                                ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Sending Interval By Seconds<span class="RequiredField"><asp:Label ID="Label19" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtMailList_SendingIntervalBySeconds" MaxLength="10" runat="server"
                                CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMailList_SendingIntervalBySeconds"
                                Display="Dynamic" ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                ValidationGroup="SiteSettings" Text="*"></asp:RequiredFieldValidator>
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
