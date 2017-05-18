using Mvvm.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TopLure.Model;

namespace TopLure.ViewModel
{
    public class MainViewModel : Mvvm.BindableBase
    {
        private const string lureFileName = @"lures.json";
        private const string catchFileName = @"catches.json";
        public MainViewModel()
        {
            GetData();
            AddCommand = new DelegateCommand(AddLure);
            AddCatchCommand = new DelegateCommand(AddCatch);
            SaveCommand = new DelegateCommand(SaveData);
        }

        private string addText;

        public string AddText
        {
            get { return addText; }
            set { addText = value; OnPropertyChanged(); }
        }


        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand AddCatchCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public void AddCatch()
        {
            var window = new View.AddCatch();

            window.ShowDialog();
            if (window.DialogResult != null && (bool)window.DialogResult)
            {
                catches.Add(window.DataContext as Catch);
            }

        }

        public void AddLure()
        {
            var window = new View.AddLure();

            window.ShowDialog();
            if (window.DialogResult != null && (bool)window.DialogResult)
            {
                lures.Add(window.DataContext as Lure);
            }
            
        }

        //public void AddLure()
        //{
        //    if (string.IsNullOrEmpty(AddText))
        //    {
        //        return;
        //    }

        //    using (StringReader reader = new StringReader(AddText))
        //    {
        //        string line = string.Empty;
        //        do
        //        {
        //            line = reader.ReadLine();
        //            if (line != null)
        //            {
        //                var items = line.Count(x => x == ',');
        //                var split = line.Split(',');
        //                if (items >= 4)
        //                {
        //                    Lures.Add(new Lure { Pattern = split[0], Style = split[1], Size = split[2], Rank = int.Parse(split[3]) });
        //                }
        //                else if (items >= 3)
        //                {
        //                    Lures.Add(new Lure { Pattern = split[0], Style = split[1], Rank = int.Parse(split[2]) });
        //                }
        //                else if (items >= 2)
        //                {
        //                    Lures.Add(new Lure { Pattern = split[0], Rank = int.Parse(split[1]) });
        //                }
        //            }

        //        } while (line != null);
        //    }
        //}
        private void GetData()
        {
            if (!File.Exists(lureFileName))
            {
                InitializeBasicData();
            }
            else
            {
                LoadJsonFromFile();
            }
        }

        private void LoadJsonFromFile()
        {
            var jsonLure = JsonConvert.DeserializeObject<List<Lure>>(File.ReadAllText(lureFileName));
            foreach (var item in jsonLure)
            {
                lures.Add(item);
            }

            if (File.Exists(catchFileName))
            {
                var jsonCatch = JsonConvert.DeserializeObject<List<Catch>>(File.ReadAllText(catchFileName));
                foreach (var item in jsonCatch)
                {
                    catches.Add(item);
                } 
            }
        }

        private void InitializeBasicData()
        {
            Lures.Add(new Lure { Style = "Dry Fly", Size = "8", Rank = 1, Pattern = "Quigley’s Hackle Stacker Flag Dun (BWO)", });
            Lures.Add(new Lure { Style = "Dry Fly", Size = "16", Rank = 2, Pattern = "Tilt Wing Dun – PMD", });
            Lures.Add(new Lure { Style = "Dry Fly", Size = "20", Rank = 3, Pattern = "CDC Midge Adult (black)", });

            SaveData();
        }

        private void SaveData()
        {
            string json = JsonConvert.SerializeObject(Lures.ToList());
            File.WriteAllText(lureFileName, json);

            json = JsonConvert.SerializeObject(Catches.ToList());
            File.WriteAllText(catchFileName, json);
        }

        private ObservableCollection<Catch> catches = new ObservableCollection<Catch>();

        public ObservableCollection<Catch> Catches
        {
            get { return catches; }
            set { catches = value; }
        }

        private ObservableCollection<Lure> lures = new ObservableCollection<Lure>();

        public ObservableCollection<Lure> Lures
        {
            get { return lures; }
            set { lures = value; }
        }

    }
}