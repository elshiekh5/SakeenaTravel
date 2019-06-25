<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="AdminCP__UserControls_MailList_MailListUsers_Add" %>
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
					<td class="text"><asp:Label ID="Label12" Text="<%$ Resources:MailListAdmin,Language %>" runat="server" /><span class="RequiredField"><asp:Label  runat="server" Text="*" /></span></td>
					<td class="control">
						<asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls"  />
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvLanguages" InitialValue="-1" runat="server" ErrorMessage="*" ControlToValidate="ddlLanguages" ValidationGroup="MailListUsers" Text="*"></asp:RequiredFieldValidator>

					</td>
				</tr>
				<tr id="trGroups" runat="server">
					<td class="text"><asp:Label  Text="<%$ Resources:MailListAdmin,ImportMails_GroupName %>" runat="server" /><span class="RequiredField"><asp:Label  runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:CheckBoxList id="ddlMailListGroups" runat="server" CssClass="Controls" ValidationGroup="MailListUsers"></asp:CheckBoxList>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label  Text="<%$ Resources:MailListAdmin,EMail %>" runat="server" /><span class="RequiredField"><asp:Label  runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="128" id="txtEmail" runat="server" CssClass="Controls" ValidationGroup="MailListUsers"></asp:TextBox>
						<asp:RegularExpressionValidator Display="Dynamic" ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="" Text="<%$ Resources:MailListAdmin,Result_InvalidMail %>" ValidationGroup="MailListUsers" ValidationExpression="^([\w\-\.]+)@((\[([0-9]{1,3}\.){3}[0-9]{1,3}\])|(([\w\-]+\.)+)([a-zA-Z]{2,4}))$"></asp:RegularExpressionValidator>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ValidationGroup="MailListUsers" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label  Text="<%$ Resources:MailListAdmin,Email_Active %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label4" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:CheckBox id="cbIsActive" CssClass="Controls" runat="server" ValidationGroup="MailListUsers"></asp:CheckBox>
					</td>
				</tr>
				
				<tr>
					<td class="Result" align="center" colspan="2">
				<asp:Button ID="btnSave"  runat="server"   ValidationGroup="MailListUsers" onclick="btnSave_Click"  SkinID="btnSave"   />
					</td>
				</tr>
				</table>
			</td>
		</tr>
	</table>