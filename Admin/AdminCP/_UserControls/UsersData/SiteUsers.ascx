<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteUsers.ascx.cs" Inherits="Admin_Modules_ELS_UserControls_UsersData_SiteUsers" %>
<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>

<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td>
            <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
             <tr id="trLanguages" runat="server">
					<td class="text"><%= Resources.AdminText.Language %><span class="RequiredField"><asp:Label ID="Label3" runat="server" Text="*" /></span></td>
					<td class="control">
						<asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls" 
                            AutoPostBack="true" onselectedindexchanged="ddlLanguages_SelectedIndexChanged" />
					</td>
				</tr>
				<tr runat="server" id="trCategoryID">
                    <td class="text">
                        <asp:Label ID="lblCategoryID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlCategoryID" AutoPostBack="true" runat="server" 
                            CssClass="Controls" onselectedindexchanged="ddlCategoryID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id="trExport">
                    <td class="text">
                       
                    </td>
                    <td class="Control">
                       <asp:Button ID="btnExport" runat="server" SkinID="btnExport" 
                            onclick="btnExport_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblResult" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="GridControl" align="center" colspan="2">
                        <asp:DataGrid ID="dgUsersData" runat="server" SkinID="GridViewSkin" OnDeleteCommand="dgUsersData_DeleteCommand"
                            OnItemDataBound="dgUsersData_ItemDataBound" OnEditCommand="dgUsersData_EditCommand">
                            <Columns>
							<asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle"   HeaderText="<%$ Resources:AdminText,Index %>"></asp:BoundColumn>
                               
                                <asp:BoundColumn DataField="Name" ItemStyle-Width="30%" ItemStyle-CssClass="ItemStyleTitle"
                                    HeaderText="<%$ Resources:UsersData,Name %>"></asp:BoundColumn>
                                 <asp:BoundColumn DataField="Email" ItemStyle-Width="30%" ItemStyle-CssClass="ItemStyleTitle"
                                    HeaderText="<%$ Resources:UsersData,Email %>"></asp:BoundColumn>
                                <asp:TemplateColumn ItemStyle-Width="50px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:UsersData,EnableOrDisable %>">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="lbtnUserActivation" CommandName="Edit" runat="server" ImageUrl='<%# GetActivationImage(Eval("IsApproved"))%>'>
                                            </asp:ImageButton>
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Update %>">
                                <ItemTemplate>
                                    <a href='<%# "Edit.aspx?id="+DataBinder.Eval(Container.DataItem, "UserId") %>' class='Link'>
                                        <img src="/Content/AdminDesign/global/images/Edit.gif" style="border-width: 0px" alt="<%#Resources.AdminText.Update%>" /></a>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                                <asp:TemplateColumn Visible="true" ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton"
                                    HeaderText="<%$ Resources:AdminText,Delete %>">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lbtnDelete" SkinID="ibtnGridDelete" CommandName="Delete" runat="server">
                                        </asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </td>
                </tr>
                <tr>
                    <td class="PagerControl" align="center" colspan="2">
                        <cc1:OurPager ID="pager" runat="server" OnPageIndexChang="Pager_PageIndexChang">
                        </cc1:OurPager>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
