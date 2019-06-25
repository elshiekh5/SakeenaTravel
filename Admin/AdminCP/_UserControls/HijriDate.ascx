<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HijriDate.ascx.cs" Inherits="UserControls_HijriDate" %>

<table>
    <tr>
        <td colspan="3" align="center">
            <asp:Label ID="lblResult"  runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width:18px; height:9px; vertical-align:middle; "><img alt="" src="Arrow.gif" /></td><td style="width:50%; height:30px;">
            <asp:DropDownList ID="ddlDay" runat="server">
                <asp:ListItem Value="-1" Selected="True" Text="<%$ Resources:AdminText,Date_Day %>"></asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator CssClass="validation" Display="Dynamic" ID="rfvDay" runat="server" ErrorMessage="*"
                ControlToValidate="ddlDay" InitialValue="-1" Text="*"></asp:RequiredFieldValidator>
        </td>
        <td style="width:18px; height:9px; vertical-align:middle; "><img alt="" src="Arrow.gif" /></td><td style="width:50%; height:30px;">
            <asp:DropDownList ID="ddlMonth" runat="server">
                <asp:ListItem Value="-1" Selected="True" Text="<%$ Resources:AdminText,Date_Month %>"></asp:ListItem>
                <asp:ListItem Value="1">„Õ—„</asp:ListItem>
                <asp:ListItem Value="2">’›—</asp:ListItem>
                <asp:ListItem Value="3">—»Ì⁄ √Ê·</asp:ListItem>
                <asp:ListItem Value="4">—»Ì⁄ À«‰</asp:ListItem>
                <asp:ListItem Value="5">Ã„«œÏ √Ê·</asp:ListItem>
                <asp:ListItem Value="6">Ã„«œÏ À«‰</asp:ListItem>
                <asp:ListItem Value="7">—Ã»</asp:ListItem>
                <asp:ListItem Value="8">‘⁄»«‰</asp:ListItem>
                <asp:ListItem Value="9">—„÷«‰</asp:ListItem>
                <asp:ListItem Value="10">‘Ê«·</asp:ListItem>
                <asp:ListItem Value="11">–Ê «·ﬁ⁄œ…</asp:ListItem>
                <asp:ListItem Value="12">–Ê «·ÕÃ…</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator CssClass="validation" Display="Dynamic" ID="rfvMonth" runat="server" ErrorMessage="*"
                ControlToValidate="ddlMonth" InitialValue="-1" Text="*"></asp:RequiredFieldValidator>
        </td>
        <td >
            <asp:DropDownList ID="ddlyear" runat="server">
                <asp:ListItem Value="-1" Selected="True" Text="<%$ Resources:AdminText,Date_Year %>"></asp:ListItem>
            </asp:DropDownList>
           
            <asp:RequiredFieldValidator CssClass="validation" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="ddlyear" InitialValue="-1" Text="*"></asp:RequiredFieldValidator>
        </td>
        <td runat=server visible=false>
            <asp:TextBox MaxLength="0" ID="txtYears" runat="server" CssClass="Controls" Width="70"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation" Display="Dynamic" ID="rfvYear" runat="server" ErrorMessage="*"
                ControlToValidate="txtYear" Text="*"></asp:RequiredFieldValidator>
        </td>
        <td style="width:18px; height:9px; vertical-align:middle; "><img alt="" src="Arrow.gif" /></td><td style="width:50%; height:30px;">
            &nbsp;<asp:Label ID="Label2" runat="server"  Text="<%$ Resources:AdminText,Date_Islamic %>"></asp:Label>
        </td>
        
    </tr>
</table>

