//----------------------------------------------
function ClearText(controlID , defaultvalue)
{
    //alert(controlID);
    //alert(defaultvalue);
    var control=document.getElementById(controlID);
    var controlvalue = control.value;
    if(controlvalue==defaultvalue)
    {
        control.value = "";
    }
}
//----------------------------------------------