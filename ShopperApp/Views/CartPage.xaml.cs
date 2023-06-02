using ShopperApp.Models;
using ShopperApp.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ShopperApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
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





    }
}

