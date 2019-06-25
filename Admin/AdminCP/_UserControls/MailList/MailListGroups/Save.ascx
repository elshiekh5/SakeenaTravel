<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Save.ascx.cs" Inherits="AdminCP__UserControls_MailList_MailListGroups_Save" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >

				<tr>
					<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:MailListAdmin,ImportMails_GroupName %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="64" id="txtName" runat="server" CssClass="Controls" ValidationGroup="MailListGroups"></asp:TextBox>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName" ValidationGroup="MailListGroups" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="Result" align="center" colspan="2">
				<asp:Button ID="btnSave"  runat="server"   ValidationGroup="MailListGroups" onclick="btnSave_Click"  SkinID="btnSave"   />
					</td>
				</tr>
				</table>
			</td>
		</tr>
	</table>