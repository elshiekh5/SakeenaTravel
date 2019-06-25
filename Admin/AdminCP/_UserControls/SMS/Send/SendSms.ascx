<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendSms.ascx.cs" Inherits="Admin_SMS_Send" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td>
            <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trLanguages" runat="server">
                    <td class="text"><asp:Label ID="Label12" Text="<%$ Resources:SmsAdmin,Language %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label11" runat="server" Text="*" /></span>
                    </td>
                    <td class="control">
                        <asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls" />
                    </td>
                </tr>
                <tr id="trGroups" runat="server">
                    <td class="text">
                        <asp:Label ID="Label9" Text="<%$ Resources:SmsAdmin,Group_Name %>" runat="server" /><span class="RequiredField"><asp:Label
                            ID="Label10" runat="server" Text="*" /></span>
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlSMSGroups" runat="server" CssClass="Controls" ValidationGroup="SMS">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvGroupID" runat="server" ErrorMessage="*"
                            ControlToValidate="ddlSMSGroups" InitialValue="-1" ValidationGroup="SMS"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trNumbers" runat="server">
                    <td class="text">
                        <asp:Label ID="Label4" Text="<%$ Resources:SmsAdmin,MobileNumber %>" runat="server" /><span class="RequiredField"><asp:Label
                            ID="Label6" runat="server" Text="*" /></span>
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtNumbers" runat="server" CssClass="Controls" ValidationGroup="SMS"></asp:TextBox>
                       
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvNumber" runat="server" ErrorMessage="*"
                            ControlToValidate="txtNumbers" ValidationGroup="SMS" Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="text">
                        <asp:Label ID="Label1" Text="<%$ Resources:SmsAdmin,MsgBody %>" runat="server" /><span class="RequiredField"><asp:Label
                            ID="Label2" runat="server" Text="*" /></span>
                    </td>
                    <td class="Control">
                        <asp:TextBox ID="txtMsg" runat="server" CssClass="Controls" TextMode="MultiLine" ValidationGroup="SMS"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSubj" runat="server" ErrorMessage="*" ValidationGroup="SMS"
                            ControlToValidate="txtMsg">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Button ID="btnSend" runat="server" ValidationGroup="SMS" OnClick="btnSend_Click"
                            SkinID="btnSend" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
