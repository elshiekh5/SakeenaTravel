<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="CommentsSettings.aspx.cs"
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
                            ������� ���������
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ����� ���������
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbComments_Enable" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ��� ������ ������ �����<span class="RequiredField"><asp:Label runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox MaxLength="10" ID="txtComments_AllowDays" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvValue" runat="server" ErrorMessage="*"
                                ControlToValidate="txtComments_AllowDays" ValidationGroup="SiteSettings" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ��� ��������� �������� ���� ����� <span class="RequiredField">
                                <asp:Label ID="Label2" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox MaxLength="10" ID="txtComments_RefuseLimmets" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage="*" ControlToValidate="txtComments_RefuseLimmets" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ��� ��������� �� ������ ������� <span class="RequiredField">
                                <asp:Label ID="Label3" runat="server" Text="*" /></span>
                        </td>
                        <td class="Control">
                            <asp:TextBox MaxLength="10" ID="txtComments_CommentsPerPage" runat="server" CssClass="Controls"
                                ValidationGroup="SiteSettings"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                ErrorMessage="*" ControlToValidate="txtComments_CommentsPerPage" ValidationGroup="SiteSettings"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ����� �������
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbComments_HasCommentTitle" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ��� ���� �������
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbComments_HasCountry" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            ������ ���������� ����� �������</span>
                        </td>
                        <td class="Control">
                            <asp:CheckBox ID="cbComments_HasSenderEmail" CssClass="Controls" ValidationGroup="SiteSettings"
                                runat="server" />
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
