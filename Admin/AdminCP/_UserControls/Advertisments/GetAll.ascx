<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GetAll.ascx.cs" Inherits="AdminCP__UserControls_Advertisments_GetAll" %>
<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
				<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
			<tr id="trLanguages" runat="server">
					<td class="text"><%= Resources.AdminText.Language %><span class="RequiredField"><asp:Label ID="Label3" runat="server" Text="*" /></span></td>
					<td class="control">
						<asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls" 
                            AutoPostBack="true" onselectedindexchanged="ddlLanguages_SelectedIndexChanged" />
					</td>
				</tr>
                <tr>
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:Advertisments,PlaceID %>" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList id="ddlAdvPlaces" AutoPostBack="true" runat="server" 
                            CssClass="Controls" ValidationGroup="Advertisments" 
                            onselectedindexchanged="ddlAdvPlaces_SelectedIndexChanged"></asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td class="Result" align="center"  colspan="2">
						<asp:Label ID="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="GridControl" align="center" colspan="2">
						<asp:DataGrid id="dgControl" runat="server" SkinId="GridViewSkin" 
						OnDeleteCommand="dgControl_DeleteCommand" OnItemDataBound="dgControl_ItemDataBound"  >
						<Columns>
							<asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" ></asp:BoundColumn>
							<asp:TemplateColumn ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="<%$ Resources:Advertisments,AdvItem %>">
							<ItemTemplate>
							<div><%# Eval("Title")%></div>
							<div ><%# DCCMSNameSpace.AdvertismentsFactory.GetAdvertiseFileForAdmin(Eval("AdvertiseID"))%></div>
							<div><a target="_blank" href='<%# Eval("Url")%>'><%# Eval("Url")%></a></div>
								
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,AdminGrid_ActivationStatus %>">
							<ItemTemplate>
							<img alt="" src="<%# DCCMSNameSpace.General.GetBoleanPhoto(Eval("IsActive")) %>" />
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Update %>">
							<ItemTemplate>
							<a href='<%# "Save.aspx?id="+DataBinder.Eval(Container.DataItem, "AdvertiseID") %>' class='Link'>
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