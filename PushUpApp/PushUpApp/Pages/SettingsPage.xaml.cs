﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PushUpApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
            BindingContext = new SettingsViewModel();
		}
	}
}