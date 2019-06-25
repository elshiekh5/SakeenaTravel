<%@ Control Language="C#" AutoEventWireup="true" %>
<asp:Repeater ID="rList" runat="server">
    <ItemTemplate>
<div class="media">
                <a class="pull-left" href="#">
                    <img class="media-object" src="/WebSite/_Assets/img/sliders/elastislide/9.jpg" alt="" />
                </a>
                <div class="media-body">
                    <h4 class="media-heading"><%# Eval("SenderName")%><span> <%# DateFormat.ArabicCalCustom(Eval("SendingDate"), true)%></span></h4>
                    <p><%# Eval("CommentText")%> </p>
                </div>
            </div><!--/media-->
    </ItemTemplate>
</asp:Repeater>
