<%@ Control Language="c#" AutoEventWireup="true" CodeFile="GetAll.ascx.cs" Inherits="Messages_GetAll" %>

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
                <tr runat="server" id="trType">
                    <td class="text">
                        <asp:Label ID="lblType" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlType" AutoPostBack="true" runat="server" CssClass="Controls"
                            OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trExport" runat="server">
                    <td class="Result" align="center" colspan="2">
                        <asp:Button ID="btnExport" runat="server" ValidationGroup="Messages" OnClick="btnExport_Click"
                            SkinID="btnExport" />
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblResult" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="GridControl" align="center" colspan="2">
                        <asp:DataGrid ID="dgMessages" runat="server" SkinID="GridViewSkin" OnDeleteCommand="dgMessages_DeleteCommand"
                            OnItemDataBound="dgMessages_ItemDataBound">
                            <Columns>
                                <asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" HeaderText="<%$ Resources:AdminText,Index %>">
                                </asp:BoundColumn>
                                 <asp:TemplateColumn ItemStyle-Width="40%" HeaderText="">
                                    <ItemTemplate>
                                            <%#  DataBinder.Eval(Container, "DataItem.Title")%>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-Width="40%" HeaderText="">
                                    <ItemTemplate>
                                            <%#  DataBinder.Eval(Container, "DataItem.Email")%>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-Width="40%"  HeaderText="">
                                    <ItemTemplate>
                                            <%#  DataBinder.Eval(Container, "DataItem.Name")%>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                            <img alt="<%# Eval("IsSeen") %>" src="<%# General.GetBoleanPhoto(Eval("IsSeen")) %>" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                            <img alt="<%# Eval("IsReplied") %>" src="<%# General.GetBoleanPhoto(Eval("IsReplied")) %>" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                            <img  alt="<%# Eval("IsAvailable") %>" src="<%# General.GetBoleanPhoto(Eval("IsAvailable")) %>" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <center>
                                            <a href='Comments/ItemInActiveComments.aspx?id=<%# Eval("MessageID") %>'>
                                                <%# Eval("InactiveComments")%></a></center>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <center>
                                            <a href='Comments/ItemActiveComments.aspx?id=<%# Eval("MessageID") %>'>
                                                <%# Eval("ActiveComments")%></a></center>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        <%# Eval("Date_Added")%></ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,AdminGrid_View %>">
                                    <ItemTemplate>
                                        <a href='<%# "Edit.aspx?id="+DataBinder.Eval(Container.DataItem, "MessageID") %>'
                                            class='Link'>
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
