<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendComment.ascx.cs" Inherits="WebSite__SharedControls_SendComment" %>
<div class="post-comment">
    <h3 class="color-green">Leave a Comment</h3>
    <label><%= Resources.Comments.Name %></label>
    <asp:TextBox MaxLength="128" ID="txtName" runat="server" CssClass="span7" ValidationGroup="Messages"></asp:TextBox>
    <label><%= Resources.Comments.Email %> <span class="color-red">*</span></label>
    <asp:TextBox MaxLength="128" ID="txtEmail" runat="server" CssClass="span7" ValidationGroup="Messages"></asp:TextBox>
    <label>Message</label>
    <asp:TextBox ID="txtCommentText" runat="server" TextMode="MultiLine" CssClass="span10" ValidationGroup="Messages"></asp:TextBox>
    <p>
        <asp:Button ID="btnSend" runat="server" ValidationGroup="Messages" CssClass="btn-u" OnClick="btnSend_Click" Text="Send Message" />
    </p>
</div>





