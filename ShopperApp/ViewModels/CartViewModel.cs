using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShopperApp.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public CartViewModel()
        {
            Title = "Cart";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}