<%@ Page Language="C#" MasterPageFile="~/WebSite/_Masters/ContactUS.master" AutoEventWireup="true" CodeFile="Send.aspx.cs" Inherits="WebSite_contact_us_Send" %>
<%@ Register Src="Controls/SendMessage.ascx" TagName="SendMessage" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<!-- Google Map -->
                <div id="map" class="map map-box map-box-space margin-bottom-40"></div>
                <!-- End Google Map -->

                <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas feugiat. Et harum quidem rerum facilis est et expedita distinctio lorem ipsum dolor sit amet, consectetur adipiscing elit landitiis.</p><br />
                <uc4:SendMessage ID="SendMessage2" runat="server" />
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="Server">

</asp:Content>
