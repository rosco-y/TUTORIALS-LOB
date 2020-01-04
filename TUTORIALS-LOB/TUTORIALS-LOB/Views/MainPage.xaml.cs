using System;

using TUTORIALS_LOB.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TUTORIALS_LOB.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return ViewModelLocator.Current.MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
