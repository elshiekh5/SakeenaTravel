<%@ Control Language="C#" AutoEventWireup="true" Inherits="DCCMSNameSpace.ReadyUserControls.Items_GetAllBaseControl" %>
<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<table id="Table1" style="width: 100%" cellspacing="0" cellpadding="0" border="0"
    align="center">
    <tr id="trSearch" runat="server">
        <td>
            <table id="Table2" style="width: 100%;" cellspacing="3" cellpadding="0" border="0"
                align="center">
                <tr>
                    <td colspan="2" align="center">
                        <asp:TextBox ID="txtSearch" CssClass="Controls" runat="server" ValidationGroup="CurrentModuleSearch"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvSearch"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtSearch"
                            ValidationGroup="CurrentModuleSearch" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="ibtnSearch" runat="server" CssClass="ibtnsearch" ImageUrl="/Content/images/spacer.gif"
                            ValidationGroup="CurrentModuleSearch" OnClick="ibtnSearch_Click" />
                            <div class="SearchSeparator"></div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="Result" align="center">
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td valign="top" align="center">
            <div id='lists'>
                

                <asp:Repeater ID="dlItems" runat="server">
                    <ItemTemplate>
                       <div id="vlist">
                            <div id="photo">
                                <a href='<%# Eval("BuildLink") %>'
                                    title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        class="photo" src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_VListWidth,SiteSettings.Photos_VListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' /></a>
                            </div>
                            <div id="data">
                                <img src="/Content/images/spacer.gif" alt="" class="NP-box-bol">
                                <h2>
                                    <a href='<%# Eval("BuildLink") %>'
                                        title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# General.SubstringByChars(DataBinder.Eval(Container, "DataItem.Title").ToString(), 60)%></a></h2>
                                <div class="breif">
                                    <%# General.SubString(DataBinder.Eval(Container, "DataItem.ShortDescription").ToString(), 75, true)%>
                                    <a class="more" href='<%# Eval("BuildLink") %>'
                                        title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# Resources.Items.More %></a></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="dlCareersOld" runat="server">
                    <ItemTemplate>
                        <div class="career_img"></div>
                        <div class="careerTitle"><%# DataBinder.Eval(Container, "DataItem.Title") %></div>
                            <div class="career_data">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.ShortDescription").ToString(), 50, true)%>
                            <a href='<%# Eval("BuildLink") %>'><p class="career_more"> </p></a>
                            </div>
                        
                        
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="dlCareers" runat="server">
                    <ItemTemplate>
                        <div class="careerTitle"><%# DataBinder.Eval(Container, "DataItem.Title") %></div>
                            <div class="career_data">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.ShortDescription").ToString(), 50, true)%>
                            <a href='<%# Eval("BuildLink") %>'><p class="career_more"> </p></a>
                            </div>
                        
                        
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlNews ------------------------ -->
                <asp:Repeater ID="dlNews" runat="server">
                    <ItemTemplate>
                        <div id="vlist">
                            <div id="photo">
                                <a href='<%# Eval("BuildLink") %>'
                                    title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        class="photo" src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_VListWidth,SiteSettings.Photos_VListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' /></a>
                            </div>
                            <div id="data">
                                <img src="/Content/images/spacer.gif" alt="" class="NP-box-bol">
                                <h2>
                                    <a href='<%# Eval("BuildLink") %>'
                                        title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# General.SubstringByChars(DataBinder.Eval(Container, "DataItem.Title").ToString(), 60)%></a></h2>
                                <div class="date">
                                    <%# General.ConvertDateToHijri2((DateTime)DataBinder.Eval(Container, "DataItem.Date_Added")) + " " + Resources.User.Mofeq + " " + ((DateTime)DataBinder.Eval(Container, "DataItem.Date_Added")).ToLongDateString()%></div>
                                <div class="breif">
                                    <%# General.SubString(DataBinder.Eval(Container, "DataItem.ShortDescription").ToString(), 75, true)%>
                                    <a class="more" href='<%# Eval("BuildLink") %>'
                                        title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# Resources.Items.More %></a></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlArticles ------------------------ -->
                <asp:Repeater ID="dlArticles" runat="server">
                    <ItemTemplate>
                        <div id="vlist">
                            <div id="photo">
                                <a href='<%# Eval("BuildLink") %>'
                                    title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        class="photo" src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_VListWidth,SiteSettings.Photos_VListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' /></a>
                            </div>
                            <div id="data">
                                <img src="/Content/images/spacer.gif" alt="" class="NP-box-bol">
                                <h2>
                                    <a href='<%# Eval("BuildLink") %>'
                                        title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# DataBinder.Eval(Container, "DataItem.Title")%></a></h2>
                                <%--<div class="date">
                                    <%# General.ConvertDateToHijri2((DateTime)DataBinder.Eval(Container, "DataItem.Date_Added")) + " " + Resources.User.Mofeq + " " + ((DateTime)DataBinder.Eval(Container, "DataItem.Date_Added")).ToLongDateString() %></div>
                                --%><div class="breif">
                                    <%# General.SubString(DataBinder.Eval(Container, "DataItem.ShortDescription").ToString(), 45, true)%><%--<a class="more" href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'><%# Resources.Items.More %></a>--%></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlArticlesWithAuthorName ------------------------ -->
                <asp:Repeater ID="dlArticlesWithAuthorName" runat="server">
                    <ItemTemplate>
                        <div id="vlist">
                            <div id="photo">
                                <a href='<%# Eval("BuildLink") %>'
                                    title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        class="photo" src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_VListWidth,SiteSettings.Photos_VListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' /></a>
                            </div>
                            <div id="data">
                                <img src="/Content/images/spacer.gif" alt="" class="NP-box-bol">
                                <h2>
                                    <a href='<%# Eval("BuildLink") %>'
                                        title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# General.SubstringByChars(DataBinder.Eval(Container, "DataItem.Title").ToString(), 60)%></a></h2>
                                <div class="date">
                                    <%# DataBinder.Eval(Container, "DataItem.AuthorName")%>
                                </div>
                                <div class="breif">
                                    <%# General.SubString(DataBinder.Eval(Container, "DataItem.ShortDescription").ToString(), 75, true)%>
                                    <%--<a class="more" href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# Resources.Items.More %>--%></a></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlFiles ------------------------ -->
                <asp:Repeater ID="dlFiles" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01">
                                    <%# Resources.GlobalTexts.TheFile%></div>
                                <div class="GridetitleN02">
                                </div>
                                <div class="GridetitleN03">
                                    <%# Resources.User.DownLoad %></div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <div class="GridDataN01">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                            </div>
                            <div class="GridDataN02">
                            </div>
                            <div class="GridDataN03">
                                <a href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=1"%>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlFilesWithAuthors ------------------------ -->
                <asp:Repeater ID="dlFilesWithAuthors" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01">
                                    <%# Resources.GlobalTexts.TheFile%></div>
                                <div class="GridetitleN02">
                                    <%# Resources.GlobalTexts.TheAuthor%></div>
                                <div class="GridetitleN03">
                                    <%# Resources.User.DownLoad %></div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <div class="GridDataN01">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                            </div>
                            <div class="GridDataN02">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.AuthorName"), 5, true)%></div>
                            <div class="GridDataN03">
                                <a href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=1"%>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlBooks ------------------------ -->
                <asp:Repeater ID="dlBooks" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01">
                                    <%# Resources.GlobalTexts.TheBook %></div>
                                <div class="GridetitleN02">
                                </div>
                                <div class="GridetitleN03">
                                    <%# Resources.User.DownLoad %></div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <div class="GridDataN01">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                            </div>
                            <div class="GridDataN02">
                            </div>
                            <div class="GridDataN03">
                                <a href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=1"%>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlBooksWithAuthors ------------------------ -->
                <asp:Repeater ID="dlBooksWithAuthors" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01">
                                    <%# Resources.GlobalTexts.TheBook %></div>
                                <div class="GridetitleN02">
                                    <%# Resources.GlobalTexts.TheAuthor%></div>
                                <div class="GridetitleN03">
                                    <%# Resources.User.DownLoad %></div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <div class="GridDataN01">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                            </div>
                            <div class="GridDataN02">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.AuthorName"), 5, true)%></div>
                            <div class="GridDataN03">
                                <a href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=1"%>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlBooksSpecial--------- ------------------------ -->
                <asp:DataList ID="dlBooksSpecial" runat="server" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="hlist">
                            <div id="title">
                                <a href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=1"%>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a>
                            </div>
                            <br />
                            <div class="photocon">
                                <a href="<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=1"%>">
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        id="photo" border='0' src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' />
                                </a>
                            </div>
                            <div id="title">
                                <%--<a href=href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a>
                                <br />--%>
                                <%# DataBinder.Eval(Container, "DataItem.AuthorName")%>
                                <br />
                                <a id='aView' runat="server" visible='<%# CheckSwf(DataBinder.Eval(Container, "DataItem.FileExtension"),".swf") %>'
                                    onclick="return hs.htmlExpand(this, { objectType: 'iframe', width: '550',minWidth: '550', minHeight: '550' } )"
                                    href='<%# "/WebSite/Books/PopUp/Display.aspx?id="+ DataBinder.Eval(Container, "DataItem.ItemID") %>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-file.png"
                                        width="24" height="24" /></a> <a id='aDownload' runat="server" visible='<%# CheckFile(DataBinder.Eval(Container, "DataItem.FileExtension")) %>'
                                            href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=1"%>'>
                                            <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                                width="24" height="24" /></a>
                            </div>
                            <%--<div id="hbar">
                            </div>
                            <div id="btop">
                            </div>
                            <div id="title">
                                <a href='<%# Eval("Url") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            <div id="bbottom">
                            </div>--%>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <!-- ------------------------ dlAudiosWithAuthors ------------------------ -->
                <asp:Repeater ID="dlAudios" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01">
                                    <%# Resources.GlobalTexts.TheAudio%></div>
                                <div class="GridetitleN02">
                                </div>
                                <div class="GridetitleN03">
                                    <%# Resources.User.DownLoad %></div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <div class="GridDataN01">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                            </div>
                            <div class="GridDataN02">
                            </div>
                            <div class="GridDataN03">
                                <a href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=3"%>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="dlAudiosWithAuthors" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01">
                                    <%# Resources.GlobalTexts.TheAudio%></div>
                                <div class="GridetitleN02">
                                    <%# Resources.GlobalTexts.TheLectureProf%>
                                </div>
                                <div class="GridetitleN03">
                                    <%# Resources.User.DownLoad %></div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <div class="GridDataN01">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                            </div>
                            <div class="GridDataN02">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.AuthorName"), 5, true)%></div>
                            <div class="GridDataN03">
                                <a href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=3"%>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="dlAudiosFullData" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01_Z">
                                    <%# Resources.GlobalTexts.TheAudio%></div>
                                <div class="GridetitleN02_Z">
                                    <%# Resources.GlobalTexts.TheLectureProf%>
                                </div>
                                <div class="GridetitleN03_Z">
                                    <%# Resources.GlobalTexts.TheFile%>
                                </div>
                                <div class="GridetitleN03_Z">
                                    <%# Resources.GlobalTexts.Listen %></div>
                                <div class="GridetitleN03_Z">
                                    <%# Resources.User.DownLoad %></div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <a href='<%# Eval("BuildLink") %>'
                                title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                <div class="GridDataN01_Z">
                                    <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                                </div>
                            </a>
                            <div class="GridDataN02_Z">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.AuthorName"), 5, true)%></div>
                            <div class="GridDataN03_Z">
                                <%# DataBinder.Eval(Container, "DataItem.AudioExtension").ToString().Remove(0,1)%>
                            </div>
                            <div class="GridDataN03_Z">
                                <a id='aView' runat="server" onclick="return hs.htmlExpand(this, { objectType: 'iframe', width: '550',minWidth: '550', minHeight: '550'} )"
                                    href='<%# "/WebSite/Audios/PopUp/Display.aspx?id="+ DataBinder.Eval(Container, "DataItem.ItemID") %>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-file.png"
                                        width="24" height="24" /></a></div>
                            <div class="GridDataN03_Z">
                                <a href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=3"%>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlVideosWithAuthors ------------------------ -->
                <asp:Repeater ID="dlVideos" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01">
                                    <%# Resources.GlobalTexts.TheVideo%></div>
                                <div class="GridetitleN02">
                                </div>
                                <div class="GridetitleN03">
                                    <%# Resources.User.DownLoad %></div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <div class="GridDataN01">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                            </div>
                            <div class="GridDataN02">
                            </div>
                            <div class="GridDataN03">
                                <a id='aDownload' runat="server" visible='<%# CheckFile(DataBinder.Eval(Container, "DataItem.VideoExtension")) %>'
                                    href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=2"%>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a> <a id='aYouTube' runat="server" visible='<%# CheckYouTube(DataBinder.Eval(Container, "DataItem.VideoExtension"),DataBinder.Eval(Container, "DataItem.YoutubeCode")) %>'
                                            onclick="return hs.htmlExpand(this, { objectType: 'iframe', width: '550',minWidth: '550', minHeight: '550' } )"
                                            href='<%# "/WebSite/Vedios/PopUp/Display.aspx?id="+ DataBinder.Eval(Container, "DataItem.ItemID") %>'>
                                            <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-youtube.png"
                                                width="24" height="24" /></a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="dlVideosWithAuthors" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01">
                                    <%# Resources.GlobalTexts.TheVideo%></div>
                                <div class="GridetitleN02">
                                    <%# Resources.GlobalTexts.TheLectureProf%></div>
                                <div class="GridetitleN03">
                                    <%# Resources.User.DownLoad %></div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <div class="GridDataN01">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                            </div>
                            <div class="GridDataN02">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.AuthorName"), 5, true)%></div>
                            <div class="GridDataN03">
                                <a id='aDownload' runat="server" visible='<%# CheckFile(DataBinder.Eval(Container, "DataItem.VideoExtension")) %>'
                                    href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=2"%>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a> <a id='aYouTube' runat="server" visible='<%# CheckYouTube(DataBinder.Eval(Container, "DataItem.VideoExtension"),DataBinder.Eval(Container, "DataItem.YoutubeCode")) %>'
                                            onclick="return hs.htmlExpand(this, { objectType: 'iframe', width: '550',minWidth: '550', minHeight: '550' } )"
                                            href='<%# "/WebSite/Vedios/PopUp/Display.aspx?id="+ DataBinder.Eval(Container, "DataItem.ItemID") %>'>
                                            <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-youtube.png"
                                                width="24" height="24" /></a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="dlVideosFullData" runat="server">
                    <HeaderTemplate>
                        <div class="gridStyle">
                            <div class="gridHead">
                                <div class="GridetitleN01_Z">
                                    <%# Resources.GlobalTexts.TheVideo%></div>
                                <div class="GridetitleN02_Z">
                                    <%# Resources.GlobalTexts.TheLectureProf%>
                                </div>
                                <div class="GridetitleN03_Z">
                                    <%# Resources.GlobalTexts.TheFile%>
                                </div>
                                <div class="GridetitleN03_Z">
                                    <%# Resources.GlobalTexts.Watch%></div>
                                <div class="GridetitleN03_Z">
                                    <%# Resources.User.DownLoad %></div>
                            </div>
                            <div class="gridItems">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <div class="gridItemData">
                            <a href='<%# Eval("BuildLink") %>'
                                title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                <div class="GridDataN01_Z">
                                    <%# General.SubString(DataBinder.Eval(Container, "DataItem.Title"), 10, true)%>
                                </div>
                            </a>
                            <div class="GridDataN02_Z">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.AuthorName"), 5, true)%></div>
                            <div class="GridDataN03_Z">
                                <%# GetPureExtension(DataBinder.Eval(Container, "DataItem.VideoExtension"))%>
                            </div>
                            <div class="GridDataN03_Z">
                                <a id='aView' runat="server" onclick="return hs.htmlExpand(this, {objectType: 'iframe', width: '550',minWidth: '550', minHeight: '550' } )"
                                    href='<%# "/WebSite/Vedios/PopUp/Display.aspx?id="+ DataBinder.Eval(Container, "DataItem.ItemID") %>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-Video.png"
                                        width="24" height="24" /></a></div>
                            <div class="GridDataN03_Z">
                                <a id='aDownload' runat="server" visible='<%# CheckFile(DataBinder.Eval(Container, "DataItem.VideoExtension")) %>'
                                    href='<%#"/WebSite/ItemDownload.aspx?id=" + DataBinder.Eval(Container, "DataItem.ItemID") + "&type=2"%>'>
                                    <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-save.gif"
                                        width="24" height="24" /></a> <a id='aYouTube' runat="server" visible='<%# CheckYouTube(DataBinder.Eval(Container, "DataItem.VideoExtension"),DataBinder.Eval(Container, "DataItem.YoutubeCode")) %>'
                                            onclick="return hs.htmlExpand(this, { objectType: 'iframe', width: '550',minWidth: '550', minHeight: '550' } )"
                                            href='<%# "/WebSite/Vedios/PopUp/Display.aspx?id="+ DataBinder.Eval(Container, "DataItem.ItemID") %>'>
                                            <img alt="" border="0" src="/Design/Website/Interface/global/icons/icons-youtube.png"
                                                width="24" height="24" /></a></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlPersons ------------------------ -->
                <asp:DataList Width="100%" ID="dlPersons" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                    ItemStyle-CssClass="DataListItem">
                    <ItemTemplate>
                        <center>
                            <div id="hlist">
                                <div class="photocon">
                                    <a href='<%# Eval("BuildLink") %>'
                                        title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <img id="photo" border='0' src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_VListWidth,SiteSettings.Photos_VListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>'
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
                                    <a href='<%# Eval("BuildLink") %>'
                                        title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            </div>
                        </center>
                    </ItemTemplate>
                </asp:DataList>
                <!-- ------------------------ dlPersonsWithPopUp ------------------------ -->
                <asp:DataList Width="100%" ID="dlPersonsWithPopUp" runat="server" RepeatColumns="3"
                    RepeatDirection="Horizontal" ItemStyle-CssClass="DataListItem">
                    <ItemTemplate>
                        <center>
                            <div id="hlist">
                                <div class="photocon">
                                    <a onclick="return hs.htmlExpand(this,  { objectType: 'iframe', width: '550',minWidth: '550', minHeight: '550'} )"
                                        href='<%# "PopUp/Details.aspx?id="+Eval("ItemID") %>'>
                                        <img id="photo" border='0' src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_VListWidth,SiteSettings.Photos_VListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>'
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
                                    <a onclick="return hs.htmlExpand(this,  { objectType: 'iframe', width: '550',minWidth: '550', minHeight: '550'} )"
                                        href='<%# "PopUp/Details.aspx?id="+Eval("ItemID") %>'>
                                        <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            </div>
                        </center>
                    </ItemTemplate>
                </asp:DataList>
                <!-- ------------------------ dlLinksOnly ------------------------ -->
                <asp:Repeater ID="dlLinksOnly" runat="server">
                    <ItemTemplate>
                        <div id="vlist">
                            <div class="bol">
                            </div>
                            <div class="data-full">
                                <a class="title" href="<%# Eval("Url") %>" target="_blank" title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                    <%# General.SubstringByChars(DataBinder.Eval(Container, "DataItem.Title").ToString(), 60)%></a>
                                <br />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlLinksWithPhotos--------- ------------------------ -->
                <asp:DataList ID="dlLinksWithPhotos" runat="server" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="hlist">
                            <div class="photocon">
                                <a href="<%# Eval("Url") %>" target="_blank">
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        id="photo" border='0' src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' />
                                </a>
                            </div>
                            <div id="title">
                                <a href='<%# Eval("Url") %>' target="_blank">
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            <%--<div id="hbar">
                            </div>
                            <div id="btop">
                            </div>
                            <div id="title">
                                <a href='<%# Eval("Url") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            <div id="bbottom">
                            </div>--%>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <!-- ------------------------ dlPhotoAlbums ------------------------ -->
                <asp:DataList ID="dlPhotoAlbums" runat="server" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="hlist">
                            <div class="photocon">
                                <a href='<%# Eval("BuildGalleryLink") %>'>
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        id="photo" border='0' src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' />
                                </a>
                            </div>
                            <div id="title">
                                <a href='<%# Eval("BuildGalleryLink") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            <%--<div id="hbar">
                            </div>
                            <div id="btop">
                            </div>
                            <div id="title">
                                <a href='<%# Eval("BuildGalleryLink") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            <div id="bbottom">
                            </div>--%>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                
                <!-- ------------------------  ------------------------ -->
                <!-- ------------------------ dlPhotos ------------------------ -->
                <asp:DataList ID="dlPhotos" runat="server" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="hlist">
                            <div class="photocon">
                                <a href="<%# ItemsFactory.GetItemsPhotoOriginal(Eval("ItemID"),Eval("PhotoExtension"),Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>"
                                    class="highslide" onclick="return hs.expand(this)">
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        id="photo" border='0' src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' />
                                </a>
                            </div>
                            
                            
                        </div>
                    </ItemTemplate>
                </asp:DataList>

                <!-- ------------------------ dlOffers ------------------------ -->
                <asp:Repeater ID="dlOffers" runat="server">
                    <HeaderTemplate>
                        <div class="OffersSlider">
                         <ul class="rslides" id="spSlider" >

                    </HeaderTemplate>
                    <ItemTemplate>
                       
                            <li style="background-image:url('/Content/UpFiles/_Site/ItemCategories/<%# Eval("CategoryID") %>/Items/<%# Eval("ItemID") %>/Files/<%# Eval("Photo2") %>');">
		                            <div><%# DataBinder.Eval(Container, "DataItem.Title")%>
                                        <br />
                                        <span style="font-size:14px;"><%# General.SubString(DataBinder.Eval(Container, "DataItem.ShortDescription").ToString(), 50, true)%></span>
                                        <br />
                                        <span style="font-style:normal;font-size:16px;"><%# Resources.Items.Price%>:<%# DataBinder.Eval(Container, "DataItem.Price")%> <%=Resources.ItemsOrders.Currency %></span>
                                        <br />
						                <a href='/AddToCart.aspx?id=<%# Eval("ItemID")%>'><%=Resources.ItemsOrders.AddToCart %></a>                                        

		                            </div>
                            </li>
                    
                    </ItemTemplate>
	
                    <FooterTemplate>
                        </ul>
                        </div>

                    </FooterTemplate>
                </asp:Repeater>
                  
                <asp:DataList ID="dlOffers2" runat="server" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="hlist">
                            <div class="photocon">
                                <a href="/Content/UpFiles/_Site/ItemCategories/<%# Eval("CategoryID") %>/Items/<%# Eval("ItemID") %>/Files/<%# Eval("Photo2") %>"
                                    class="highslide" onclick="return hs.expand(this)">
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        id="photo" border='0' src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' />
                                </a>
                            </div>
                            <div id="title">
                                <a  onclick="return hs.expand(this)" class="highslide" href='/Content/UpFiles/_Site/ItemCategories/<%# Eval("CategoryID") %>/Items/<%# Eval("ItemID") %>/Files/<%# Eval("Photo2") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a>
                            </div>
                            
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <!-- ------------------------ dlYoutubes ------------------------ -->
                <asp:DataList ID="dlYoutubes" runat="server" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="hlist">
                            <div class="youtube">
                                <a href="http://www.youtube.com/watch?v=<%# DataBinder.Eval(Container, "DataItem.YoutubeCode") %>">
                                    <img width="120" height="90" src="http://img.youtube.com/vi/<%# DataBinder.Eval(Container, "DataItem.YoutubeCode") %>/1.jpg"></a>
                            </div>
                            <div id="hbar">
                            </div>
                            <%--<div id="btop">
                            </div>--%>
                            <div id="title">
                                <%# DataBinder.Eval(Container, "DataItem.Title")%></div>
                            <%-- <div id="bbottom">
                            </div>--%>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <!-- ------------------------ dlYoutubeVideo ------------------------ -->
                <asp:DataList ID="dlYoutubeVideo" runat="server" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="hlist">
                            <div class="photocon">
                                <a href='<%# Eval("BuildLink") %>'
                                    title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        width="<%#SiteSettings.Photos_HListWidth %>" height="<%#SiteSettings.Photos_HListHeight %>"
                                        src="http://img.youtube.com/vi/<%# Eval("YoutubeCode") %>/1.jpg" />
                                </a>
                            </div>
                            <div id="title">
                                <a  href='<%# Eval("BuildLink") %>'
                                    title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            <%--<div id="hbar">
                            </div>
                            <div id="btop">
                            </div>
                            <div id="title">
                                <a href='<%# Eval("BuildLink") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            <div id="bbottom">
                            </div>--%>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <!-- ------------------------  ------------------------ -->
                <!-- ------------------------ dlTitleOnly ------------------------ -->
                <asp:Repeater ID="dlTitleOnly" runat="server">
                    <ItemTemplate>
                        <div id="vlist">
                            <div class="bol">
                            </div>
                            <div class="data-full">
                                <a class="title" href='<%# Eval("BuildLink") %>'
                                    title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                    <%# General.SubstringByChars(DataBinder.Eval(Container, "DataItem.Title").ToString(), 60)%></a>
                                <br />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlTitleWithDate ------------------------ -->
                <asp:Repeater ID="dlTitleWithDate" runat="server">
                    <ItemTemplate>
                        <div id="vlist">
                            <div class="bol">
                            </div>
                            <div class="data-full">
                                <div class="title-o">
                                    <a class="title" href='<%# Eval("BuildLink") %>'
                                        title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# General.SubstringByChars(DataBinder.Eval(Container, "DataItem.Title").ToString(), 60)%></a></div>
                                <div class="title-d">
                                    <%# ((DateTime)DataBinder.Eval(Container, "DataItem.ItemDate")).ToLongDateString()%></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlTitleDateDescription ------------------------ -->
                <asp:Repeater ID="dlTitleDateDescription" runat="server">
                    <ItemTemplate>
                        <div id="vlist">
                            <div id="datafull">
                                <img src="/Content/images/spacer.gif" alt="" class="NP-box-bol">
                                <h2>
                                    <a href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# General.SubStringByWords(DataBinder.Eval(Container, "DataItem.Title").ToString(), 10,true)%></a></h2>
                                <div class="date">
                                    <%# General.ConvertDateToHijri2((DateTime)DataBinder.Eval(Container, "DataItem.Date_Added")) + " "+Resources.User.Mofeq+" " + ((DateTime)DataBinder.Eval(Container, "DataItem.Date_Added")).ToLongDateString() %></div>
                                <div class="breif">
                                    <%# General.SubString(DataBinder.Eval(Container, "DataItem.Description").ToString(), 80, true)%><%--<a class="more" href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'><%# Resources.Items.More %></a>--%></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlTitleDescription ------------------------ -->
                <asp:Repeater ID="dlTitleDescription" runat="server">
                    <ItemTemplate>
                        <div id="vlist">
                            <div id="datafull">
                                <img src="/Content/images/spacer.gif" alt="" class="NP-box-bol">
                                <h2>
                                    <a href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                        <%# General.SubStringByWords(DataBinder.Eval(Container, "DataItem.Title").ToString(), 10,true)%></a></h2>
                                <div class="breif">
                                    <%# General.SubString(DataBinder.Eval(Container, "DataItem.Description").ToString(), 80, true)%><%--<a class="more" href='<%# Eval("BuildLink") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'><%# Resources.Items.More %></a>--%></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlTitleWithDescriptionExpandable ------------------------ -->
                <asp:Repeater ID="dlTitleWithDescriptionExpandable" runat="server">
                    <ItemTemplate>
                        <div class="menuheader expandable">
                            <%# DataBinder.Eval(Container, "DataItem.Title")%>
                        </div>
                        <div class="categoryitems">
                            <div class="items_contents_body">
                                <%# General.SubstringByChars(DataBinder.Eval(Container, "DataItem.Description").ToString(), 60)%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlDescriptionOnly ------------------------ -->
                <asp:Repeater ID="dlDescriptionOnly" runat="server">
                    <ItemTemplate>
                        <div class="latest_item">
                            <div class="breif" style="width: 98%">
                                <%# DataBinder.Eval(Container, "DataItem.Description")%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlTitleWithPhoto ------------------------ -->
                <asp:DataList ID="dlTitleWithPhoto" runat="server" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="hlist">
                            <div class="photocon">
                                <a href='<%# Eval("BuildLink") %>'>
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        id="photo" border='0' src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' />
                                </a>
                            </div>
                            <div id="title">
                                <a href='<%# Eval("BuildLink") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            <%--<div id="hbar">
                            </div>
                            <div id="btop">
                            </div>
                            <div id="title">
                                <a href='<%# Eval("BuildLink") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            <div id="bbottom">
                            </div>--%>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
