using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PagerModel
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
        public bool Visible { get; set; }
        //-------------------------------------------------
        public int _EndPage;
        public int _PagerCount = 10;
        public int _PreviousPages;
        public int _StartPage = 1;
        public int _totalPages;
        //-------------------------------------------------
        public int PreviousIndex = 0;
        public int NextIndex = 0;

        public string LinkPattern = "";
        public string LinkToNext = "";
        public string LinkToPrevious = "";

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
                try { LinkToNext = string.Format(LinkPattern, NextIndex); }
                catch (Exception) { }
                try { LinkToPrevious = string.Format(LinkPattern, PreviousIndex); }
                catch (Exception) { }
                

            }
        }
    }
}