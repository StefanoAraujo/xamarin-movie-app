using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using MoviesMobileApp.Services;
using MoviesMobileApp.Models;

namespace MoviesMobileApp
{
    public partial class App : Application
    {
        public static INavigation Navigation;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MoviesMobileApp.MainPage());
            Navigation = MainPage.Navigation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
