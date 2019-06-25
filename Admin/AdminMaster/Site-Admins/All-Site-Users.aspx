<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="All-Site-Users.aspx.cs"
    Inherits="MasterAdmin_AllSiteUsers" %>
    <%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Label ID="lblResult" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHeader" colspan="2">
                            „” Œœ„Ì «·„Êﬁ⁄
                        </td>
                    </tr>
                    <tr>
					<td class="GridControl" align="center" colspan="2">
						<asp:DataGrid id="dgSiteUsers" runat="server" SkinId="GridViewSkin" 
						OnDeleteCommand="dgSiteUsers_DeleteCommand" OnItemDataBound="dgSiteUsers_ItemDataBound"  
						OnEditCommand="dgSiteUsers_EditCommand">
						<Columns>
							<asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" HeaderText="Index"></asp:BoundColumn>
							<asp:BoundColumn Visible="false" DataField="ProviderUserKey"  ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleTitle" HeaderText="ID"></asp:BoundColumn>
							<asp:TemplateColumn ItemStyle-Width="30%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="UserName">
							<ItemTemplate>
							<%#  DataBinder.Eval(Container.DataItem, "UserName")%>
							</ItemTemplate>
							</asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-Width="30%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="Password">
							<ItemTemplate>
							<%# GetPassword((string) DataBinder.Eval(Container.DataItem, "UserName"))%>
							</ItemTemplate>
							</asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-Width="30%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="Folder Size">
							<ItemTemplate>
							<%# GetSubSiteFolderSize(DataBinder.Eval(Container.DataItem, "UserName"))%>
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn  DataField="Email"  ItemStyle-Width="50%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="Email"></asp:BoundColumn>
							<asp:TemplateColumn ItemStyle-Width="30px" ItemStyle-CssClass="ItemStyleButton" HeaderText=" ›⁄Ì·/ÕŸ—">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="lbtnUserActivation" CommandName="Edit" runat="server" ImageUrl='<%# GetActivationImage(Eval("IsApproved"))%>'>
                                            </asp:ImageButton>                                                                                                
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" Visible="false" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Update %>">
							<ItemTemplate>
							<a href='<%# "Save.aspx?id="+DataBinder.Eval(Container.DataItem, "ProviderUserKey") %>' class='Link'>
									<img src="/Content/AdminDesign/global/images/Edit.gif" style="border-width:0px" alt=" ⁄œÌ·" /></a>
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
