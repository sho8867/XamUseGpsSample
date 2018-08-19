using System;
using Xamarin.Forms;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace XamUseGpsSample
{
    class MainPageViewModel : BindableBase
    {
        public Command StartCommand { get; }

        private string _text = String.Empty;
        public string Text { get { return _text; } set { SetProperty(ref _text, value); } }

        private void Start()
        {
            IGeolocator locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50; // <- 1. 50mの精度に指定

            var location = locator.GetLastKnownLocationAsync();
            location.Wait();
            var result = location.Result;
            Text += $"緯度:{result.Latitude} 経度:{result.Longitude}{Environment.NewLine}";
            //MessagingCenter.Send(this, "Start");
        }

        public MainPageViewModel()
        {
            StartCommand = new Command(Start);
        }
    }
}
