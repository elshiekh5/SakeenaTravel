<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImportFromTextFile.ascx.cs" Inherits="AdminCP__UserControls_MailList_MailListUsers_Import_Export_ImportFromTextFile" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td  colspan="2">
                           <%= Resources.MailListAdmin.ImportMails_Note%>
                            <br />
                            mail1@domian.com
                            <br />
                            mail2@domian.com
                            <br />
                            mail3@domian.com
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;">
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </td>
                    </tr>
        <tr>
            <td class="Result" align="center" colspan="2">
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </td>
        </tr>
                    <tr id="trLanguages" runat="server">
                        <td class="text">
                            <asp:Label ID="Label12" Text="<%$ Resources:MailListAdmin,Language %>" runat="server" /><span
                                class="RequiredField"><asp:Label ID="Label4" runat="server" Text="*" /></span>
                        </td>
                        <td class="control">
                            <asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls" />
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvLanguages" InitialValue="-1"
                                runat="server" ErrorMessage="*" ControlToValidate="ddlLanguages" ValidationGroup="MailListUsers"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
       <tr id="trGroups" runat="server">
            <td class="text">
                <asp:Label  Text="<%$ Resources:MailListAdmin,ImportMails_GroupName %>" runat="server" /><span class="RequiredField"><asp:Label
                     runat="server" Text="*" /></span>
            </td>
            <td class="Control">
                <asp:DropDownList ID="ddlMailListGroups" runat="server" CssClass="Controls" ValidationGroup="MailListUsers">
                </asp:DropDownList>
                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvGroupID" runat="server" ErrorMessage="*"
                    ControlToValidate="ddlMailListGroups" InitialValue="-1" ValidationGroup="MailListUsers"
                    Text="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text">
                <asp:Label  Text="<%$ Resources:MailListAdmin,ImportMails_File %>"  runat="server" /><span class="RequiredField"><asp:Label ID="Label222" runat="server"
                    Text="*" /></span>
            </td>
            <td class="Control">
                <asp:FileUpload ID="fuNumbers" runat="server" CssClass="Controls" /><a href="/AdminCP/MailList/MailListUsers/Import-Export/SampleFiles/mails-sample.txt" title="<%= Resources.MailListAdmin.FileSample %>" target="_blank"><%= Resources.MailListAdmin.FileSample %></a>
                <asp:RequiredFieldValidator ID="rfvNumbers" runat="server" ErrorMessage="*" ControlToValidate="fuNumbers"
                    ValidationGroup="MailListUsers">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RFV" runat="server" ControlToValidate="fuNumbers"
                    ValidationGroup="MailListUsers" ErrorMessage="<%$ Resources:MailListAdmin,ImportMails_FileValidation %>" ValidationExpression="(.*\.([tT][xX][tT])$)"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
					<td class="text"><asp:Label ID="Label5" Text="<%$ Resources:MailListAdmin,Email_Active %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label6" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:CheckBox id="cbIsActive" CssClass="Controls" runat="server" ValidationGroup="MailListUsers"></asp:CheckBox>
					</td>
				</tr>
        <tr>
            <td class="Result" align="center" colspan="2">
                <asp:Button ID="btnSave" runat="server" 
                    ValidationGroup="MailListUsers" OnClick="btnSave_Click" SkinID="btnSave" />
            </td>
        </tr>
        <tr>
            <td  colspan="2">
                <table id="tblResults" class="SubTable" cellspacing="0" cellpadding="0" width="100%"
                    border="0">
                    <tr>
                        <td colspan="3"  id="tdSuccessfulyMails" style="height: 50px;">
                            <asp:Label ID="lblSuccessfulyMails" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1"  valign="top" id="tdNotMails">
                            <asp:Label ID="lblNotMails" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="1"  valign="top" id="tdFailedMails">
                            <asp:Label ID="lblFailedMails" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="1"  valign="top" id="tdExistsMails">
                            <asp:Label ID="lblExistsMails" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
            </td>
        </tr>
    </table>