<%@ Page Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_counter_Default"  %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table  class="MainTable" width="90%" cellpadding="0" cellspacing="0">
	<tr><td id="country_header"  style="font-size:14px; font-weight:bold;font-family:Arial;" align="center"><asp:Label ID="lblCount" runat="server"></asp:Label></td></tr>
	
	<tr>
		<td id="tdVisitors002">
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="padding:2px;"  >
                        <asp:DataGrid runat="server" ID="dgCountryVisitors" ShowFooter="false" SkinID="DataGridSkin" ShowHeader="false"  OnItemDataBound="dgCountryVisitors_ItemDataBound">
                            <Columns>
                                <asp:TemplateColumn HeaderText="<%$ Resources:VisitorsCounter,Country %>">
                                    <ItemTemplate>
				                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
					                        <tr>
						                        <td >
						                            <img src='<%# DCCMSNameSpace.VisitorCouter.GetCountryFlagPath(Eval("ctry")) %>'  />
						                        </td>
						                        <td ><%# Eval(("country_ar"))%></td>
						                        <td align="right" ><nobr>(<%# Eval("vc_count")%>)</nobr></td>
					                        </tr>
				                        </table>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </td>
                </tr>
                <tr>
                    <td class="country_name" ></td>
                </tr>
            </table>
		</td>
	</tr>
	<tr>
		<td id=tdVisitors003 align="center">
            <asp:Button ID="btnSetZero" runat="server" Text="<%$ Resources:VisitorsCounter,ResetCounter %>" 
                onclick="btnSetZero_Click"  />
        </td>
	</tr>
	</table>
</asp:Content>


