<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Export.ascx.cs" Inherits="App_Controls_Messages_Admin_Export" %>

<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td>
            <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr id="trLanguages" runat="server">
                    <td class="text">
                        <%= Resources.AdminText.Language %><span class="RequiredField"><asp:Label ID="Label3" runat="server" Text="*" /></span>
                    </td>
                    <td class="control">
                        <asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls" />
                    </td>
                </tr>
                <tr runat="server" id="trType">
                    <td class="text">
                        <asp:Label ID="lblType" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="Controls">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
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
                        <asp:DataGrid AutoGenerateColumns="False" AllowSorting="false" ID="dgMessages" runat="server"
                            SkinID="GridViewSkin">
                            <Columns>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# GetName(Eval("Name"))%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <div dir="ltr">
                                            <%# Eval("EMail")%>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# Eval("CountryName")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# Eval("CityName")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# Eval("UserCityName")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# Eval("Company")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# GetJobIDText(Eval("JobID"))%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# Eval("JobText")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# Eval("EmpNo")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        
                                            <%# Eval("JobTel")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# GetActivitiesIDText(Eval("ActivitiesID"))%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <div dir="ltr">
                                        
                                            <%# Eval("Url")%>
                                        </div>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="left">
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
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <div dir="ltr">
                                            <%# Eval("ZipCode")%>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# Eval("Address")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# GetAgeText( Eval("AgeRang"))%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# GetGenderText(Eval("Gender"))%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# Eval("BirthDate")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# GetSocialStatusText(Eval("SocialStatus"))%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# GetEducationLevelText(Eval("EducationLevel"))%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                            <%# GetTypeText(Eval("Type"))%>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <center>
                                             <img alt="<%# GetBooleanText(Eval("HasSmsService"))%>" src="<%# SiteSettings.Site_WebsiteDomain+General.GetBoleanPhoto(Eval("HasSmsService")) %>" />
                                        </center>
                                            
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <center>
                                             <img alt="<%# GetBooleanText(Eval("HasEmailService"))%>" src="<%# SiteSettings.Site_WebsiteDomain+General.GetBoleanPhoto(Eval("HasEmailService")) %>" />
                                        </center>
                                            
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn >
                                    <ItemTemplate>
                                        
                                            <%# Eval("Date_Added")%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <center>
                                             <img alt="<%# GetBooleanText(Eval("IsSeen"))%>" src="<%# SiteSettings.Site_WebsiteDomain+General.GetBoleanPhoto(Eval("IsSeen")) %>" />
                                        </center>
                                            
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <center>
                                             <img alt="<%# GetBooleanText(Eval("IsReplied"))%>" src="<%# SiteSettings.Site_WebsiteDomain+General.GetBoleanPhoto(Eval("IsReplied")) %>" />
                                        </center>
                                            
                                        
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <center>
                                             <img alt="<%# GetBooleanText(Eval("IsAvailable"))%>" src="<%# SiteSettings.Site_WebsiteDomain+General.GetBoleanPhoto(Eval("IsAvailable")) %>" />
                                        </center>
                                            
                                        
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
