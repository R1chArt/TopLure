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
        private const string fileName = @"lures.json";
        public MainViewModel()
        {
            GetData();
            AddCommand = new DelegateCommand(AddLure);
            SaveCommand = new DelegateCommand(SaveData);
        }

        private string addText;

        public string AddText
        {
            get { return addText; }
            set { addText = value; OnPropertyChanged(); }
        }


        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        public void AddLure()
        {
            if (string.IsNullOrEmpty(AddText))
            {
                return;
            }

            using (StringReader reader = new StringReader(AddText))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        var items = line.Count(x => x == ',');
                        var split = line.Split(',');
                        if (items >= 4)
                        {
                            Lures.Add(new Lure { Pattern = split[0], Style = split[1], Size = split[2], Rank = int.Parse(split[3]) });
                        }
                        else if (items >= 3)
                        {
                            Lures.Add(new Lure { Pattern = split[0], Style = split[1], Rank = int.Parse(split[2]) });
                        }
                        else if (items >= 2)
                        {
                            Lures.Add(new Lure { Pattern = split[0], Rank = int.Parse(split[1]) });
                        }
                    }

                } while (line != null);
            }

        }
        private void GetData()
        {
            if (!File.Exists(fileName))
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
            var jsonLure = JsonConvert.DeserializeObject<List<Lure>>(File.ReadAllText(fileName));
            foreach (var item in jsonLure)
            {
                lures.Add(item);
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
            File.WriteAllText(fileName, json);
        }

        private ObservableCollection<Lure> lures = new ObservableCollection<Lure>();

        public ObservableCollection<Lure> Lures
        {
            get { return lures; }
            set { lures = value; }
        }

    }
}