<%@ Page Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master"  AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_Users_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <font color="red"></font>
	<table width="100%" border="0">
		<tr>
			<td colspan="2" class="SubHeader"><asp:Label ID="Label1" Text="<%$ Resources:Zecurity,ZecurityUserData %>" runat="server" /></td>
		</tr>
		<tr>
			<td class="text"><asp:Label ID="Label2" Text="<%$ Resources:Zecurity,UserNameLabelText %>" runat="server" /></td>
			<td class="Control"><asp:Label runat="server" ID="lblUserName" /></td>
		</tr>
		<tr  runat="server" visible="false">
			<td class="text"><asp:Label ID="Label3" Text="<%$ Resources:Zecurity,ZecurityUserDateAdded %>" runat="server" /></td>
			<td class="Control"><asp:Label runat="server" ID="lblCreationDate" /></td>
			
		</tr>
		<tr>
			<td class="text"><asp:Label ID="Label4" Text="<%$ Resources:Zecurity,EmailLabelText %>" runat="server" /></td>
			<td class="Control"><asp:TextBox CssClass="Controls" runat="server" ID="txtEmail"  />
				<asp:RequiredFieldValidator Display="Dynamic"   ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
					ErrorMessage="*" ValidationGroup="vgAlterUser"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
					ErrorMessage="Email not correct" ValidationExpression="^([\w\-\.]+)@((\[([0-9]{1,3}\.){3}[0-9]{1,3}\])|(([\w\-]+\.)+)([a-zA-Z]{2,4}))$"
					ValidationGroup="vgAlterUser"></asp:RegularExpressionValidator></td>
		</tr>
		<tr>
			<td class="text"><asp:Label ID="Label5" Text="<%$ Resources:Zecurity,ZecurityUserAccountActive %>" runat="server" /></td>
			<td class="Control"><asp:CheckBox runat="server" ID="cbIsApproved" /></td>
		</tr>
		<tr runat="server" visible="false">
			<td class="text"><asp:Label ID="Label6" Text="<%$ Resources:Zecurity,ZecurityUserExist %>" runat="server" /></td>
			<td class="Control"><asp:CheckBox runat="server" ID="cbIsOnline" Enabled="false" /></td>
		</tr>
		<tr runat="server" visible="false">
			<td class="text" ><asp:Label ID="Label11" Text="<%$ Resources:Zecurity,ZecurityUserLastLogin %>" runat="server" /></td>
			<td class="Control"><asp:Label runat="server" ID="lblLastDate" /></td>
		</tr>
		<tr>
			<td colspan=2 class="SubHeader"><asp:Label ID="Label7" Text="<%$ Resources:Zecurity,ChangePassword %>" runat="server" /></td>
		</tr>
		<tr>
			<td class="text"><asp:Label ID="Label8" Text="<%$ Resources:Zecurity,PasswordLabelText %>" runat="server" /></td>
			<td class="Control"><asp:TextBox CssClass="Controls" runat="server" ID="txtPassword" TextMode="Password"  /></td>
		</tr>
		<tr>
			<td class="text"><asp:Label ID="Label9" Text="<%$ Resources:Zecurity,ConfirmPasswordLabelText %>" runat="server" /></td>
			<td class="Control"><asp:TextBox runat="server" CssClass="Controls" ID="txtConfirmPassword" TextMode="Password"  />
				<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
					ControlToValidate="txtConfirmPassword" ErrorMessage="<%$ Resources:Zecurity,ConfirmPasswordCompareErrorMessage %>"
					ValidationGroup="vgAlterUser"></asp:CompareValidator></td>
		</tr>
		<tr>
			<td colspan=2 class="SubHeader"><asp:Label ID="Label10" Text="<%$ Resources:Zecurity,Groups %>" runat="server" /></td>
		</tr>
		<tr>
			<td colspan=2 class="Control">
			    <asp:CheckBoxList ID="cblGroups" runat="server">
                </asp:CheckBoxList>
			</td>
		</tr>
		<tr>
			<td colspan=2 align="center"><asp:Button CssClass="Button" ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" ValidationGroup="vgAlterUser" /></td>
		</tr>
	</table>
</asp:Content>