<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddPhoto.ascx.cs" Inherits="UserControls_Items_AddPhoto" %>

<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td>
            <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </td>
                </tr>
                
                <tr id="trItems" runat="server" >
					<td class="text"><asp:Label ID="lblItems" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList id="ddlItems" runat="server" CssClass="Controls" 
                            AutoPostBack="True" onselectedindexchanged="ddlItems_SelectedIndexChanged" ></asp:DropDownList>
						<asp:RequiredFieldValidator  id="rfvCategoryID" ValidationGroup="ItemsFiles" ControlToValidate="ddlItems"  Display="Dynamic" runat="server" ErrorMessage="*" InitialValue="-1"  Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				 <tr id="TrTitle" runat=server>
                    <td class="text">
                        <asp:Label ID="Label1" Text="<%$ Resources:ItemsFiles,PhotoComment %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtTitle" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="*" ControlToValidate="txtNo" ValidationGroup="ItemsFiles" Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat=server>
                    <td class="text">
                        <asp:Label ID="lblFileText" runat="server" Text="<%$ Resources:ItemsFiles,Photo %>" /><span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span>
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuPhoto" runat="server" CssClass="Controls" />
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvPhotoExtension" runat="server"
                            ErrorMessage="*" ControlToValidate="fuPhoto" ValidationGroup="ItemsFiles" Text="*"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="ItemsFiles" onclick="btnSave_Click"  SkinID="btnSave"  />
                    </td>
                </tr>
                
                <tr>
                    <td class="SubHeader" colspan="2">
                       <asp:Label ID="Label3" runat="server" Text="<%$ Resources:ItemsFiles,PhotosAdded %>" />
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <div style="direction: rtl;">
                            <asp:DataList ID="dlPhotos" runat="server" RepeatColumns="2" Width="100%" OnDeleteCommand="dlPhotos_DeleteCommand"
                                OnItemDataBound="dlPhotos_ItemDataBound" RepeatDirection="Horizontal">
                                <ItemTemplate>

                                <table id="PhotoContainer" runat="server" class="PhotoContainer" cellspacing="0" align="center"
                            cellpadding="0" border="0">
                            <tr id="trImgPhoto" runat="server">
                                <td class="Image" align="center">
                                     <a id="ancor" href='<%# ItemsFilesEntity.GetPhotoPath(PhotoTypes.Big,Eval("FileID"),Eval("FileExtension"),Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID"),Eval("ItemID"))%>'
                                                        class="highslide" onclick="return hs.expand(this);">
                                        <asp:Image runat="server" ID="imgPhoto" ImageUrl='<%# ItemsFilesEntity.GetPhotoPath(PhotoTypes.Thumb,Eval("FileID"),Eval("PhotoExtension"),Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID"),Eval("ItemID")) %>'
                                                             ToolTip="<%$ Resources:AdminText,ClickToEnlage %>"
                                                            ImageAlign="Middle" />
                                    </a>
                                    <br /><%# Eval("Title")%>
                                </td>
                            </tr>
                            <tr id="tr1" runat="server">
                                <td class="Imagetext">
                                    <asp:Button  runat="server" ValidationGroup="Items" ID="lbtnDelete"  CommandName="Delete"
                                        CssClass="btnDeletePhoto" />
                                </td>
                            </tr>
                            
                        </table>
                                <div style="height:10px;"></div>
                                    
                                </ItemTemplate>
                            </asp:DataList></div>
                    </td>
                </tr>
               
            </table>
        </td>
    </tr>
</table>
