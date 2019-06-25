<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Export.ascx.cs" Inherits="AdminCP__UserControls_UsersData_Export" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td class="Result" align="center" colspan="2">
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="GridControl" align="center" colspan="2">
            <asp:DataGrid AutoGenerateColumns="False" AllowSorting="false" ID="dgUsers" runat="server"
                SkinID="GridViewSkin" BorderWidth="1" OnItemDataBound="dgUsers_ItemDataBound">
                <Columns>
                    <asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" HeaderText="<%$ Resources:AdminText,Index %>">
                    </asp:BoundColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <%# Eval("Name")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div dir="ltr">
                                <%# Eval("Email")%>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <%# GetCategoryText(Eval("CategoryID"))%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <%# Eval("JobText")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <%# Eval("CountryName")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <%# GetCityText(Eval("CityName"), Eval("UserCityName"))%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <%# Eval("Company")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <%# GetActivitiesIDText(Eval("ActivitiesID"))%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div dir="ltr">
                                <%# Eval("Url")%>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div dir="ltr">
                                <%# Eval("Tel")%>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <div dir="ltr">
                                <%# Eval("Mobile")%>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <div dir="ltr">
                                <%# Eval("Fax")%>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <div dir="ltr">
                                <%# Eval("MailBox")%>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <center>
                                <img alt="<%# GetBooleanText(Eval("HasEmailService"))%>" src="<%# SiteSettings.Site_WebsiteDomain+General.GetBoleanPhoto(Eval("HasEmailService")) %>" />
                            </center>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <center>
                                <img alt="<%# GetBooleanText(Eval("HasEmailService"))%>" src="<%# SiteSettings.Site_WebsiteDomain+General.GetBoleanPhoto(Eval("HasEmailService")) %>" />
                            </center>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
        </td>
    </tr>
</table>
