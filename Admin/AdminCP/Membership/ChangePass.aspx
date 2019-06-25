<%@ Page Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master" AutoEventWireup="true"
    CodeFile="ChangePass.aspx.cs" Inherits="Admin_Admin_ChangePass"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                        <td class="text">
                            <%= Resources.MemberShip.Password%>
                        </td>
                        <td class="Control">
                            <asp:TextBox CssClass="Controls" ID="txtCurrentPassword" runat="server"  TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="txtCurrentPassword"
                                 ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            <%= Resources.MemberShip.NewPassword%>
                        </td>
                        <td class="Control">
                            <asp:TextBox CssClass="Controls" ID="txtNewPassword" runat="server"  TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="txtNewPassword"
                                            ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            <%= Resources.MemberShip.ConfirmNewPassword%>
                        </td>
                        <td class="Control">
                            <asp:TextBox CssClass="Controls" ID="txtConfirmNewPassword" runat="server"  TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="txtConfirmNewPassword"
                                   ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="result" align="center" colspan="2">
                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="txtNewPassword"
                                ControlToValidate="txtConfirmNewPassword" Display="Dynamic" ErrorMessage="<%$ Resources:MemberShip,NewPasswordConfirmationError %>"
                                ValidationGroup="ChangePassword1"></asp:CompareValidator>
                        </td>
                    </tr>
                   
                    <tr>
                        <td  class="Result" align="center" colspan="2">
						<asp:ImageButton ID="ibtnUpdate" runat="server" SkinID="ibtnUpdate"   OnClick="ChangePasswordPushButton_Click" ValidationGroup="ChangePassword1" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


