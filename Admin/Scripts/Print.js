var gAutoPrint = true; // Tells whether to automatically call the print function

function printSpecial() {
    if (document.getElementById != null) {

        var html = '<HTML>\n<HEAD>\n <link rel="stylesheet"  href="<%=SiteDesign.CssFolder %>print.css" type="text/css" />';

        html += '\n</HE>\n<BODY >\n';

        var printReadyElem = document.getElementById("printReady");

        if (printReadyElem != null) {



        html += "<table class='printholder'  border='0' cellpadding='0' cellspacing='0' align=center>"
        html += "<tr><td class='printheader'></td></tr>"
        html += "<tr><td class='printbody'>"
	    html += printReadyElem.innerHTML;
	    html += "</td></tr>"
	    html += "<tr><td class='printfooter'></td></tr>"
	    html += "</table>"


	}
	else {
	    alert("Could not find the printReady function");
	    return;
	}

	html += '\n</BO>\n</HT>';

	var printWin = window.open("", "printSpecial");
	printWin.document.open();
	printWin.document.write(html);
	printWin.document.close();
	if (gAutoPrint)
	    printWin.print();
}
else {
    alert("The print ready feature is only available if you are using an browser. Please update your browswer.");
}
}