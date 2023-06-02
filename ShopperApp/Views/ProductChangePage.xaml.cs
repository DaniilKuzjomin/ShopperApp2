using ShopperApp.Models;
using ShopperApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopperApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductChangePage : ContentPage
    {
        public ProductChangePage()
        {
            InitializeComponent();
        }

        private void SaveProduct(object sender, EventArgs e)
        {
            var product = (product)BindingContext;
            if (!String.IsNullOrEmpty(product.Name))
            {
                App.Database.SaveItem(product);
            }
            this.Navigation.PopAsync();
        }

        private void DeleteProduct(object sender, EventArgs e)
        {
            var product = (product)BindingContext;
            App.Database.DeleteItem(product.Id);
            this.Navigation.PopAsync();
        }

        private void OnQuantityTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue) && int.TryParse(e.NewTextValue, out int quantity))
            {
                // Ограничение значения Quantity до 99
                if (quantity > 99)
                {
                    ((Entry)sender).Text = "99";
                }
            }
            else
            {
                ((Entry)sender).Text = "";
            }
        }

        private void OnNameTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                // Remove any digits from the input
                ((Entry)sender).Text = new string(e.NewTextValue.Where(c => !char.IsDigit(c)).ToArray());
            }
        }

    }
}