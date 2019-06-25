<%@ Control Language="c#" AutoEventWireup="true"  Inherits="DCCMSNameSpace.ReadyUserControls.ItemCategories_GetAllBaseControl" %>

<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>

<table id="Table1" style="width: 100%;" cellspacing="0" cellpadding="0" border="0"
    align="center">
    <tr>
        <td class="Result" align="center" colspan="2">
            <asp:Label ID="lblResult" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height: 100%;" valign="top" align="center" colspan="2">
            <div id='lists'>
                <!-- ------------------------ dlCategories ------------------------ -->
                 <asp:DataList Width="100%" ID="dlPCategories" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    ItemStyle-CssClass="DataListItem">
                    <ItemTemplate>
                        <center>
                            <div id="hlist">
                                <div class="photocon">
                                    <a href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <img id="photo" border='0' src='<%# ItemCategoriesFactory.GetItemCategoriesPhotoThumbnail(Eval("CategoryID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListWidth,Eval("OwnerName"),Eval("ModuleTypeID")) %>'
                                            alt='<%# Eval("title") %>' title='<%# Eval("title") %>' />
                                    </a>
                                </div>
                                <div id="title">
                                       <a href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# Eval("title") %></a></div>
                            </div>
                        </center>
                    </ItemTemplate>
                </asp:DataList>
                <asp:DataList Width="100%" ID="dlCategories" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                    ItemStyle-CssClass="DataListItem">
                    <ItemTemplate>
                        <center>
                            <div id="hlist">
                                <div class="photocon">
                                    <a href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <img id="photo" border='0' src='<%# ItemCategoriesFactory.GetItemCategoriesPhotoThumbnail(Eval("CategoryID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListWidth,Eval("OwnerName"),Eval("ModuleTypeID")) %>'
                                            alt='<%# Eval("title") %>' title='<%# Eval("title") %>' />
                                    </a>
                                </div>
                                <%--<div id="hbar">
                            </div>
                            <div id="btop">
                            </div>
                            <div id="title">
                                <%# Eval("title") %></div>
                            <div id="bbottom">
                            </div>--%>
                                <div id="title">
                                       <a href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# Eval("title") %></a></div>
                            </div>
                        </center>
                    </ItemTemplate>
                </asp:DataList>
                 <!-- ------------------------ dlMessagesCategories ------------------------ -->
                <asp:DataList Width="100%" ID="dlMessagesCategories" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                    ItemStyle-CssClass="DataListItem">
                    <ItemTemplate>
                        <center>
                            <div id="hlist">
                                <div class="photocon">
                                    <a href='<%# "Default.aspx?id=" + Eval("CategoryID") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <img id="photo" border='0' src='<%# ItemCategoriesFactory.GetItemCategoriesPhotoThumbnail(Eval("CategoryID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListWidth,Eval("OwnerName"),Eval("ModuleTypeID")) %>'
                                            alt='<%# Eval("title") %>' title='<%# Eval("title") %>' />
                                    </a>
                                </div>
                                <%--<div id="hbar">
                            </div>
                            <div id="btop">
                            </div>
                            <div id="title">
                                <%# Eval("title") %></div>
                            <div id="bbottom">
                            </div>--%>
                                <div id="title">
                                       <a href='<%# "Default.aspx?id=" + Eval("CategoryID") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# Eval("title") %></a></div>
                            </div>
                        </center>
                    </ItemTemplate>
                </asp:DataList>
                <!-- ------------------------ dlListedCategories ------------------------ -->
                <asp:Repeater ID="dlListedCategories" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01">
                                    «·≈”„</div>
                                <div class="GridetitleN02">
                                    ⁄œœ «·„·›« </div>
                                <div class="GridetitleN03">
                                     Õ„Ì·</div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <div class="GridDataN01">
                             <a href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                                </a>
                            </div>
                            <div class="GridDataN02">
                                <%# DataBinder.Eval(Container, "DataItem.ActiveItemsCount")%></div>
                            <div class="GridDataN03">
                                <a href='<%#DataBinder.Eval(Container, "DataItem.YoutubeCode") %>' target="_blank">
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </td>
    </tr>
    <tr runat="server" id="trPagerContainer">
        <td class="PagerControl" align="center" colspan="2">
            <cc1:OurPager ID="pager" runat="server" OnPageIndexChang="Pager_PageIndexChang">
            </cc1:OurPager>
        </td>
    </tr>
    <tr >
        <td style="height:15px;" colspan="2"></td>    
    </tr>
</table>

