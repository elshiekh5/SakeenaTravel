<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Default.ascx.cs" Inherits="AdminCP__UserControls_Voting_VoteQuestions_Default" %>
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
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Label ID="lblResult" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="GridControl" align="center" colspan="2">
                            <asp:DataGrid ID="dgControl" runat="server" SkinID="GridViewSkin" OnDeleteCommand="dgControl_DeleteCommand"
                                OnItemDataBound="dgControl_ItemDataBound" OnItemCommand="dgControl_ItemCommand">
                                <Columns>
                                    <asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="QuestionText" ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleTitle"
                                        HeaderText="<%$ Resources:Vote,QuestionText %>"></asp:BoundColumn>
                                    <asp:TemplateColumn ItemStyle-Width="120px" ItemStyle-CssClass="ItemStyleButton"
                                        HeaderText="<%$ Resources:Vote,Status %>">
                                        <ItemTemplate>
                                            <asp:Image ID="imgStatus" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:Vote,Activate %>">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lbtnOpen" SkinID="ibtnGridVoteOpen" CommandName="Open" runat="server">
                                            </asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:Vote,Close %>">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lbtnClose" SkinID="ibtnGridVoteClose" CommandName="Close" runat="server">
                                            </asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:Vote,Result %>">
                                        <ItemTemplate>
                                            <a id="aViewResult" runat="server"  href='<%# "/Website/AdditionalModules/Vote/flashAdmin.aspx?id="+Eval("QuesID")%>'
                                                onclick="return hs.htmlExpand(this, { objectType: 'iframe', minWidth: '610'} )" class='Link'>
                                                <img src="/Content/AdminDesign/global/images/Icons/polls.png" style="border-width:0px; width:16px; height:16px;" alt="<%# Resources.Vote.Result %>" /></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Update %>">
                                        <ItemTemplate>
                                            <a id="aUpdate" runat="server" href='<%# "Edit.aspx?id="+DataBinder.Eval(Container.DataItem, "QuesID") %>'
                                                class='Link'>
                                                <img src="/Content/AdminDesign/global/images/Icons/edit.png" style="border-width:0px" alt="<%#Resources.AdminText.Update%>" /></a>
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