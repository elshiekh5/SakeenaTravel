<%@ Page Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master" AutoEventWireup="true"
    CodeFile="Profile.aspx.cs" Inherits="Admin_Users_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <font color="red"></font>
    <table width="95%">
        <tr>
             <td class="text">
                <asp:Label ID="Label1" Text="<%$ Resources:Zecurity,UserNameLabelText %>" runat="server" />
            </td>
            <td class="Control">
                <asp:Label runat="server" ID="lblUserName" />
            </td>
        </tr>
        <tr id="trCreationDate" runat="server" visible="false">
             <td class="text">
               <asp:Label ID="Label3" Text="<%$ Resources:Zecurity,ZecurityUserDateAdded %>" runat="server" />
            </td>
            <td class="Control">
                <asp:Label runat="server" ID="lblCreationDate" />
            </td>
        </tr>
        <%--<tr>
			 <td class="text">Email</td>
			<td class="Control"><asp:TextBox runat="server" ID="txtEmail" CssClass="Controls" />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
					ErrorMessage="*" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
					ErrorMessage="Wrong Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
					ValidationGroup="ChangePassword"></asp:RegularExpressionValidator></td>
		</tr>--%>
        <%--	<tr>
			<td>Active ?</td>
			<td><asp:CheckBox runat="server" ID="cbIsApproved" /></td>
		</tr>
		 --%>
        <tr>
             <td class="text">
               <asp:Label ID="Label2" Text="<%$ Resources:Zecurity,ZecurityUserLastLogin %>" runat="server" />
            </td>
            <td class="Control">
                <asp:Label runat="server" ID="lblLastDate" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="SubHeader">
                <%= Resources.MemberShip.ChangePassword %>
            </td>
        </tr>
        <tr>
            <td class="Result" align="center" colspan="2">
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
             <td class="text">
                <%= Resources.MemberShip.Password%>
            </td>
            <td class="Control">
                <asp:TextBox runat="server" ID="txtCurrentPassword" TextMode="Password" CssClass="Controls" />
                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="txtCurrentPassword"
                    ValidationGroup="ChangePassword" Text="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
             <td class="text">
                <%= Resources.MemberShip.NewPassword%>
            </td>
            <td class="Control">
                <asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" CssClass="Controls" />
                <asp:Label ID="LblPasslength" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPassword"
                    ValidationGroup="ChangePassword" Text="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
             <td class="text">
                <%= Resources.MemberShip.ConfirmNewPassword%>
            </td>
            <td class="Control">
                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="Controls" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirmPassword"
                    ValidationGroup="ChangePassword" Text="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                    ControlToValidate="txtConfirmPassword" ErrorMessage="<%$ Resources:MemberShip,NewPasswordConfirmationError %>"
                    ValidationGroup="ChangePassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click"
                    ValidationGroup="ChangePassword" />
            </td>
        </tr>
    </table>
</asp:Content>
