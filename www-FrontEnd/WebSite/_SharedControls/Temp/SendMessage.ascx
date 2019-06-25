<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendMessage.ascx.cs" Inherits="WebSite__SharedControls_SendMessage" %>
     <asp:Label ID="lblResult" runat="server"></asp:Label>
    <label>Name</label>
    <asp:TextBox MaxLength="128" ID="txtName" runat="server" CssClass="span7" ValidationGroup="Messages"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvName"
        runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtName"
        ValidationGroup="Messages" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>


    <label>Email <span class="color-red">*</span></label>
    <asp:TextBox MaxLength="128" ID="txtEMail" runat="server" CssClass="span7" ValidationGroup="Messages"></asp:TextBox>
    <asp:RegularExpressionValidator CssClass="ourvalidation" Display="Dynamic" ID="revEMail"
        runat="server" ControlToValidate="txtEMail" ErrorMessage="" Text="<%$ Resources:MemberShip,InvalidEmail %>"
        ValidationGroup="Messages" ValidationExpression="^([\w\-\.]+)@((\[([0-9]{1,3}\.){3}[0-9]{1,3}\])|(([\w\-]+\.)+)([a-zA-Z]{2,4}))$"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvEMail"
        runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtEMail"
        ValidationGroup="Messages" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>


    <label>Message</label>
    <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" CssClass="span10"
        ValidationGroup="Messages" rows="8"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvDetails"
        runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtDetails"
        ValidationGroup="Messages" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>


    <p>
        <asp:Button ID="btnSend" runat="server" ValidationGroup="Messages" CssClass="btn-u" Text="Send Message" OnClick="btnSend_Click"></asp:Button></p>
