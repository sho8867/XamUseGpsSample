using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

namespace XamUseGpsSample
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        // 画面が表示されたタイミングでの処理
        private void MainPageAppearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<MainPageViewModel>(this, "Start", Start);
        }

        // 画面が表示されなくなったタイミングでの処理
        private void MainPageDisappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<MainPageViewModel>(this, "Start");
        }

        private void Start<T>(T sender)
        {
            IGeolocator locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50; // <- 1. 50mの精度に指定

            var location = locator.GetLastKnownLocationAsync();
            location.Wait();
            var result = location.Result;
        }
    }
}
