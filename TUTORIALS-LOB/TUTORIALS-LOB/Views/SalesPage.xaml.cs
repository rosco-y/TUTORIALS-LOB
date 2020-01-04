using System;

using TUTORIALS_LOB.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TUTORIALS_LOB.Views
{
    public sealed partial class SalesPage : Page
    {
        private SalesViewModel ViewModel
        {
            get { return ViewModelLocator.Current.SalesViewModel; }
        }

        public SalesPage()
        {
            InitializeComponent();
            Loaded += SalesPage_Loaded;
        }

        private async void SalesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Workaround for issue on MasterDetail Control. Find More info at https://github.com/Microsoft/WindowsTemplateStudio/issues/2738
            ViewModel.Selected = null;
        }
    }
}
