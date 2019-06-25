<%@ Page Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master" AutoEventWireup="true" CodeFile="ToGroup.aspx.cs" Inherits="AdminCP_SMS_Send_ToGroup"  %>
<%@ Register Src="../../_UserControls/SMS/SMS.ascx" TagName="SMS" TagPrefix="uc1" %>
<%@ Register Src="../../_UserControls/SMS/Send/SendSms.ascx" TagName="SendSms" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="MainTable" cellspacing="0" cellpadding="0" width="100%" 
        border="0">
        <tr>
            <tr>
                <td >
                    <uc1:sms id="SMS1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <uc2:SendSms ID="SendSms1" runat="server" FormSmsTo="Group" />
                </td>
            </tr>
    </table>
</asp:Content>
