using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PushUpApp
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseViewModel()
        {

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Changes the current page 
        /// </summary>
        /// <param name="page">Next page </param>
        public void ChangePage(Page page)
        {
            App.Current.MainPage.Navigation.PushAsync(page);
        }
        #endregion
    }
}
