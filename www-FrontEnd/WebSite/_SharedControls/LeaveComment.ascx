<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeaveComment.ascx.cs" Inherits="WebSite__SharedControls_LeaveComment" %>
<asp:Label ID="lblResult" runat="server" CssClass="divResult"></asp:Label>
<div class="post-comment" runat="server" id="divControls">
    <h3 class="color-green">Leave a Comment</h3>

    <label><%= Resources.Comments.Name %></label>
    <asp:TextBox MaxLength="128" ID="txtName" runat="server" CssClass="span7"
        ValidationGroup="Messages"></asp:TextBox>
    <label><%= Resources.Comments.Email %> <span class="color-red">*</span></label>
    <asp:TextBox MaxLength="128" ID="txtEmail" runat="server" CssClass="span7"
        ValidationGroup="Messages"></asp:TextBox>
    <label>Message</label>
    <asp:TextBox ID="txtCommentText" runat="server" TextMode="MultiLine" CssClass="span10"
        ValidationGroup="Messages" maxlengthS="1000" onkeyup="return ismaxlength(this,document.forms[0].txtCommentTextLengthControler)"
        onfocus="return ismaxlength(this,document.forms[0].txtCommentTextLengthControler)"></asp:TextBox>

    <p>
        <asp:Button ID="btnSend" runat="server" ValidationGroup="Messages" CssClass="btn-u"
            OnClick="btnSend_Click" Text="Send Message" />
    </p>

</div>
