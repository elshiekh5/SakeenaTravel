<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Edit.ascx.cs" Inherits="AdminCP__UserControls_SMS_Groups_Edit" %>
<%@ Register Src="../SMS.ascx" TagName="SMS" TagPrefix="uc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td align="center" colspan="2">
                <uc1:sms id="SMS1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label id="lblResult" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text">
               <asp:Label ID="Label1" Text="<%$ Resources:SmsAdmin,Group_Name %>" runat="server" />
            </td>
            <td class="control">
                <asp:TextBox CssClass="Controls" id="txtName" runat="server" ValidationGroup="SMSGroups_Update">
                </asp:TextBox>
                <asp:RequiredFieldValidator id="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName"
                    ValidationGroup="SMSGroups_Update">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Result" align="center" colspan="2">
                <asp:Button  id="btnUpdate" runat="server"  OnClick="btnUpdate_Click"
                    ValidationGroup="SMSGroups_Update" SkinID="btnSave"></asp:Button>
            </td>
        </tr>
    </table>