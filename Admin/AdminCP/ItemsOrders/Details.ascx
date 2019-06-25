<%@ Control Language="c#" AutoEventWireup="true" CodeFile="Details.ascx.cs" Inherits="Items_GetAll" %>

<%@ Register src="OrderData.ascx" tagname="OrderData" tagprefix="uc2" %>

<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td>
            <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <uc2:OrderData ID="OrderData1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="GridControl" align="center" colspan="2">
                        <asp:DataGrid ID="dgItems" runat="server" SkinID="GridViewSkin" OnDeleteCommand="dgItems_DeleteCommand"
                            OnItemDataBound="dgItems_ItemDataBound">
                            <Columns>
                                <asp:BoundColumn ItemStyle-Width="20" ItemStyle-CssClass="ItemStyle" HeaderText="<%$ Resources:AdminText,Index %>"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Title" ItemStyle-Width="75%" ItemStyle-CssClass="ItemStyleTitle" HeaderText=""></asp:BoundColumn>
                                <asp:BoundColumn DataField="BarCode"  ItemStyle-CssClass="ItemStyleTitle" HeaderText=""></asp:BoundColumn>
                                <asp:BoundColumn DataField="ByUnit"  ItemStyle-CssClass="ItemStyleTitle" HeaderText=""></asp:BoundColumn>
                                <asp:BoundColumn DataField="ByCarton"  ItemStyle-CssClass="ItemStyleTitle" HeaderText=""></asp:BoundColumn>
                                <asp:BoundColumn DataField="Quantity"  ItemStyle-CssClass="ItemStyleTitle" HeaderText=""></asp:BoundColumn>
                                <asp:TemplateColumn Visible="false" ItemStyle-Width="20px" ItemStyle-CssClass="ItemStyleButton" HeaderText="<%$ Resources:AdminText,Delete %>">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lbtnDelete" SkinID="ibtnGridDelete" CommandName="Delete" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </td>
                </tr>
             
            </table>
        </td>
    </tr>
</table>
