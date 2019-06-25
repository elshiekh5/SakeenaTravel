
<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="AdmininstrationSettings.aspx.cs"
    Inherits="AdminSiteSettings_AdmininstrationSettings" %>

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
                            ≈⁄œ«œ«  «·≈‘—«›
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width:165px;">
                        Has Admin Email
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbAdmininstration_HasAdminEmail" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <td class="text">
                        Has Admin Bcc Email
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbAdmininstration_HasAdminBccEmail" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr id="trCountryID" runat="server">
                    <td class="text">
                        «·œÊ·… ·√”«”Ì…
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlSystemCountries" runat="server" CssClass="Controls" ValidationGroup="SiteSettings" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvCountryID"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="ddlSystemCountries"
                            InitialValue="-1" ValidationGroup="SiteSettings" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
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
