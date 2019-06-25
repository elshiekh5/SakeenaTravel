using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite__SharedControls_Pager : System.Web.UI.UserControl
{
    public int TotalRecords { get; set; }

    //-------------------------------------------------
    private int _PageSize = 10;

    public int PageSize
    {
        get { return _PageSize; }
        set { _PageSize = value; }
    }

    //-------------------------------------------------
    private int _CurrentPage = 1;
    public int CurrentPage
    {
        get { return _CurrentPage; }
        set { _CurrentPage = value; }
    }
    
    //-------------------------------------------------
    private int _EndPage;
    private int _PagerCount = 10;
    private int _PreviousPages;
    private int _StartPage = 1;
    private int _totalPages;
    //-------------------------------------------------
    public int PreviousIndex = 0;
    public int NextIndex = 0;

    public string LinkPattern = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        PreparePager();
        LoadPagerHtml();
    }
    public void PreparePager()
    {
        //bool haveNewRecords = (TotalRecords != 0);
        if (TotalRecords < 0)
        {
            this.Visible = false;
        }
        else
        {
            if (PageSize > TotalRecords)
                PageSize = TotalRecords;

            _totalPages = TotalRecords / PageSize;
            if ((TotalRecords % PageSize) > 0)
                _totalPages++;

            if (_totalPages < 2)
            {
                Visible = false;
                return;
            }




            if (_PagerCount > TotalRecords)
            {
                _PagerCount = TotalRecords;
            }

            _PreviousPages = _PagerCount / 2;

            if ((_PagerCount % 2) > 0)
            {
                _PreviousPages++;
            }

            if (CurrentPage > (_PreviousPages + 1))
            {
                _StartPage = CurrentPage - _PreviousPages;
            }

            _EndPage = _StartPage + _PagerCount - 1;

            if (_EndPage > _totalPages)
            {
                _EndPage = _totalPages;
            }

            if ((_EndPage - _StartPage) < _PagerCount)
            {
                _StartPage = _EndPage - _PagerCount + 1;
            }

            if (_StartPage < 1)
            {
                _StartPage = 1;
            }

            PreviousIndex = CurrentPage - 1;
            NextIndex = CurrentPage + 1;
            //if(previousIndex<1)

        }
    }

    public void LoadPagerHtml()
    {
    ltrPager.Text+="<ul class=\"pagination\">";
    if (PreviousIndex > 0)
    {
        ltrPager.Text += "\t<li><a href=\"" + PreviousIndex + "\">Prev</a></li>";
    }
        for (int i = _StartPage; i <= _EndPage; i++)
		{
                if(i== CurrentPage)
                {
                    ltrPager.Text+="\t<li class=\"active\"><a href=\""+string.Format(LinkPattern,i)+"\">"+i+"</a></li>";
              } 
                else{

                    ltrPager.Text += "\t<li><a href=\"" + string.Format(LinkPattern, i) + "\">" + i + "</a></li>";


                }
            }

        if (NextIndex <= _EndPage)
        {
            ltrPager.Text += "\t<li><a href=\"" + NextIndex + "\">Next</a></li>";
        }
        ltrPager.Text += "</ul>";
    
    }
}