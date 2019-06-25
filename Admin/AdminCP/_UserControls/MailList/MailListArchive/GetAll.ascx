<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GetAll.ascx.cs" Inherits="AdminCP__UserControls_MailList_MailListArchive_GetAll" %>
<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
	<tr>
		<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td class="Result" align="center"  colspan="2">
						<asp:Label ID="lblResult" runat="server" ></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="GridControl" align="center" colspan="2">
						<asp:DataGrid id="dgControl" runat="server" SkinId="GridViewSkin" 
						OnDeleteCommand="dgControl_DeleteCommand" OnItemDataBound="dgControl_ItemDataBound"  >
						<Columns>
							<asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" ></asp:BoundColumn>
							<asp:BoundColumn  DataField="Subject"  ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="<%$ Resources:MailListAdmin,EmailSubject%>"></asp:BoundColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$Resources:AdminText,Show%>">
							<ItemTemplate>
							    <a href='<%# "Show.aspx?id="+DataBinder.Eval(Container.DataItem, "MailID") %>' class='Link'>
									<img src="/Content/AdminDesign/global/images/Edit.gif" style="border-width:0px" alt="<%#Resources.AdminText.Update%>" /></a>
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Delete %>">
							<ItemTemplate>
								<asp:ImageButton ID="lbtnDelete" SkinID="ibtnGridDelete" CommandName="Delete" runat="server"></asp:ImageButton>
								
							</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
						</asp:DataGrid>
					</td>
				</tr>
				<tr>
					<td class="PagerControl" align="center" colspan="2">
						<cc1:OurPager ID="pager" runat="server" OnPageIndexChang="Pager_PageIndexChang"></cc1:OurPager>
					</td>
				</tr>

			</table>
			</td>
		</tr>
	</table>