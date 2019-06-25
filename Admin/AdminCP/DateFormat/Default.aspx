<%@ Page Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Admin_Modules_AppSettings_HijriDate" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    التحكم فى التاريخ الهجرى
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text" style="width:170px">
                            التاريخ الهجري: تقويم الخادم
                        </td>
                        <td class="Control">
                            <asp:Label ID="lblHijriDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            التاريخ الهجري: التقويم المعدل
                        </td>
                        <td class="Control">
                            <asp:Label ID="lblHijriDate2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            تعديل تقويم الموقع: الفرق بالأيام (يمكن استخدام علامة السالب -)
                        </td>
                        <td class="Control">
                            <asp:TextBox ID="txtOffset" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Button ID="Button1" runat="server" SkinID="btnSave" ValidationGroup="GG"
                                CssClass="inpt_but120" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
