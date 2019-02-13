﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PushUpApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            // Checks if this is first time opening this application
            if (Settings.UserName == string.Empty)
                MainPage = new NavigationPage(new RegisterPage());
            else
                MainPage = new NavigationPage(new WorkoutPage());
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
