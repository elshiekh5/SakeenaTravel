<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs" Inherits="AdminSitePages_GetAll"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>

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
				<tr>
					<td class="GridControl" align="center" colspan="2">
						<asp:DataGrid id="dgSitePages" runat="server" SkinId="GridViewSkin" 
						OnDeleteCommand="dgSitePages_DeleteCommand" OnItemDataBound="dgSitePages_ItemDataBound"  
						OnEditCommand="dgSitePages_EditCommand">
						<Columns>
							<asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" HeaderText="Index"></asp:BoundColumn>
							<asp:BoundColumn  DataField="PageID"  ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleTitle" HeaderText="ID"></asp:BoundColumn>
							<asp:TemplateColumn ItemStyle-Width="50%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="ÇÓã ÇáÕÝÍÉ">
							<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "Title")%>
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn  DataField="Identifire"  ItemStyle-Width="50%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="Identifire"></asp:BoundColumn>
							<asp:TemplateColumn ItemStyle-Width="50px" ItemStyle-CssClass="ItemStyleButton" HeaderText="ÊÝÚíá/ÍÙÑ">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="lbtnUserActivation" CommandName="Edit" runat="server" ImageUrl='<%# GetActivationImage(Eval("IsAvailabe"))%>'>
                                            </asp:ImageButton>
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Update %>">
							<ItemTemplate>
							<a href='<%# "Save.aspx?id="+(int)DataBinder.Eval(Container.DataItem, "PageID") %>' class='Link'>
									<img src="/Content/AdminDesign/global/images/Edit.gif" style="border-width:0px" alt="ÊÚÏíá" /></a>
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn  ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Delete %>">
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
</asp:Content>
