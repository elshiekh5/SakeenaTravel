<%@ Control Language="C#" AutoEventWireup="true" Inherits="DCCMSNameSpace.ReadyUserControls.UsersData_GetAllBaseControl" %>
<%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>

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
                    <td colspan="2" align="center" >
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
            <asp:Label ID="lblResult" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height: 100%;" valign="top" align="center" colspan="2">
            <div id='lists'>
                <!-- ------------------------ dlUsers ------------------------ -->
                <asp:DataList  ID="dlUsers" runat="server" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <div id="hlist">
                            <div class="photocon">
                                <a href='<%# "/"+Eval("UserName")+"/SubSite/default.aspx" %>'>
                                    <img id="photo" border='0' src='<%# UsersDataFactory.GetUserPhotoThumbnail(Eval("UserProfileID"), Eval("PhotoExtension"), SiteSettings.Photos_HListWidth, SiteSettings.Photos_HListWidth,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID")) %>'
                                        alt='<%# Eval("Name") %>' title='<%# Eval("Name") %>' />
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
                            <div id="title" style="width: 143px;">
                                <a href='<%# "/"+Eval("UserName")+"/SubSite/default.aspx" %>'>
                                    <%# Eval("Name") %></a></div>
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


