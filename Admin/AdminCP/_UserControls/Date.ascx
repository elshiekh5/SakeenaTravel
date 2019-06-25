<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Date.ascx.cs" Inherits="UserControls_Date" %>

<table>
    <tr>
        <td colspan="3" align="center">
            <asp:Label ID="lblResult"  runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlDay" runat="server" CssClass="Controls" Width="70">
                <asp:ListItem Value="-1" Selected="True"  Text="<%$ Resources:AdminText,Date_Day %>"></asp:ListItem>
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
                <asp:ListItem>31</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator CssClass="validation" Display="Dynamic"  ID="rfvDay" runat="server" ErrorMessage="*"
                ControlToValidate="ddlDay" InitialValue="-1" Text="*"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="Controls" Width="70">
                <asp:ListItem Value="-1" Selected="True"  Text="<%$ Resources:AdminText,Date_Month %>"></asp:ListItem>
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
            </asp:DropDownList>
            <asp:RequiredFieldValidator CssClass="validation" Display="Dynamic" ID="rfvMonth" runat="server" ErrorMessage="*"
                ControlToValidate="ddlMonth" InitialValue="-1" Text="*"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:TextBox MaxLength="4" ID="txtYear"   runat="server" CssClass="Controls" Width="70"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validation" Display="Dynamic" ID="rfvYear" runat="server" ErrorMessage="*"
                ControlToValidate="txtYear" Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="validation"  ID="rxvYear"  Display="Dynamic"  ValidationExpression="\d*" runat="server" ControlToValidate="txtYear"
                                             ErrorMessage="<%$ Resources:User,InvalidNumericalData %>"></asp:RegularExpressionValidator>
           &nbsp;<asp:Label ID="Label2" runat="server"  Text="<%$ Resources:AdminText,Date_Georgian %>"></asp:Label>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
