using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLure.Model
{
    public class Fish
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private float weight;

        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private float length;

        public float Length
        {
            get { return length; }
            set { length = value; }
        }
    }
}
