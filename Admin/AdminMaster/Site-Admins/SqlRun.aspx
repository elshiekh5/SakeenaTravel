<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SqlRun.aspx.cs"
    Inherits="MasterAdmin_SqlRun" %>


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
                        <td class="Result" align="center" colspan="2">
                            Your Query
                        </td>
                    </tr>
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:TextBox MaxLength="10" ID="txtSql" runat="server" CssClass="DetailsControls" ValidationGroup="SqlRun"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="Result" align="center" colspan="2">
                            <asp:Button ID="btnExecute" runat="server" ValidationGroup="SqlRun" OnClick="btnExecute_Click"
                                SkinID="btnExecute" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
