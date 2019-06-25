<%@ Control Language="c#" AutoEventWireup="true" CodeFile="OrdersByUser.ascx.cs" Inherits="Items_GetAll" %>

<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td>
            <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr id="trUserID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblUser" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlUsers" runat="server" CssClass="Controls" ValidationGroup="Items"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCategoryID" runat="server" ErrorMessage="*"
                            ControlToValidate="ddlUsers" InitialValue="-1" ValidationGroup="Items"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="GridControl" align="center" colspan="2">
                        <asp:DataGrid ID="dgItems" runat="server" SkinID="GridViewSkin" OnDeleteCommand="dgItems_DeleteCommand"
                            OnItemDataBound="dgItems_ItemDataBound">
                            <Columns>
                                <asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" HeaderText="<%$ Resources:AdminText,Index %>"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CustomerName" ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleTitle"
                                    HeaderText=""></asp:BoundColumn>
                                
                                
                                <asp:TemplateColumn HeaderText="">
                                    <ItemTemplate>
                                        <center>
                                            <%# GetStatusText(Eval("Status")) %>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="<%$ Resources:AdminText,AdminGrid_DateAdded %>">
                                    <ItemTemplate>
                                        <%# Eval("DateAdded")%>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Show %>">
                                    <ItemTemplate>
                                        <a href='<%# "details.aspx?id="+DataBinder.Eval(Container.DataItem, "OrderID") %>' class='Link'>
                                            <img src="/Content/AdminDesign/global/images/Edit.gif" style="border-width: 0px" alt="<%#Resources.AdminText.Show%>" /></a>
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
