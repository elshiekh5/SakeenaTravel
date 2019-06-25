<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs" Inherits="AdminCities_GetAll"  %>
<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>

 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

			<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
				<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >

				<tr>
					<td class="Result" align="center"  colspan="2">
						<asp:Label ID="lblResult" runat="server" ></asp:Label>
					</td>
				</tr>
				<tr id="trCountryID" runat="server" colspan="2">
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:Cities,Country %>" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList  ID="ddlCountries" runat="server" CssClass="Controls" 
                            ValidationGroup="Cities" AutoPostBack="true" 
                            onselectedindexchanged="ddlCountries_SelectedIndexChanged" />
					</td>
				</tr>
				<tr>
					<td class="GridControl" align="center" colspan="2">
						<asp:DataGrid id="dgCities" runat="server" SkinId="GridViewSkin" 
						OnDeleteCommand="dgCities_DeleteCommand" OnItemDataBound="dgCities_ItemDataBound"  >
						<Columns>
							<asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle"   HeaderText=""></asp:BoundColumn>
							<asp:BoundColumn  DataField="NameAr"  ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="<%$ Resources:Cities,CityName %>"></asp:BoundColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Update %>">
							<ItemTemplate>
								<a href='<%# "Edit.aspx?id="+DataBinder.Eval(Container.DataItem, "CityID") %>' class='Link'>
									<img src="/Content/AdminDesign/global/images/Edit.gif" style="border-width:0px" alt="<%#Resources.AdminText.Update%>" /></a>
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Delete %>">
							<ItemTemplate>
								<asp:ImageButton ID="lbtnDelete" SkinID="ibtnGridDelete"  CommandName="Delete" runat="server"></asp:ImageButton>
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
</asp:Content>
