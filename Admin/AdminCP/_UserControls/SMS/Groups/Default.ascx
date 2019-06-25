<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Default.ascx.cs" Inherits="AdminCP__UserControls_SMS_Groups_Default" %>
<%@ Register Src="../SMS.ascx" TagName="SMS" TagPrefix="uc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td align="center" colspan="2">
                <uc1:sms id="SMS1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="Result" align="center" colspan="2">
                <asp:DataGrid id="dgSMSGroups" runat="server" SkinID="GridViewSkin" OnDeleteCommand="dgSMSGroups_DeleteCommand"
                    OnItemDataBound="dgSMSGroups_ItemDataBound" OnPageIndexChanged="dgSMSGroups_PageIndexChanged">
                    <columns>
							<asp:BoundColumn DataField="Name" HeaderText="<%$ Resources:SmsAdmin,Group_Name %>" ItemStyle-Width=75%></asp:BoundColumn>
							<asp:TemplateColumn HeaderText="<%$ Resources:AdminText,Update %>" ItemStyle-HorizontalAlign=center>
							<ItemTemplate >
							<a href='<%# "Edit.aspx?GroupID="+DataBinder.Eval(Container.DataItem, "GroupID") %>' class='Link'>
									<img src="/Content/AdminDesign/global/images/Edit.gif" style="border-width:0px" alt="<%#Resources.AdminText.Update%>" /></a>
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="<%$ Resources:AdminText,Delete %>" ItemStyle-HorizontalAlign=center>
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