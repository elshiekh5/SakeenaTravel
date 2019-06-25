<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Edit.ascx.cs" Inherits="AdminCP__UserControls_SMS_Users_Edit" %>
<%@ Register Src="../SMS.ascx" TagName="SMS" TagPrefix="uc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td align="center" colspan="2">
                <uc1:sms id="SMS1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="Result" align="center" colspan="2">
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr id="trGroups" runat="server">
            <td class="text">
                <asp:Label ID="Label1" Text="<%$ Resources:SmsAdmin,Group_Name %>" runat="server" /><span class="RequiredField"><asp:Label
                    ID="Label2" runat="server" Text="*" /></span>
            </td>
            <td class="Control">
                <asp:DropDownList ID="ddlSmsGroups" runat="server" CssClass="Controls" ValidationGroup="SMSNumbers">
                </asp:DropDownList>
                <asp:RequiredFieldValidator Visible="false" Display="Dynamic" ID="rfvGroupID" runat="server"
                    ErrorMessage="*" ControlToValidate="ddlSmsGroups" InitialValue="-1" ValidationGroup="SMSNumbers"
                    Text="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text">
                <asp:Label ID="Label6" Text="<%$ Resources:SmsAdmin,MobileNumber %>" runat="server" />
            </td>
            <td class="control">
                <asp:TextBox CssClass="Controls" ID="txtNumber" runat="server" MaxLength="20" ValidationGroup="SMSNumbers">
                </asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNumber"
                    ErrorMessage="<%$ Resources:SmsAdmin,Result_ErrorInNumber %>" ValidationExpression="(\d{10,15})" ValidationGroup="SMSNumbers">
                </asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="rfvNumbers" runat="server"
                    ErrorMessage="*" ControlToValidate="txtNumber" ValidationGroup="SMSNumbers"></asp:RequiredFieldValidator>
                    <br />
               <asp:Label ID="Label7" Text="<%$ Resources:SmsAdmin,SmsNoteAddingNumbers %>" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="text">
                <asp:Label ID="Label8" Text="<%$ Resources:SmsAdmin,Name %>" runat="server" />
            </td>
            <td class="control">
                <asp:TextBox CssClass="Controls" ID="txtName" runat="server" MaxLength="20" ValidationGroup="SMSNumbers">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text">
                <asp:Label ID="Label4" Text="<%$ Resources:SmsAdmin,Mobile_Active %>" runat="server" /><span class="RequiredField"><asp:Label
                    ID="Label5" runat="server" Text="*" /></span>
            </td>
            <td class="Control">
                <asp:CheckBox ID="cbIsActive" CssClass="Controls" runat="server" ValidationGroup="SMSNumbers">
                </asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td class="Result" align="center" colspan="2">
                <asp:Button ID="btnSave" runat="server" ValidationGroup="SMSNumbers" OnClick="btnSave_Click"
                    SkinID="btnSave" />
            </td>
        </tr>
    </table>