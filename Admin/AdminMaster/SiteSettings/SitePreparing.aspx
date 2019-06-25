<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SitePreparing.aspx.cs"
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
                            Õ–› «·»Ì«‰«  Ê«· ÂÌ∆… ·„Êﬁ⁄ ÃœÌœ
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width:170px;">
                            Õ–› «·»Ì«‰«  Ê«·„·›«  Ê«·„” Œœ„Ì‰
                        </td>
                        <td class="Control">
                            <asp:Button ID="btnDeleteAllData" runat="server" ValidationGroup="SiteSettings" OnClick="btnDeleteAllData_Click"
                                SkinID="btnPrepare" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Õ–› «·»Ì«‰«  Ê«·„·›«  ›ﬁÿ
                        </td>
                        <td class="Control">
                            <asp:Button ID="btnDeleteAllDataWithoutUsers" runat="server" ValidationGroup="SiteSettings" OnClick="btnDeleteAllDataWithoutUsers_Click"
                                SkinID="btnPrepare" />
                        </td>
                    </tr>
                     <tr>
                        <td class="text">
                            Õ–› «·„” Œœ„Ì‰ ›ﬁÿ
                        </td>
                        <td class="Control">
                            <asp:Button ID="btnDeleteAllOldUsers" runat="server" ValidationGroup="SiteSettings" OnClick="btnDeleteAllOldUsers_Click"
                                SkinID="btnPrepare" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ≈÷«›… »Ì«‰«   Ã—Ì»Ì…
                        </td>
                        <td class="Control">
                            <asp:Button ID="btnAddTestingData" runat="server" 
                                ValidationGroup="SiteSettings"                                
                                SkinID="btnPrepare" onclick="btnAddTestingData_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
