<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="VoteSettings.aspx.cs"
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
                            ≈⁄œ«œ«  «· ’ÊÌ 
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="text">
                            ≈€·«ﬁ  ﬂ—«— «· ’ÊÌ  ⁄‰ ÿ—Ìﬁ «·ﬂÊﬂÌ<span class="RequiredField"><asp:Label ID="Label49"
                                runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbVote_CloseDuplicateVotingByCookie" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            «ﬁ’Ï ⁄œœ ··≈Œ Ì«—« <span class="RequiredField"><asp:Label ID="Label24" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtVote_MaxChoices" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ImageMaxLength<span class="RequiredField"><asp:Label ID="Label26" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtVote_ImageMaxLength" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ImageMinLength<span class="RequiredField"><asp:Label ID="Label27" runat="server"
                                Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtVote_ImageMinLength" runat="server" CssClass="Controls" ValidationGroup="SiteSettings"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="SiteSettings" OnClick="btnSave_Click"
                                SkinID="btnSave" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
