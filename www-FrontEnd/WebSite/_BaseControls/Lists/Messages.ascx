<%@ Control Language="C#" AutoEventWireup="true" Inherits="DCCMSNameSpace.ReadyUserControls.Messages_GetAllBaseControl" %>
<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
<table id="Table1" style="width: 100%;" cellspacing="0" cellpadding="0" border="0"
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
        <td class="Result" align="center" colspan="2">
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height: 100%;" valign="top" align="center" colspan="2">
            <!-- ------------------------ dlMessages ------------------------ -->
            <asp:Repeater ID="dlMessages" runat="server">
                <ItemTemplate>
                    <div id="vlist">
                        <div id="datafull">
                            <img src="/Content/images/spacer.gif" alt="" class="NP-box-bol">
                            <h2>
                                <a href='<%# "Details.aspx?id="+Eval("MessageID") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
                                    <%# General.SubStringByWords(DataBinder.Eval(Container, "DataItem.Title").ToString(), 10,true)%></a></h2>
                            <div class="date">
                                <%# General.ConvertDateToHijri2((DateTime)DataBinder.Eval(Container, "DataItem.Date_Added")) + " "+Resources.User.Mofeq+" " + ((DateTime)DataBinder.Eval(Container, "DataItem.Date_Added")).ToLongDateString() %></div>
                            <div class="breif">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Reply").ToString(), 80, true)%><%--<a class="more" href='<%# "Details.aspx?id="+Eval("MessageID") %>' title='<%# DataBinder.Eval(Container, "DataItem.Title") %>'><%# Resources.Items.More %></a>--%></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="dlMotakhasessen" runat="server">
                <HeaderTemplate>
                    <div class="gridStyle">
                        <div class="gridHead">
                            <div class="GridetitleN01_Z" style="width: 285px">
                                «·«”„</div>
                            <div class="GridetitleN02_Z">
                                «·„ƒÂ· «·⁄·„Ì
                            </div>
                            <div class="GridetitleN03_Z" style="width: 120px">
                                «·œÊ·…
                            </div>
                        </div>
                        <div class="gridItems">
                </HeaderTemplate>
                <FooterTemplate>
                    </div> </div>
                </FooterTemplate>
                <ItemTemplate>
                    <div class="gridItemData">
                        <div class="GridDataN01_Z" style="width: 285px">
                            <a href="<%# "Data.aspx?id="+Eval("MessageID") %>" class="title">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.Name"), 1000, true)%></a>
                        </div>
                        <div class="GridDataN02_Z">
                            <%# GetEducationLevelText(DataBinder.Eval(Container, "DataItem.EducationLevel"))%>
                        </div>
                        <div class="GridDataN02_Z" style="width: 120px">
                            <%# DataBinder.Eval(Container, "DataItem.CountryName")%>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="dlMotakhasessen2" runat="server">
                <ItemTemplate>
                    <div class="latest_item">
                        <div class="latset_text" style="width: 100%">
                            <table>
                                <tr>
                                    <td>
                                        <b>«·≈”„ </b>
                                    </td>
                                    <td>
                                        : <a href="<%# "Data.aspx?id="+Eval("MessageID") %>" class="title">
                                            <%# General.SubString(DataBinder.Eval(Container, "DataItem.Name"), 1000, true)%></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>«·„ƒÂ· «·⁄·„Ì </b>
                                    </td>
                                    <td>
                                        :
                                        <%# GetEducationLevelText(DataBinder.Eval(Container, "DataItem.EducationLevel"))%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>«·œÊ·… </b>
                                    </td>
                                    <td>
                                        :
                                        <%# DataBinder.Eval(Container, "DataItem.CountryName")%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:DataList Width="100%" ID="dlUsersArticles" runat="server">
                <ItemTemplate>
                    <div id="vlist">
                        <div id="photo">
                            <a href="<%# "Details.aspx?id="+Eval("MessageID")  %>">
                                <img class="photo" src='<%# MessagesFactory.GetPhotoThumbnail(Eval("MessageID"),Eval("PhotoExtension"),SiteSettings.Photos_VListWidth,SiteSettings.Photos_VListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>' /></a>
                        </div>
                        <div id="data">
                            <h2>
                                <a href="<%# "Details.aspx?id="+Eval("MessageID")  %>">
                                    <%# General.SubstringByChars(DataBinder.Eval(Container, "DataItem.Title").ToString(), 60)%></a></h2>
                            <%--<div class="date">
                                    <%# General.ConvertDateToHijri2((DateTime)DataBinder.Eval(Container, "DataItem.Date_Added")) + " "+ Resources.User.Mofeq +" "+ ((DateTime)DataBinder.Eval(Container, "DataItem.Date_Added")).ToLongDateString() %></div>--%>
                            <div class="breif">
                                <%# General.SubString(DataBinder.Eval(Container, "DataItem.ShortDescription").ToString(), 75, true)%><%--<a class="more" href="<%# "Details.aspx?id="+Eval("ItemID") %>"><%# Resources.Items.More %></a>--%></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:DataList Width="100%" ID="dlConsultants" runat="server">
                <ItemTemplate>
                    <div id="vlist">
                        <div class="bol">
                        </div>
                        <div class="data-full">
                            <a class="title" href="<%# "Details.aspx?id="+Eval("MessageID") %>">
                                <%# General.SubstringByChars(DataBinder.Eval(Container, "DataItem.Title").ToString(), 60)%></a>
                            <br />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
    <tr runat="server" id="trPagerContainer">
        <td class="PagerControl" align="center">
            <cc1:OurPager ID="pager" runat="server" OnPageIndexChang="Pager_PageIndexChang">
            </cc1:OurPager>
        </td>
    </tr>
</table>
<%-- </ContentTemplate>
</asp:UpdatePanel>--%>
