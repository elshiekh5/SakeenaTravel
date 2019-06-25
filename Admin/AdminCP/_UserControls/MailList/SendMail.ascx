<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendMail.ascx.cs" Inherits="Admin_MailList_SendMail" %>
 <%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				<tr id="trLanguages" runat="server">
					<td class="text"><asp:Label ID="Label12" Text="<%$ Resources:MailListAdmin,Language %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label11" runat="server" Text="*" /></span></td>
					<td class="control">
						<asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls"  />
					</td>
				</tr>
				<tr id="trGroups" runat="server">
					<td class="text"><asp:Label ID="Label9" Text="<%$ Resources:MailListAdmin,ImportMails_GroupName %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label10" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:DropDownList id="ddlMailListGroups" runat="server" CssClass="Controls" ValidationGroup="MailListEmails"></asp:DropDownList>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvGroupID" runat="server" ErrorMessage="*" ControlToValidate="ddlMailListGroups" InitialValue="-1" ValidationGroup="MailListEmails" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr id="trEmail" runat="server">
					<td class="text"><asp:Label ID="Label4" Text="<%$ Resources:MailListAdmin,EMail %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label6" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="128" id="txtEmail" runat="server" CssClass="Controls" ValidationGroup="MailListEmails"></asp:TextBox>
						<asp:RegularExpressionValidator Display="Dynamic" ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="" Text="<%$ Resources:MailListAdmin,EMail_Invaild %>" ValidationGroup="MailListEmails" ValidationExpression="^([\w\-\.]+)@((\[([0-9]{1,3}\.){3}[0-9]{1,3}\])|(([\w\-]+\.)+)([a-zA-Z]{2,4}))$"></asp:RegularExpressionValidator>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ValidationGroup="MailListEmails" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:MailListAdmin,EmailSubject %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span></td>
					   <td class="Control">
					    <asp:TextBox ID="txtEMailSubject" runat="server" CssClass="Controls" ValidationGroup="MailListEmails"				></asp:TextBox>
			            <asp:RequiredFieldValidator ID="rfvSubj" runat="server" ErrorMessage="*" ValidationGroup="MailListEmails"	ControlToValidate="txtEMailSubject">*</asp:RequiredFieldValidator>
					
                    </td>
				</tr>
				<tr id="trAttatch1" runat="server">
					<td class="text"><asp:Label ID="Label13" Text="<%$ Resources:MailListAdmin,EmailAttatchFile1 %>" runat="server" /></td>
					<td class="Control">
					    <asp:FileUpload ID="fuAttach1" runat="server" CssClass="Controls"  ValidationGroup="MailListEmails"	 />
			            <asp:RegularExpressionValidator ID="regAttach1" runat="server" ControlToValidate="fuAttach1" ValidationGroup="MailListEmails" ErrorMessage='<%$ Resources:MailListAdmin,EmailAttatchFileAvialableExtebtions %>'  ValidationExpression="(.*\.([pP][dD][fF])$)|(.*\.([dD][oO][cC])$)|(.*\.([dD][oO][cC][xX])$)|(.*\.([tT][xX][tT])$)|(.*\.([pP][nN][gG])$)|(.*\.([jJ][pP][gG])$)|(.*\.([gG][iI][fF])$)"></asp:RegularExpressionValidator>
					</td>
				</tr>
				<tr id="trAttatch2" runat="server">
					<td class="text"><asp:Label ID="Label3" Text="<%$ Resources:MailListAdmin,EmailAttatchFile2 %>" runat="server" /></td>
					<td class="Control">
					    <asp:FileUpload ID="fuAttach2" runat="server" CssClass="Controls" ValidationGroup="MailListEmails"  />
			            <asp:RegularExpressionValidator ID="regAttach2" runat="server" ControlToValidate="fuAttach2" ErrorMessage='<%$ Resources:MailListAdmin,EmailAttatchFileAvialableExtebtions %>' ValidationGroup="MailListEmails" ValidationExpression="(.*\.([pP][dD][fF])$)|(.*\.([dD][oO][cC])$)|(.*\.([dD][oO][cC][xX])$)|(.*\.([tT][xX][tT])$)|(.*\.([pP][nN][gG])$)|(.*\.([jJ][pP][gG])$)|(.*\.([gG][iI][fF])$)"></asp:RegularExpressionValidator>
					</td>
				</tr>
				<tr id="trAttatch3" runat="server">
					<td class="text"><asp:Label ID="Label5" Text="<%$ Resources:MailListAdmin,EmailAttatchFile3 %>" runat="server" /></td>
					<td class="Control">
					    <asp:FileUpload ID="fuAttach3" runat="server" CssClass="Controls"  ValidationGroup="MailListEmails"  />
			            <asp:RegularExpressionValidator ID="regAttach3" runat="server" ControlToValidate="fuAttach3" ValidationGroup="MailListEmails"
				        ErrorMessage='<%$ Resources:MailListAdmin,EmailAttatchFileAvialableExtebtions %>' ValidationExpression="(.*\.([pP][dD][fF])$)|(.*\.([dD][oO][cC])$)|(.*\.([dD][oO][cC][xX])$)|(.*\.([tT][xX][tT])$)|(.*\.([pP][nN][gG])$)|(.*\.([jJ][pP][gG])$)|(.*\.([gG][iI][fF])$)"></asp:RegularExpressionValidator>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label7" Text="<%$ Resources:MailListAdmin,EMailBody %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label8" runat="server" Text="*" /></span></td>
					<td class="Control"></td>
				</tr>
				<tr>
					<td class="Control" colspan="2">
					    
                            <CE:Editor id="fckEmailbody" Height="500" Width="1000" EditorWysiwygModeCss="~/CuteSoft_Client/example.css" runat="server" ></CE:Editor>
                            
						</td>
				</tr>
				<tr>
					<td class="Result" align="center" colspan="2">
				<asp:Button ID="btnSend"  runat="server"   ValidationGroup="MailListEmails" onclick="btnSend_Click"  SkinID="btnSend"   />
					</td>
				</tr>
				</table>
			</td>
		</tr>
	</table>

