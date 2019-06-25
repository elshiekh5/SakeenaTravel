<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="AdminCP__UserControls_SMS_Groups_Add" %>
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
        <tr>
            <td class="text">
                <asp:Label ID="Label1" Text="<%$ Resources:SmsAdmin,Group_Name %>" runat="server" />
            </td>
            <td class="control">
                <asp:TextBox CssClass="Controls" ID="txtName" runat="server" MaxLength="100" ValidationGroup="SMSGroups_Create">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName"
                    ValidationGroup="SMSGroups_Create">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button  ID="btnCreate" runat="server"  OnClick="btnCreate_Click"
                    ValidationGroup="SMSGroups_Create" SkinID="btnSave" ></asp:Button>
            </td>
        </tr>
    </table>
