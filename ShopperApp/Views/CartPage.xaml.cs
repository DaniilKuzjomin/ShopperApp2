using ShopperApp.Models;
using ShopperApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ShopperApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        private bool isTimerRunning = false;
        private int remainingTime = 0;
        private const int MaxHours = 24;


        public CartPage()
        {
            InitializeComponent();
        }

        private CancellationTokenSource cancellationTokenSource;

        private async void StartTimer(object sender, EventArgs e)
        {
            if (!isTimerRunning && int.TryParse(timeEntry.Text, out int hours))
            {
                if (hours > 0 && hours <= MaxHours)
                {
                    int timeInSeconds = hours * 3600;
                    isTimerRunning = true;
                    remainingTime = timeInSeconds;
                    timeEntry.IsEnabled = false;
                    startButton.IsEnabled = false;
                    stopButton.IsEnabled = true;
                    cancellationTokenSource = new CancellationTokenSource();

                    while (remainingTime > 0)
                    {
                        remainingTime--;
                        timerLabel.Text = TimeSpan.FromSeconds(remainingTime).ToString(@"hh\:mm\:ss");
                        await Task.Delay(1000, cancellationTokenSource.Token);
                    }

                    isTimerRunning = false;
                    timeEntry.IsEnabled = true;
                    startButton.IsEnabled = true;
                    stopButton.IsEnabled = false;
                    timerLabel.Text = "00:00:00";
                }
                else
                {
                    await DisplayAlert("Error", $"Please enter a number from 1 to {MaxHours}", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Incorrect time format", "OK");
            }
        }

        private void StopTimer(object sender, EventArgs e)
        {
            if (isTimerRunning && cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                isTimerRunning = false;
                timeEntry.IsEnabled = true;
                startButton.IsEnabled = true;
                stopButton.IsEnabled = false;
                timerLabel.Text = "00:00:00";
            }
        }




        protected override void OnAppearing()
        {
            productsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            product SelectedProduct = (product)e.SelectedItem;
            ProductChangePage productPage = new ProductChangePage();
            productPage.BindingContext = SelectedProduct;
            await Navigation.PushAsync(productPage);
        }

        private async void CreateProduct(object sender, EventArgs e)
        {
            product product = new product();
            ProductPage productPage = new ProductPage();
            productPage.BindingContext = product;
            await Navigation.PushAsync(productPage);
        }

        public static string modifiedLabelText = "❌";

        private void OnLabelTapped(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Text = modifiedLabelText;
        }

        private void OnTimeEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(timeEntry.Text, out int hours))
            {
                if (hours > MaxHours)
                {
                    timeEntry.Text = MaxHours.ToString();
                }
            }
        }

    }
}

