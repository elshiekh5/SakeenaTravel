<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImportFromTextFile.ascx.cs"
    Inherits="AdminCP__UserControls_SMS_Users_Import_Export_ImportFromTextFile" %>
<%@ Register Src="../../SMS.ascx" TagName="SMS" TagPrefix="uc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td>
            <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td align="center" colspan="2">
                        <uc1:SMS ID="SMS1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%= Resources.SmsAdmin.ImportNumbers_Note%>
                        <br />
                        966000000000 - Name 1
                        <br />
                        966000000000 - Name 2
                        <br />
                        966000000000
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px;">
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trLanguages" runat="server">
                    <td class="text">
                        <asp:Label ID="Label12" Text="<%$ Resources:SmsAdmin,Language %>" runat="server" /><span
                            class="RequiredField"><asp:Label ID="Label4" runat="server" Text="*" /></span>
                    </td>
                    <td class="control">
                        <asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls" />
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvLanguages" InitialValue="-1"
                            runat="server" ErrorMessage="*" ControlToValidate="ddlLanguages" ValidationGroup="SmsUsers"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trGroups" runat="server">
                    <td class="text">
                        <asp:Label  Text="<%$ Resources:SmsAdmin,Group_Name %>" runat="server" /><span
                            class="RequiredField"><asp:Label  runat="server" Text="*" /></span>
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlSmsGroups" runat="server" CssClass="Controls" ValidationGroup="SmsUsers">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvGroupID" runat="server" ErrorMessage="*"
                            ControlToValidate="ddlSmsGroups" InitialValue="-1" ValidationGroup="SmsUsers"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="text">
                        <asp:Label  Text="<%$ Resources:SmsAdmin,ImportSms_File %>" runat="server" /><span
                            class="RequiredField"><asp:Label  runat="server" Text="*" /></span>
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuFile" runat="server" CssClass="Controls" /><a href="/AdminCP/SMS/Users/Import-Export/SampleFiles/numbers-sample.txt"
                            title="<%= Resources.SmsAdmin.FileSample %>" target="_blank"><%= Resources.SmsAdmin.FileSample %></a>
                        <asp:RequiredFieldValidator ID="rfvNumbers" runat="server" ErrorMessage="*" ControlToValidate="fuFile"
                            ValidationGroup="SmsUsers">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RFV" runat="server" ControlToValidate="fuFile"
                            ValidationGroup="SmsUsers" ErrorMessage="<%$ Resources:SmsAdmin,ImportSms_FileValidation %>"
                            ValidationExpression="(.*\.([tT][xX][tT])$)"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="text">
                        <asp:Label ID="Label5" Text="<%$ Resources:SmsAdmin,Sms_Active %>" runat="server" /><span
                            class="RequiredField"><asp:Label ID="Label6" runat="server" Text="*" /></span>
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="cbIsActive" CssClass="Controls" runat="server" ValidationGroup="SmsUsers">
                        </asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="SmsUsers" OnClick="btnSave_Click"
                            SkinID="btnSave" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table id="tblResults" class="SubTable" cellspacing="0" cellpadding="0" width="100%"
                            border="0">
                            <tr>
                                <td colspan="3" id="tdSuccessfulyMails" style="height: 50px;">
                                    <asp:Label ID="lblSuccessfulyRecords" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1" valign="top" id="tdNotMails">
                                    <asp:Label ID="lblNotMobileNumbers" runat="server" Text=""></asp:Label>
                                </td>
                                <td colspan="1" valign="top" id="tdFailedMails">
                                    <asp:Label ID="lblFailedMobileNumbers" runat="server" Text=""></asp:Label>
                                </td>
                                <td colspan="1" valign="top" id="tdExistsMails">
                                    <asp:Label ID="lblExistsMobileNumbers" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
