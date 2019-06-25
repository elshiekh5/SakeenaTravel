<%@ Page Language="C#" %>


<script runat="server">
    
    protected void Page_Load(object sender, EventArgs e)
    {
        GoogleMap1.Key = General.GetGoogleMapKey();

    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        //
        if (IsPostBack)
        {
            //string address = _txtAddress.Text;
            //GoogleMap1.Address = address;
            //   GoogleMap1.Markers.Clear();
            //  GoogleMap1.Markers.Add(new GoogleMarker(address));
        }
    } 
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="artem" Namespace="Artem.Web.UI.Controls" Assembly="Artem.GoogleMap" %>

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>خريطة جوجل</title>
    <link href="/Content/AdminDesign/css/Popup.css" rel="stylesheet" type="text/css" />
    <link id="ctl00_cssAdmin" rel="stylesheet" type="text/css" href="/Content/AdminDesign/Ar/Css/Admin.css" />

    <script type="text/javascript" src="/GoogleMapSearch/js/jquery-1.4.2.min.js"></script>

    <script type="text/javascript">
    function __setLocation(overlay, point) 
    {
       alert(point.lat());
      $('#lat').text( point.lat()); 
      $('#lon').text(point.lng()); 
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="vertical-align: top; text-align: center; background-color: White" align="center">
        <table class="MainTable" cellspacing="0" cellpadding="0" width="0" border="0">
            <tr>
                <td>
                    <table class="SubTable" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td align="right" class="text">
                                خط العرض
                            </td>
                            <td align="right" class="text">
                                <span id='_lat'></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="text">
                                خط الطول
                            </td>
                            <td align="right" class="text">
                                <span id='_lon'></span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="23.6445241" Longitude="44.6484375"
                        Zoom="4" OnClientClick="__showInfo" ZoomPanType="Large3D" ShowScaleControl="True"
                        EnableContinuousZoom="True" EnableScrollWheelZoom="true" EnableDoubleClickZoom="True"
                        Width="500px" Height="400px">
                    </artem:GoogleMap>
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        function __showInfo(overlay, point) {
            if (point) {
                //var info = document.getElementById('__info');
                var lat = document.getElementById('_lat');
                var lon = document.getElementById('_lon');
                //info.innerHTML =(point.lat() + '/' + point.lng());
                lat.innerHTML =(point.lat());
                lon.innerHTML =(point.lng());
                
            }
        }
    </script>

    </form>
</body>
</html>
<artem:GoogleMap ID="GoogleMap2" runat="server" Latitude="23.6445241" Longitude="44.6484375"
    Zoom="4" EnableScrollWheelZoom="true" OnClientZoomEnd="__setLocation" OnClientDragEnd="__setLocation"
    AllowBidirectionalLanguages="True" BaseCountryCode="sa" EnableContinuousZoom="True"
    EnableDoubleClickZoom="True" EnableGoogleBar="False" EnableTheming="False" EnableViewState="False"
    IconUrl="/WebSite/_Assets/Interface/images/marker.png" DefaultMapView="Normal" EnableGoogleMapState="False"
    EnableInfoWindow="true" EnableMarkerManager="False" EnableReverseGeocoding="False"
    ShowMapTypeControl="True" ShowScaleControl="True">
</artem:GoogleMap>
