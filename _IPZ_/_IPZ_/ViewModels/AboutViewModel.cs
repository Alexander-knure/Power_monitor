using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace _IPZ_.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/Alexander-knure/Power_monitor"));
        }

        public ICommand OpenWebCommand { get; }
    }
}