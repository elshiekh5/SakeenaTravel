<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GetAll.ascx.cs" Inherits="App_Controls_SiteDeparments_Admin_All" %>

<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >

				<tr>
				<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >

				<tr>
					<td class="Result" align="center"  colspan="2">
						<asp:Label ID="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="GridControl" align="center" colspan="2">
						<asp:DataGrid id="dgSiteDeparments" runat="server" SkinId="GridViewSkin" 
						OnDeleteCommand="dgSiteDeparments_DeleteCommand" 
                            OnItemDataBound="dgSiteDeparments_ItemDataBound" 
                              >
						<Columns>
							<asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle"   HeaderText="<%$ Resources:AdminText,Index %>"></asp:BoundColumn>
							<asp:TemplateColumn ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="<%$ Resources:SiteDepartments,Title %>">
							<ItemTemplate>
								<%# DataBinder.Eval(Container.DataItem, "Title")%>
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="<%$ Resources:AdminText,AdminGrid_AddedBy %>" ><ItemTemplate><%# Eval("InsertUserName")%></ItemTemplate></asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Update %>">
							<ItemTemplate>
								<a href='<%# "Edit.aspx?id="+DataBinder.Eval(Container.DataItem, "DepartmentID") %>' class='Link'>
									<img src="/Content/AdminDesign/global/images/Edit.gif" style="border-width:0px" alt="<%#Resources.AdminText.Update%>" /></a>
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Delete %>">
							<ItemTemplate>
								<asp:ImageButton ID="lbtnDelete"   SkinID="ibtnGridDelete" CommandName="Delete" runat="server"></asp:ImageButton>
							</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
						</asp:DataGrid>
					</td>
				</tr>
			</table>
			</td>
			</tr>
			</table>

