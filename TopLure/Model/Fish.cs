using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TopLure.Model
{
    public class Fish : Mvvm.BindableBase
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private float weight;

        public float Weight
        {
            get { return weight; }
            set { weight = value; OnPropertyChanged(); }
        }

        private float length;
     
        public float Length
        {
            get { return length; }
            set { length = value; OnPropertyChanged(); }
        }
    }
}
