<%@ Control Language="C#" AutoEventWireup="true" CodeFile="default.ascx.cs" Inherits="AdminCP__UserControls_SMS_SMSArchive_default" %>
<%@ Register Src="../SMS.ascx" TagName="SMS" TagPrefix="uc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td class="Result" align="center" colspan="2">
                <uc1:sms id="SMS1" runat="server" />
                <asp:Button CssClass="BigButton" ID="Button1" runat="server" onclick="Button1_Click"
                    Text="<%$ Resources:SmsAdmin,Archive_DeleteAllData %>" />
                <asp:DataGrid id="dgSMSArchive" runat="server" SkinID="GridViewSkin" OnDeleteCommand="dgSMSArchive_DeleteCommand"
                    OnItemDataBound="dgSMSArchive_ItemDataBound" OnPageIndexChanged="dgSMSArchive_PageIndexChanged">
                    <columns>
				<asp:BoundColumn DataField="Sender" HeaderText="<%$ Resources:SmsAdmin,SmsSender %>"></asp:BoundColumn>
				<asp:BoundColumn DataField="RecieverMobile" HeaderText="<%$ Resources:SmsAdmin,SmsReciever %>"></asp:BoundColumn>
				<asp:BoundColumn DataField="Message" HeaderText="<%$ Resources:SmsAdmin,MsgBody %>"></asp:BoundColumn>
				<%--<asp:BoundColumn DataField="Lang" HeaderText="<%$ Resources:SmsAdmin,Language %>"></asp:BoundColumn>--%>
				<asp:TemplateColumn HeaderText="<%$ Resources:AdminText,Delete %>">
				<ItemTemplate>
					<asp:ImageButton ID="lbtnDelete" SkinID="ibtnGridDelete" CommandName="Delete" runat="server"></asp:ImageButton>
				</ItemTemplate>
				</asp:TemplateColumn>
			</columns>
                </asp:DataGrid>
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="<%$ Resources:AdminText,ThereIsNoData %>"></asp:Label>
            </td>
        </tr>
    </table>