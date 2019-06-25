<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Default.ascx.cs" Inherits="AdminCP__UserControls_MailList_MailListUsers_Default" %>
<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
				<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
			<tr id="trLanguages" runat="server">
					<td class="text"><asp:Label ID="Label12" Text="<%$ Resources:MailListAdmin,Language %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label4" runat="server" Text="*" /></span></td>
					<td class="control">
						<asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls" 
                            AutoPostBack="true" onselectedindexchanged="ddlLanguages_SelectedIndexChanged" />
					</td>
				</tr>
               <tr id="trGroups" runat="server">
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:MailListAdmin,ImportMails_GroupName %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:DropDownList id="ddlMailListGroups" runat="server" CssClass="Controls" ValidationGroup="MailListUsers"></asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label3" Text="<%$ Resources:MailListAdmin,SearchByEmail %>" runat="server" /></td>
					<td class="Control">
						<asp:TextBox MaxLength="128" id="txtEmail" runat="server" CssClass="Controls" ValidationGroup="MailListUsers"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td class="Result" align="center" colspan="2">
				<asp:Button ID="btnSearch"  runat="server" 
                              ValidationGroup="MailListUsers"   
                            SkinID="btnSearch" onclick="btnSearch_Click"   />
                            <asp:Button ID="btnExport" runat="server" ValidationGroup="MailListUsers" OnClick="btnExport_Click"
                                SkinID="btnExport" />
					</td>
				</tr>
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
							<asp:BoundColumn  DataField="Email"  ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleTitle" HeaderText="<%$ Resources:MailListAdmin,EMail %>"></asp:BoundColumn>
							<asp:TemplateColumn ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" HeaderText="<%$ Resources:AdminText,ActivationStatus %>">
                                    <ItemTemplate>
                                            <img alt="<%# Resources.AdminText.ActivationStatus %>" src="<%# General.GetBoleanPhoto(Eval("IsActive")) %>" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Update %>">
							<ItemTemplate>
								<a href='<%# "Edit.aspx?id="+DataBinder.Eval(Container.DataItem, "UserID") %>' class='Link'>
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
                        <asp:DataGrid AutoGenerateColumns="False" AllowSorting="false" ID="dgExport" runat="server"
                                SkinID="GridViewSkin">
                                <Columns>
                                    <asp:TemplateColumn ItemStyle-HorizontalAlign="left" HeaderText="<%$ Resources:MailListAdmin,Email %>">
                                        <ItemTemplate>
                                            <div dir="ltr">
                                                <%# Eval("Email")%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" HeaderText="<%$ Resources:AdminText,ActivationStatus %>">
                                        <ItemTemplate>
                                        <center>
                                             <img alt="<%# Resources.AdminText.ActivationStatus %>" src="<%# SiteSettings.Site_WebsiteDomain+General.GetBoleanPhoto(Eval("IsActive")) %>" />
                                        </center>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
					</td>
				</tr>
				<tr>
					<td class="PagerControl" align="center" colspan="2" style="margin-top:10px;">
						<cc1:OurPager ID="pager" runat="server" OnPageIndexChang="Pager_PageIndexChang"></cc1:OurPager>
					</td>
				</tr>

			</table>
			</td>
			</tr>
			</table>