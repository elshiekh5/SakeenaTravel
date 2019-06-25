<%@ Control Language="c#" AutoEventWireup="true" CodeFile="Details.ascx.cs" Inherits="MLanguagesDetailsControls2" %>

<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<%@ Register Assembly="ServerControl1" Namespace="DC" TagPrefix="cc1" %>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr id="trTitle" runat="server">
        <td class="text">
            <asp:Label ID="lblTitle" runat="server" />
        </td>
        <td class="Control">
            <asp:TextBox MaxLength="128" ID="txtTitle" runat="server" CssClass="Controls"></asp:TextBox>
            <asp:CustomValidator ID="cvTitle" runat="server" ValidationGroup="Items" ErrorMessage="*"
                Display="Dynamic" />
        </td>
    </tr>
    <tr id="trAuthorName" runat="server">
        <td class="text">
            <asp:Label ID="lblAuthorName" runat="server" />
        </td>
        <td class="Control">
            <asp:TextBox MaxLength="128" ID="txtAuthorName" runat="server" CssClass="Controls"></asp:TextBox>
            <asp:CustomValidator ID="cvAuthorName" ValidationGroup="Items" runat="server" ErrorMessage="*"
                Display="Dynamic" />
        </td>
    </tr>
    <tr id="trAddress" runat="server">
        <td class="text">
            <asp:Label ID="lblAddress" runat="server" />
        </td>
        <td class="Control">
            <asp:TextBox MaxLength="128" ID="txtAddress" runat="server" CssClass="Controls"></asp:TextBox>
            <asp:CustomValidator ID="cvAddress" ValidationGroup="Items" runat="server" ErrorMessage="*"
                Display="Dynamic" />
        </td>
    </tr>
    <tr id="trExtraText_1" runat="server">
        <td class="text">
            <asp:Label ID="lblExtraText_1" runat="server" />
        </td>
        <td class="Control">
            <asp:TextBox MaxLength="128" ID="txtExtraText_1" runat="server" CssClass="Controls"></asp:TextBox>
            <asp:CustomValidator ID="cvExtraText_1" ValidationGroup="Items" runat="server" ErrorMessage="*"
                Display="Dynamic" />
        </td>
    </tr>
    <tr id="trShortDescription" runat="server">
        <td class="text">
            <asp:Label ID="lblShortDescription" runat="server" />
        </td>
        <td class="Control">
            <asp:TextBox MaxLength="500" ID="txtShortDescription" runat="server" TextMode="MultiLine"
                CssClass="Controls" maxlengthS="500" onkeyup="return ismaxlength(this,document.forms[0].txtShortDescriptionLengthControler)"
                onfocus="return ismaxlength(this,document.forms[0].txtShortDescriptionLengthControler)"></asp:TextBox>
            <input type="text" runat="server" class="Controls" id="txtSDLengthControler" style="width: 40px;"
                disabled>
            <asp:CustomValidator ID="cvShortDescription" ValidationGroup="Items" runat="server"
                ErrorMessage="*" Display="Dynamic" />
        </td>
    </tr>
    <tr id="trDetailsText" runat="server">
        <td class="text"> 
            <asp:Label ID="lblDetails" runat="server" />
        </td>
        <td>
        </td>
    </tr>
    <tr id="trDetailsControl" runat="server">
        <td class="DetailsControl" colspan="2">
            
            <CE:Editor  id="fckDescription" Height="500" Width="1000" EditorWysiwygModeCss="~/CuteSoft_Client/example.css" runat="server" ></CE:Editor>
            <asp:TextBox  TextMode="MultiLine" ID="txtDescription" runat="server"
                CssClass="DetailsControls"></asp:TextBox>
            <asp:CustomValidator ID="cvDescription" ValidationGroup="Items" runat="server" ErrorMessage="*"
                Display="Dynamic" />
        </td>
    </tr>
    <tr id="trMetaKeyWords" runat="server">
        <td class="text">
            <asp:Label ID="lblMetaKeyWords" runat="server" />
        </td>
        <td class="Control">
            <asp:TextBox MaxLength="128" ID="txtMetaKeyWords" runat="server" CssClass="Controls"></asp:TextBox>
            <%--<asp:CustomValidator ID="cvMetaKeyWords" ValidationGroup="Items" runat="server" ErrorMessage="*"
                Display="Dynamic" />--%>
        </td>
    </tr>

</table>
