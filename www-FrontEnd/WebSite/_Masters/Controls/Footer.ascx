<%@ Control Language="C#" ClassName="Footer" %>

<%@ Register src="HomePage/RecentBlogEntries.ascx" tagname="RecentBlogEntries" tagprefix="uc1" %>

<%@ Register src="HomePage/PageContacts.ascx" tagname="PageContacts" tagprefix="uc2" %>

<script runat="server">

</script>
  <!--=== Footer ===-->
<div class="footer">
    <div class="container">
        <div class="row">
            <div class="col-md-4 md-margin-bottom-40">
                <!-- About -->
                <div class="headline"><h2>About</h2></div>
                <p class="margin-bottom-25 md-margin-bottom-40">We create things in the way we believe is right,
                with passion and commitment.</p>
                <!-- End About -->
                <!-- Monthly Newsletter -->
                <div class="headline"><h2>Monthly Newsletter</h2></div>
                <p>Subscribe to our newsletter and stay up to date with the latest news and deals!</p>
                <form class="footer-subsribe">
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="Email Address">
                        <span class="input-group-btn">
                            <button class="btn-u" type="button">Subscribe</button>
                        </span>
                    </div>
                </form>
                <!-- End Monthly Newsletter -->
            </div><!--/col-md-4-->

            <div class="col-md-4 md-margin-bottom-40">
                <!-- Recent Blogs -->
                <uc1:RecentBlogEntries ID="RecentBlogEntries1" runat="server" />
                <!-- End Recent Blogs -->
            </div><!--/col-md-4-->
            <div class="col-md-4">
                <!-- Contact Us -->
                <uc2:PageContacts ID="PageContacts1" runat="server" />
                <!-- End Contact Us -->
                <!-- Social Links -->
                <div class="headline"><h2>Stay Connected</h2></div>
                <ul class="social-icons">
                    <li><a href="#" data-original-title="Feed" class="social_rss"></a></li>
                    <li><a href="#" data-original-title="Facebook" class="social_facebook"></a></li>
                    <li><a href="#" data-original-title="Twitter" class="social_twitter"></a></li>
                    <li><a href="#" data-original-title="Goole Plus" class="social_googleplus"></a></li>
                    <li><a href="#" data-original-title="Pinterest" class="social_pintrest"></a></li>
                    <li><a href="#" data-original-title="Linkedin" class="social_linkedin"></a></li>
                    <li><a href="#" data-original-title="Vimeo" class="social_vimeo"></a></li>
                </ul>
                <!-- End Social Links -->
            </div><!--/col-md-4-->
        </div>
    </div>
</div><!--/footer-->
<!--=== End Footer ===-->
<!--=== Copyright ===-->
<div class="copyright">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <p>
                    2014 &copy; Unify. ALL Rights Reserved.
                    <a target="_blank" href="#">Digital Tags</a> | <a href="#">Privacy Policy</a> | <a href="#">Terms of Service</a>
                </p>
            </div>
            <div class="col-md-6">
                <a href="index.html">
                    <img class="pull-right" id="logo-footer" src="/WebSite/_Assets/img/logo.png" alt="">
                </a>
            </div>
        </div>
    </div>
</div><!--/copyright-->
<!--=== End Copyright ===-->