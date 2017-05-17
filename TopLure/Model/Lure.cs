using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLure.Model
{
    [Serializable]
    public class Lure : Mvvm.BindableBase
    {
        private string pattern;

        public string Pattern
        {
            get { return pattern; }
            set { pattern = value; OnPropertyChanged(); }
        }

        private string style;

        public string Style
        {
            get { return style; }
            set { style = value; OnPropertyChanged(); }
        }

        private string size;

        public string Size
        {
            get { return size; }
            set { size = value; OnPropertyChanged(); }
        }

        private int rank;

        public int Rank
        {
            get { return rank; }
            set { rank = value; OnPropertyChanged(); }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string urlShop;

        public string UrlShop
        {
            get { return urlShop; }
            set { urlShop = value; }
        }

    }
}
