﻿
using Android.App;
using Android.OS;

namespace PushUpApp.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
    MainLauncher = true,
    NoHistory = true)]
    public class SplashScreen : Activity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(MainActivity));
        }
    }
}