<%@ Control Language="C#" AutoEventWireup="true" CodeFile="details.ascx.cs" Inherits="WebSite_Solutions_Gallery_details" %>
<div class="blog margin-bottom-40">
    <h2 id="lblTitle" runat="server"></h2>
    <div class="blog-post-tags">
        <ul class="list-unstyled list-inline blog-info">
            <li id="lblDate" runat="server"><i class="fa fa-calendar"></i></li>
            <li id="lblAuthor" runat="server"><i class="fa fa-pencil"></i></li>
            <li id="lblComments" runat="server"><i class="fa fa-comments"></i><a href="#">24 Comments</a></li>
        </ul>
        <%--<ul class="list-unstyled list-inline blog-tags">
            <li>
                <i class="fa fa-tags"></i>
                <a href="#">Technology</a>
                <a href="#">Education</a>
                <a href="#">Internet</a>
                <a href="#">Media</a>
            </li>
        </ul>--%>
    </div>
    <div class="blog-img">
        <img id="imgPhoto" runat="server" class="img-responsive" alt="">
    </div>
    <p>
        <asp:Literal ID="ltrDetails" runat="server"></asp:Literal></p>
    <br>
</div>
