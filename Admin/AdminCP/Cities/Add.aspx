<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Add.aspx.cs" Inherits="AdminCities_Create"  %>

 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

			<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				
				<tr>
					<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				 <tr id="trCountryID" runat="server">
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:Cities,Country %>" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList  ID="ddlCountries" runat="server" CssClass="Controls" ValidationGroup="Cities"  />
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvParents" runat="server" ErrorMessage="*" 
						ControlToValidate="ddlCountries" ValidationGroup="Messages" Text="*" InitialValue="-1"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr  id="trArabicText" runat="server">
					<td class="text"><asp:Label ID="Label2" Text="<%$ Resources:Cities,NameAr %>" runat="server" /></td>
					<td class="Control">
						<asp:TextBox MaxLength="32" id="txtNameAr" runat="server" CssClass="Controls" ValidationGroup="Cities"></asp:TextBox>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvNameAr" runat="server" ErrorMessage="*" ControlToValidate="txtNameAr" ValidationGroup="Cities" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr id="trEnglishText" runat="server">
					<td class="text"><asp:Label ID="Label3" Text="<%$ Resources:Cities,NameEn %>" runat="server" /></td>
					<td class="Control">
						<asp:TextBox MaxLength="32" id="txtNameEn" runat="server" CssClass="Controls" ValidationGroup="Cities"></asp:TextBox>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvNameEn" runat="server" ErrorMessage="*" ControlToValidate="txtNameEn" ValidationGroup="Cities" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				
				<tr id="trGoogleMapHorizontal" runat="server" visible="false">
					<td class="text"><asp:Label ID="Label4" Text="<%$ Resources:Cities,GoogleMapHorizontal %>" runat="server" /></td>
					<td class="Control" valign="middle">
					    <div style="float:right">
						    <asp:TextBox CssClass="Controls" MaxLength="64" ID="txtGoogleMapHorizontal" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="txtGoogleMapHorizontal"  ValidationGroup="Cities"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="Cities"  ControlToValidate="txtGoogleMapHorizontal" ID="RegularExpressionValidator2" ValidationExpression="[0-9]*\.?[0-9]*" Display="Dynamic"  runat="server" ErrorMessage="<%$ Resources:Cities,GoogleMapValueError %>"></asp:RegularExpressionValidator>
					    </div>
					    <div style="float:right"><a runat=server class="footer" href="/AdminCP/GoogleMaps/" id="aVideo"  onclick="return hs.htmlExpand(this, { objectType: 'iframe', minHeight:'510' , height: '510' , width: '520' } )"><img hspace="0"  style="width:19px; height:19px;" src="/GoogleMapSearch/GMAPS.gif" border="0" alt="<%= Resources.AdminText.GoogleMapShow %>" /></a></div>
					</td>
				</tr>
				<tr id="trGoogleMapVertical" runat="server" visible="false">
					<td class="text"><asp:Label ID="Label5" Text="<%$ Resources:Cities,GoogleMapVertical %>" runat="server" /></td>
					<td class="Control" valign="middle">
					    <div style="float:right">
						    <asp:TextBox CssClass="Controls" MaxLength="64" ID="txtGoogleMapVertical" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtGoogleMapVertical"  ValidationGroup="Cities"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="Cities"  ControlToValidate="txtGoogleMapVertical" ID="RegularExpressionValidator1" ValidationExpression="[0-9]*\.?[0-9]*" Display="Dynamic"  runat="server" ErrorMessage="<%$ Resources:Cities,GoogleMapValueError %>"></asp:RegularExpressionValidator>
					    </div>
					    <div style="float:right"><a runat=server class="footer" href="/AdminCP/GoogleMaps/" id="a1"  onclick="return hs.htmlExpand(this, { objectType: 'iframe', minHeight:'510' , height: '510' , width: '520' } )"><img hspace="0"  style="width:19px; height:19px;" src="/GoogleMapSearch/GMAPS.gif" border="0" alt="<%= Resources.AdminText.GoogleMapShow %>" /></a></div>
					</td>
				</tr>
				
				<tr>
					<td class="Result" align="center" colspan="2">
				        <asp:Button ID="btnSave"  runat="server"   ValidationGroup="Cities" onclick="btnSave_Click"  SkinID="btnSave" />
					</td>
				</tr>
				</table>
			</td>
		</tr>
	</table>
</asp:Content>
