<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Comments.ascx.cs" Inherits="Admin_Comments_Comments" %>

<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
 <tr id="trLanguages" runat="server">
                    <td class="text">
                        <%= Resources.AdminText.Language %><span class="RequiredField"><asp:Label ID="Label3" runat="server" Text="*" /></span>
                    </td>
                    <td class="control">
                        <asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlLanguages_SelectedIndexChanged" />
                    </td>
                </tr>
				<tr>
					<td class="Result" align="center"  colspan="2">
						<asp:Label ID="lblResult" runat="server" ></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="GridControl" align="center" colspan="2">
						<asp:DataGrid id="dgComments" runat="server" SkinId="GridViewSkin" 
						OnDeleteCommand="dgComments_DeleteCommand" OnItemDataBound="dgComments_ItemDataBound" 
                            onitemcommand="dgComments_ItemCommand"  >
						<Columns>
							<asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" HeaderText=""  ></asp:BoundColumn>
							<asp:TemplateColumn ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:Comments,TheComment %>">
							<ItemTemplate>
							<table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td class="Comments_Head" align="right">
                                <div class="Comments_SenderName">
                                    <span style="color: Red;">
                                        <%# Eval("SenderName") %></span>
                                </div>
                                <div class="Comments_SendingDate">
                                    <span>
                                        <%#Convert.ToDateTime(Eval("SendingDate"))%></span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="Comments_CommentTitle" align="right">
                                <b>
                                    <%# Eval("CommentTitle") %></b>
                            </td>
                        </tr>
                        <tr>
                            <td class="Comments_CommentText" align="right">
                                <%# Eval("CommentText") %>
                            </td>
                        </tr>
                        
                        <tr><td style="height: 20px"></td></tr>
                    </table>
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,AdminGrid_ActivationStatus %>">
							<ItemTemplate>
							<img alt="" src="<%# General.GetBoleanPhoto(Eval("IsActive")) %>" />
							</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:Comments,Activate %>">
							<ItemTemplate><asp:ImageButton ID="ibtnActivate"  ImageUrl="/Content/images/Boolean/True.gif" CommandName="Activate" runat="server" /></ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,AdminGrid_View %>">
							<ItemTemplate>
								<a href='<%# "Edit.aspx?CommentID="+DataBinder.Eval(Container.DataItem, "CommentID") + "&page="+PageFile + "&forItem="+Request.QueryString["id"] %> ' class='Link'>
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
					<td class="PagerControl" align="center" colspan="2"><br />
						<cc1:OurPager ID="pager" runat="server" OnPageIndexChang="Pager_PageIndexChang"></cc1:OurPager>
					</td>
				</tr>

			</table>

