using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLure.Model
{
    public class Lure
    {
        private string pattern;

        public string Pattern
        {
            get { return pattern; }
            set { pattern = value; }
        }

        private string style;

        public string Style
        {
            get { return style; }
            set { style = value; }
        }

        private string size;

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
