using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShopperApp.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        public DetailsViewModel()
        {
            Title = "Details";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
