using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TestPullToRefresh;
using Xamarin.Forms;

namespace TestPullToRefreshXaml
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private bool _loading;
        private bool _refreshing;
        private List<Person> _personList;

        public MainPageViewModel()
        {
            this.RefreshCommand = new Command(this.RefreshData);
        }

        /// <summary>
        /// Gets or sets the refresh command
        /// </summary>
        public Command RefreshCommand { get; set; }

        public async Task LoadData()
        {
            this.Loading = true;
            this.Refreshing = false;
            await Task.Delay(3000);
            this.LoadItems();
            this.Loading = false;
        }

        public List<Person> PersonList
        {
            get { return _personList; }
            set {
                if (_personList != value)
                {
                    _personList = value;
                    OnPropertyChanged("PersonList");
                }
            }
        }

        public bool Loading
        {
            get { return _loading; }
            set {
                if (_loading != value)
                {
                    _loading = value;
                    OnPropertyChanged("Loading");
                }
            }
        }

        public bool Refreshing
        {
            get { return _refreshing; }
            set
            {
                if (_refreshing != value)
                {
                    _refreshing = value;
                    OnPropertyChanged("Refreshing");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private async void RefreshData()
        {
            await this.LoadData();
        }

        private void LoadItems()
        {
            this.PersonList = new List<Person>
            {
                new Person { Name = "Steve", Age = 21, Country = "USA" },
                new Person { Name = "Raven", Age = 32, Country = "Iceland" },
                new Person { Name = "Carsten", Age = 28, Country = "Denmark" },
                new Person { Name = "John", Age = 32, Country = "England" },
                new Person { Name = "Tony", Age = 37, Country = "Ireland" },
                new Person { Name = "Tom", Age = 43, Country = "USA" },
                new Person { Name = "Nonni", Age = 12, Country = "Iceland" },
                new Person { Name = "Rikki", Age = 17, Country = "Iceland" },
                new Person { Name = "Sam", Age = 56, Country = "Australia" },
                new Person { Name = "Mary", Age = 32, Country = "Denmark" },
                new Person { Name = "Sue", Age = 39, Country = "Scotland" },
                new Person { Name = "Ellen", Age = 45, Country = "Sweden" },
                new Person { Name = "Amy", Age = 67, Country = "USA" },
                new Person { Name = "Andy", Age = 69, Country = "Canada" },
                new Person { Name = "Magnus", Age = 22, Country = "Norway" },
                new Person { Name = "Gary", Age = 19, Country = "Russia" },
                new Person { Name = "Anatoly", Age = 11, Country = "Russia" },
                new Person { Name = "Victor", Age = 99, Country = "Switzerland" },
                new Person { Name = "Robert", Age = 25, Country = "USA" }
            };
        }
    }
}
