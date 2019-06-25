<%@ Control Language="c#" AutoEventWireup="true" CodeFile="GetVisitorsParticipations.ascx.cs" Inherits="Items_AdminGetVisitorsParticipations" %>

<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td>
            <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr id="trLanguages" runat="server">
                    <td class="text">
                        <%= Resources.AdminText.Language %><span class="RequiredField"><asp:Label ID="Label3" runat="server" Text="*" /></span>
                    </td>
                    <td class="control">
                        <asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlLanguages_SelectedIndexChanged" />
                    </td>
                </tr>
                <tr id="trCategoryID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblCategoryID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlItemCategories" runat="server" CssClass="Controls" ValidationGroup="Items"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlItemCategories_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCategoryID" runat="server" ErrorMessage="*"
                            ControlToValidate="ddlItemCategories" InitialValue="-1" ValidationGroup="Items"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblResult" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="GridControl" align="center" colspan="2">
                        <asp:DataGrid ID="dgItems" runat="server" SkinID="GridViewSkin" OnDeleteCommand="dgItems_DeleteCommand"
                            OnItemDataBound="dgItems_ItemDataBound">
                            <Columns>
                                <asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" HeaderText="<%$ Resources:AdminText,Index %>">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Title" ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleTitle"
                                    HeaderText=""></asp:BoundColumn>
                                <asp:TemplateColumn ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleButton" HeaderText="">
                                    <ItemTemplate>
                                        <a runat="server" id="a1" href='<%# ItemsFactory.GetItemsPhotoBigThumbnail(Eval("ItemID"),Eval("PhotoExtension"),Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>'
                                            class="highslide" onclick="return hs.expand(this)">
                                            <img src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),80,80,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>'
                                                class="GImage" alt='<%# Resources.AdminText.ClickToEnlage %>' /></a>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="<%$ Resources:AdminText,AdminGrid_AddedBy %>">
                                    <ItemTemplate>
                                        <%# Eval("InsertUserName")%></ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="<%$ Resources:AdminText,AdminGrid_ActivationStatus %>">
                                    <ItemTemplate>
                                        <center>
                                            <img src="<%# General.GetBoleanPhoto(Eval("IsAvailable")) %>" /></center>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,AdminGrid_Photos %>">
                                    <ItemTemplate>
                                        <a href='<%# "AddPhoto.aspx?ID="+DataBinder.Eval(Container.DataItem, "ItemID") %>'>
                                            <img border="0" src='/Content/AdminDesign/global/images/Edit.gif' alt='<%# Resources.AdminText.AdminGrid_Photos %>' /></a>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="<%$ Resources:AdminText,AdminGrid_InActiveComments %>">
                                    <ItemTemplate>
                                        <center>
                                            <a href='Comments/ItemInActiveComments.aspx?id=<%# Eval("ItemID") %>'>
                                                <%# Eval("InactiveComments")%></a></center>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="<%$ Resources:AdminText,AdminGrid_ActiveComments %>">
                                    <ItemTemplate>
                                        <center>
                                            <a href='Comments/ItemActiveComments.aspx?id=<%# Eval("ItemID") %>'>
                                                <%# Eval("ActiveComments")%></a></center>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText=""  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <center>
                                            <a href='Messages/default.aspx?id=<%# Eval("ItemID") %>'>
                                                <%# Eval("RequestTotalCount")%></a></center>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <center>
                                            <a href='Messages/New.aspx?id=<%# Eval("ItemID") %>'>
                                                <%# Eval("RequestNewCount")%></a></center>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="<%$ Resources:AdminText,AdminGrid_DateAdded %>">
                                    <ItemTemplate>
                                        <%# Eval("Date_Added")%></ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Update %>">
                                    <ItemTemplate>
                                        <a href='<%# "../Edit.aspx?id="+DataBinder.Eval(Container.DataItem, "ItemID") %>' class='Link'>
                                            <img src="/Content/AdminDesign/global/images/Edit.gif" style="border-width: 0px" alt="<%#Resources.AdminText.Update%>" /></a>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Delete %>">
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
