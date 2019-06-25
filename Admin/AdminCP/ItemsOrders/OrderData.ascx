<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderData.ascx.cs" Inherits="AdminCP_ItemsOrders_OrderData" %>
<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				 <tr id="trCustomerName" runat="server">
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:ItemsOrders,CustomerName %>" runat="server" /></td>
					<td class="Control">
						<asp:Label ID="lblCustomerName"  runat="server" />
					</td>
				</tr>
    <tr id="trCustomerEmail" runat="server">
					<td class="text"><asp:Label ID="Label4" Text="<%$ Resources:ItemsOrders,CustomerEmail %>" runat="server" /></td>
					<td class="Control">
						<asp:Label ID="lblCustomerEmail"  runat="server" />
					</td>
				</tr>
    <tr id="trCustomerPhone" runat="server">
					<td class="text"><asp:Label ID="Label7" Text="<%$ Resources:ItemsOrders,CustomerPhone %>" runat="server" /></td>
					<td class="Control">
						<asp:Label ID="lblCustomerPhone"  runat="server" />
					</td>
				</tr>
    <tr id="trCustomerMobile" runat="server">
					<td class="text"><asp:Label ID="Label9" Text="<%$ Resources:ItemsOrders,CustomerMobile %>" runat="server" /></td>
					<td class="Control">
						<asp:Label ID="lblCustomerMobile"  runat="server" />
					</td>
				</tr>
    <tr id="trCustomerAddress" runat="server">
					<td class="text"><asp:Label ID="Label11" Text="<%$ Resources:ItemsOrders,CustomerAddress %>" runat="server" /></td>
					<td class="Control">
						<asp:Label ID="lblCustomerAddress"  runat="server" />
					</td>
				</tr>
    <tr id="trDateAdded" runat="server">
					<td class="text"><asp:Label ID="Label6" Text="<%$ Resources:ItemsOrders,DateAdded %>" runat="server" /></td>
					<td class="Control">
						<asp:Label ID="lblDateAdded"  runat="server" />
					</td>
				</tr>
				<tr  id="trStatus" runat="server">
					<td class="text"><asp:Label ID="Label2" Text="<%$ Resources:ItemsOrders,Status  %>" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList  ID="ddlOrderStatus" runat="server" CssClass="Controls" ValidationGroup="ItemsOrders"  >
                            <asp:ListItem Value="0" Text="<%$ Resources:ItemsOrders,Status_0 %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$ Resources:ItemsOrders,Status_1 %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$ Resources:ItemsOrders,Status_2 %>"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<%$ Resources:ItemsOrders,Status_3 %>"></asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
				<tr  id="trComment" runat="server">
					<td class="text"><asp:Label ID="Label3" Text="<%$ Resources:ItemsOrders,Comment %>" runat="server" /></td>
					<td class="Control">
						<asp:TextBox MaxLength="500" id="txtComment" TextMode="MultiLine" runat="server" CssClass="Controls" ValidationGroup="ItemsOrders"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td class="Result" align="center" colspan="2">
				        <asp:Button ID="btnSave"  runat="server"   ValidationGroup="ItemsOrders" onclick="btnSave_Click"  SkinID="btnSave" />
					</td>
				</tr>
				</table>