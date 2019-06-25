<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="ZecutitySettings.aspx.cs"
    Inherits="AdminSiteSettings_Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Label ID="lblResult" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHeader" colspan="2">
                            ≈⁄œ«œ«  „ÊœÊÌ· √„‰ «·‰Ÿ«„
                        </td>
                    </tr>
                      
                     <tr>
                        <td class="text">
                            UnSafePathes<span class="RequiredField">
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtZecurityUnSafePathes" runat="server" CssClass="ControlsLong" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td class="text">
                            AdminFolder<span class="RequiredField">
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtZecurityAdminFolder" runat="server" CssClass="ControlsLong" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td class="text">
                            AdminDefaultPage<span class="RequiredField">
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtZecurityAdminDefaultPage" runat="server" CssClass="ControlsLong" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    
                     <tr>
                        <td class="text">
                            ErrorPagePath<span class="RequiredField">
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtZecurityErrorPagePath" runat="server" CssClass="ControlsLong" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="SiteSettings" OnClick="btnSave_Click"
                                SkinID="btnSave" />
                            <asp:LinkButton ID="lbSecurityBuilder" runat="server" 
                            onclick="lbSecurityBuilder_Click">≈⁄œ«œ „ÊœÌÊ· «·”ﬂÌÊ—Ì Ì</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
