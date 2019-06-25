using System;
using System.Text.RegularExpressions;
namespace DCCMSNameSpace
{
    public class ReWrittenUrl
    {
        //-----------------------------
        private string _name;
        private string _path;
        private string _pattern;
        private Regex _regex = null;
        //-----------------------------    
        public ReWrittenUrl(string name, string pattern, string path)
        {
            _name = name;
            _path = path;
            _pattern = pattern;
            _regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        //-----------------------------
        public bool IsMatch(string url)
        {
            return _regex.IsMatch(url);
        }

        //-----------------------------
        public string Pattern
        {
            get { return _pattern; }
        }

        //-----------------------------
        public string Name
        {
            get { return _name; }
        }
        //-----------------------------
        public string Path
        {
            get { return _path; }
        }
        //-----------------------------
        public string Convert(string url, string qs)
        {
            if (qs != null && qs.StartsWith("?"))
            {
                qs = qs.Replace("?", "&");
            }
            return string.Format("{0}{1}", _regex.Replace(url, _path), qs);
        }
        //-----------------------------
    }
}