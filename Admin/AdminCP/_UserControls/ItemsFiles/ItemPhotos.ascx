<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItemPhotos.ascx.cs" Inherits="UserControls_Items_ItemPhotos" %>

<asp:DataList ID="dlPhotos" runat="server" RepeatColumns="3" Width="100%" >
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td align="center">
                                                <div class="Image" style="width: 100%">
                                                    <a runat="server" id="ancor" href='<%# ItemsFilesEntity.GetPhotoPath(PhotoTypes.Big,Eval("FileID"),Eval("PhotoExtension"),Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID"),Eval("ItemID"))%>'
                                                        class="highslide" onclick="return hs.expand(this)">
                                                        <asp:Image runat="server" ID="imgPhoto" ImageUrl='<%# ItemsFilesEntity.GetPhotoPath(PhotoTypes.Thumb,Eval("FileID"),Eval("PhotoExtension"),Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID"),Eval("ItemID")) %>'
                                                            BorderColor="Black" BorderWidth="2" hspace="25" CssClass="dimage" ToolTip="<%$ Resources:AdminText,ClickToEnlage %>"
                                                            ImageAlign="Middle" />
                                                    </a>
                                                </div>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>