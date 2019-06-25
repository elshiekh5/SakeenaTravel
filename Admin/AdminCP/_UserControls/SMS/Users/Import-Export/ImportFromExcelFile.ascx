<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImportFromExcelFile.ascx.cs" Inherits="AdminCP__UserControls_SMS_Users_Import_Export_ImportFromExcelFile" %>
<%@ Register Src="../../SMS.ascx" TagName="SMS" TagPrefix="uc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" align="center"
        border="0">
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
        <tr id="trLanguages" runat="server">
            <td class="text"><asp:Label ID="Label12" Text="<%$ Resources:SmsAdmin,Language %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label3" runat="server" Text="*" /></span>
            </td>
            <td class="control">
                <asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls" />
                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvLanguages" InitialValue="-1"
                    runat="server" ErrorMessage="*" ControlToValidate="ddlLanguages" ValidationGroup="SMSNumbers"
                    Text="*"></asp:RequiredFieldValidator>
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
                 <asp:Label ID="Label6" Text="<%$ Resources:SmsAdmin,ImportSms_File %>" runat="server" />
            </td>
            <td class="control">
                <asp:FileUpload CssClass="Controls" id="FuFile" runat="server" /><a href="/AdminCP/SMS/Users/Import-Export/SampleFiles/numbers-sample.xls" title="<%= Resources.SmsAdmin.FileSample %>" target="_blank"><%= Resources.SmsAdmin.FileSample %></a>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FuFile"
                    ErrorMessage="<%$ Resources:SmsAdmin,ImportSms_ExcellFileValidation %>"  ValidationExpression="(.*\.([xX][Ll][sS])$|.*\.([xX][Ll][sS][xX])$)" ValidationGroup="SMSNumbers_Create">
                </asp:RegularExpressionValidator><asp:RequiredFieldValidator id="rfvNumbers" runat="server"
                    ErrorMessage="*" ControlToValidate="FuFile" ValidationGroup="SMSNumbers"></asp:RequiredFieldValidator>
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
        <tr>
            <td  colspan="2">
                <table id="tblResults" class="SubTable" cellspacing="0" cellpadding="0" width="100%"
                    border="0">
                    <tr>
                        <td colspan="3"  id="tdSuccessfulyMails" style="height: 50px;">
                            <asp:Label ID="lblSuccessfulyRecords" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1"  valign="top" id="tdNotMails">
                            <asp:Label ID="lblNotMobileNumbers" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="1"  valign="top" id="tdFailedMails">
                            <asp:Label ID="lblFailedMobileNumbers" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="1"  valign="top" id="tdExistsMails">
                            <asp:Label ID="lblExistsMobileNumbers" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
    </table>