using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPullToRefreshXaml;
using Xamarin.Forms;

namespace TestPullToRefresh
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (MainPageViewModel)this.BindingContext;
            await vm.LoadData(false);
        }
    }
}
