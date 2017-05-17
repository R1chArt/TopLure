using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLure.Model
{
    public class Lure : PropertyChangedBase
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

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private int rank;

        public int Rank
        {
            get { return rank; }
            set { rank = value; OnPropertyChanged(); }
        }
            
    }
}