<!-- ------------------------ dlTitleWithPhoto ------------------------ -->
                <asp:Repeater ID="dlVProducts" runat="server">
                    <HeaderTemplate>
                        <table class="gridStyle">
                            <tr class="gridHead">
                                <td class="GridetitleN01_Z" style="width:25px;"></td>
                                <td class="GridetitleN02_Z" style="width:634px;"></td>
                               <td class="GridetitleN03_Z">
                                    <%# Resources.Items.Price%>
                                </td>
                               
                                <td class="GridetitleN05_Z">
                                    <%# Resources.ItemsOrders.AddToCart %></td>
                            </tr>
                            
                            
                    </HeaderTemplate>
                    <FooterTemplate>
                                                </table>

                    </FooterTemplate>
                    <ItemTemplate>
                        <tr class="gridItemData">
                            <td class="GridDataN01_Z"  style="width:25px;"></td>
                                <td  id='dip<%# Eval("ItemID")%>' class="GridDataN02_Z"  style="width:634px;">
                                    <div><%# DataBinder.Eval(Container, "DataItem.Title")%></div>
                                    
                                    <script>BuildBopUpForElement('dip<%# Eval("ItemID")%>', '', '<%# DataBinder.Eval(Container, "DataItem.ShortDescription").ToString().Replace("\r\n","")%>');</script>
                                    
                                </td>
                            <td class="GridDataN03_Z">
                                <%# DataBinder.Eval(Container, "DataItem.Price")%> <%=Resources.ItemsOrders.Currency %>
                            </td>
                           
                            <td class="GridDataN05_Z">
                               <a href='/AddToCart.aspx?id=<%# Eval("ItemID")%>'><%=Resources.ItemsOrders.AddToCart %></a>

                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- ------------------------ dlTitleWithPhoto ------------------------ -->
                <asp:DataList ID="dlVProducts_old" runat="server" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="hlist">
                            <div class="photocon">
                                <a href='<%# Eval("BuildLink") %>'>
                                    <img title='<%# DataBinder.Eval(Container, "DataItem.Title") %>' alt='<%# DataBinder.Eval(Container, "DataItem.Title") %>'
                                        id="photo" border='0' src='<%# ItemsFactory.GetItemsPhotoThumbnail(Eval("ItemID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' />
                                </a>
                            </div>
                            <div id="title">
                                <a href='<%# Eval("BuildLink") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a>
                                <br />
                                <%# DataBinder.Eval(Container, "DataItem.Price")%> <%# Resources.ItemsOrders.Currency %>
                                <br />
                                <a href='/AddToCart.aspx?id=<%# Eval("ItemID")%>'><%# Resources.ItemsOrders.AddToCart %></a>
                            </div>
                            <%--<div id="hbar">
                            </div>
                            <div id="btop">
                            </div>
                            <div id="title">
                                <a href='<%# Eval("BuildLink") %>'>
                                    <%# DataBinder.Eval(Container, "DataItem.Title")%></a></div>
                            <div id="bbottom">
                            </div>--%>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </td>
    </tr>
    <tr runat="server" id="trPagerContainer">
        <td class="PagerControl" align="center">
            <cc1:OurPager ID="pager" runat="server" OnPageIndexChang="Pager_PageIndexChang">
            </cc1:OurPager>
        </td>
    </tr>
</table>
