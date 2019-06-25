<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script type="text/javascript" src="swfobject.js"></script>
                        <div id="player"></div>
                        <span id="lblPlayer"><script type='text/javascript'>
                            var so = new SWFObject('mediaplayer.swf','mpl','400','320','8');
                            so.addParam('allowscriptaccess','always');
                            so.addParam('allowfullscreen','true');
                            so.addVariable('height','320');
                            so.addVariable('width','400');
                            so.addVariable('file','video.flv');
                            so.addVariable('image','preview.jpg');
                            so.addVariable('backcolor','0x3D91CA');
                            so.addVariable('frontcolor','0xFFFFFF');
                            so.addVariable('logo','/images/BL-Logo.png');
                            so.addVariable('link','http://www.bluelimits.com');
                            so.addVariable('linktarget','_blank');
                            so.addVariable('showstop','true');
                            so.write('player');
                         </script></span>
    </div>
    </form>
</body>
</html>
