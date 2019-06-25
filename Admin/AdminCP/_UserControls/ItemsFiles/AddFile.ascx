<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddFile.ascx.cs" Inherits="UserControls_Items_AddFile" %>

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
                        <asp:Label ID="lblItemTitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text">
                    <asp:Label ID="lblFileText" runat="server" Text="<%$ Resources:ItemsFiles,ItemFileType_File %>" />
                        <span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span>
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuPhoto" runat="server" CssClass="Controls" />
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFileExtension" runat="server"
                            ErrorMessage="*" ControlToValidate="fuPhoto" ValidationGroup="ItemsFiles" Text="*"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="ItemsFiles" onclick="btnSave_Click"  SkinID="btnSave"  />
                    </td>
                </tr>
                <tr>
                    <td class="SubHeader" colspan="2">
                        <asp:Label ID="Label3" runat="server" Text="<%$ Resources:ItemsFiles,FilesAdded %>" />
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <div style="direction: rtl;">
                            <asp:DataList ID="dlPhotos" runat="server" RepeatColumns="4" Width="100%" OnDeleteCommand="dlPhotos_DeleteCommand"
                                OnItemDataBound="dlPhotos_ItemDataBound">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td align="center">
                                                    <a runat="server" href='<%# ItemsFilesEntity.GetFilePath(Eval("FileID"),Eval("FileExtension"),Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID"),Eval("ItemID"))%>'><%= Resources.ItemsFiles.Download %></a>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="lbtnDelete" SkinID="ibtnGridDelete" CommandName="Delete" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList></div>
                    </td>
                </tr>
               
            </table>
        </td>
    </tr>
</table>
