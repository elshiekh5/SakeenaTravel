<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItemVideos.ascx.cs" Inherits="UserControls_Items_ItemPhotos" %>

<asp:DataList ID="dlVideosPhotos" runat="server" RepeatColumns="3" Width="100%" >
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td align="center">
                                                <div class="Image" style="width: 100%">
                                                    <a runat="server" id="ancor" href='<%# ItemsFilesEntity.GetFilePath(Eval("FileID"),Eval("FileExtension"),Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID"),Eval("ItemID"))%>' >
                                                         <img src="/Design/Images/New/Ar/vedioo.jpg" />
                                                        
                                                    </a>
                                                </div>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>