using ShopperApp.Models;

using ShopperApp.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopperApp
{
    public partial class App : Application
    {

        public const string DATABASE_NAME = "poducts.db";
        public static ProductRepository database;
        public static ProductRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProductRepository(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
