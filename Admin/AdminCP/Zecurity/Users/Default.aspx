<%@ Page Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="AdminCP_Zecurity_Users_Default"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblResult" runat="server" ></asp:Label>
                    </td>
                </tr>
                    <tr>
                        <td class="GridControl" align="center" colspan="2">
                            <asp:DataGrid ID="dgUsres" runat="server" SkinID="GridViewSkin" OnDeleteCommand="dgUsres_DeleteCommand"
                                OnItemDataBound="dgUsres_ItemDataBound">
                                <Columns>
                                    <asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" HeaderText="<%$ Resources:AdminText,Index %>">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="UserName" ItemStyle-Width="100%" ItemStyle-CssClass="ItemStyleTitle"
                                        HeaderText="<%$ Resources:Zecurity,UserNameLabelText %>"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="false" DataField="Email" HeaderText="<%$ Resources:Zecurity,EmailLabelText %>" />
                                    <asp:TemplateColumn Visible="false" HeaderText="Creation Date">
                                        <ItemTemplate>
                                            <%# Eval("CreationDate")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="<%$ Resources:Zecurity,ZecurityUserAccountActive %>">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" OnCheckedChanged="ToggleApproved" AutoPostBack="True"
                                                ID="IsApproved" Checked='<%# Eval("IsApproved") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="<%$ Resources:Zecurity,ZecurityUserExist %>" Visible="false">
                                        <ItemTemplate>
                                            <%# Eval("IsOnline") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    
                                  <asp:TemplateColumn ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Update %>">
                                    <ItemTemplate>
                                        <a href='<%# "Edit.aspx?id="+DataBinder.Eval(Container.DataItem, "ProviderUserKey") %>' class='Link'>
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
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
