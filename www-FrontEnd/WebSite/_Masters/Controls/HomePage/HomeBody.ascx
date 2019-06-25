<%@ Control Language="C#" ClassName="HomeBody" %>

<%@ Register src="Welcome.ascx" tagname="Welcome" tagprefix="uc1" %>
<%@ Register src="LatestProjcts.ascx" tagname="LatestProjcts" tagprefix="uc2" %>
<%@ Register src="Solutions.ascx" tagname="Solutions" tagprefix="uc3" %>
<%@ Register src="HomeSlider.ascx" tagname="HomeSlider" tagprefix="uc4" %>

<%@ Register src="WhyUs.ascx" tagname="WhyUs" tagprefix="uc5" %>

<script runat="server">

</script>

<uc4:HomeSlider ID="HomeSlider1" runat="server" />

<!--=== Purchase Block ===-->
    <div class="spotLoght">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center animated fadeInLeft">
                   <%-- <span>Unify is a clean and fully responsive incredible Template.</span>
                    <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi  vehicula sem ut volutpat. Ut non libero magna fusce condimentum eleifend enim a feugiat corrupti quos.</p>
                   --%> <!--<h3>In <span class="id-color">Our Web Studio </span> Your <span class="id-color">Pretty And Professional Website</span> Is Our Mission</h3>-->
                    <h3>We just love building <span class="id-color">Websites </span> to Enhance your  <span class="id-color">Business Image</span></h3>

                </div>            
                
            </div>
        </div>
    </div><!--/row-->
    <!-- End Purchase Block -->

<!-- Content Part -->
    <div class="container content">	
	<uc5:WhyUs ID="WhyUs1" runat="server" />
       

	<!-- Info Blokcs -->
<div class="row margin-bottom-30">
    <!-- Welcome Block -->
    <div class="col-md-8 md-margin-bottom-40">
        <uc1:Welcome ID="Welcome1" runat="server" />
    </div><!--/col-md-8-->
    <!-- Latest Shots -->
    <div class="col-md-4">
        <uc2:LatestProjcts ID="LatestProjcts1" runat="server" />
    </div><!--/col-md-4-->
</div>
<!-- End Info Blokcs -->

	<!-- Recent Works -->
    <uc3:Solutions ID="Solutions1" runat="server" />
    

</div><!--/container-->		
<!-- End Content Part -->
<!--=== Purchase Block ===-->
    <div class="spotLoght2">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center animated fadeInLeft">
                    <h3>In <span class="id-color">Our Web Studio </span> Your <span class="id-color">Pretty And Professional Website</span> Is Our Mission</h3>

                </div>            
                
            </div>
        </div>
    </div><!--/row-->
    <!-- End Purchase Block -->
<!--=== Purchase Block ===-->
<%--<div class="row-fluid purchase2">
    <div class="container">
		<div class="col-md-12 text-center animated fadeInLeft">
           
            <h3>In <span class="id-color">Our Web Studio </span> Your <span class="id-color">Pretty And Professional Website</span> Is Our Mission</h3>
        </div>
       
    </div>
</div>--%><!--/row-fluid-->
<!-- End Purchase Block -->
<!--@section scripts{
    
   
}-->