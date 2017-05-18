using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLure.Model
{
    [Serializable]
    public class Catch : Mvvm.BindableBase
    {
        public Catch()
        {
            Fish.Name = "abc";
        }
        private Fish fish = new Fish();

        public Fish Fish
        {
            get { return fish; }
            set { fish = value; OnPropertyChanged(); }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged(); }
        }

        private string coordiante;

        public string Coordiante
        {
            get { return coordiante; }
            set { coordiante = value; OnPropertyChanged(); }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; OnPropertyChanged(); }
        }

        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; OnPropertyChanged(); }
        }

        private Lure lure = new Lure();

        public Lure Lure
        {
            get { return lure; }
            set { lure = value; OnPropertyChanged(); }
        }
    }
}
