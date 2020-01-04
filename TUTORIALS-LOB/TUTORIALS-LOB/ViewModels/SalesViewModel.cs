  using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;

using Microsoft.Toolkit.Uwp.UI.Controls;

using TUTORIALS_LOB.Core.Models;
using TUTORIALS_LOB.Core.Services;

namespace TUTORIALS_LOB.ViewModels
{
    public class SalesViewModel : ViewModelBase
    {
        private Order _selected;
        public Order Selected
        {
            get => _selected;
            set
            {
                Set(ref _selected, value);
            }
        }
        public ObservableCollection<Order> Orders { get; private set; }
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            var orders = await DataService.GetOrdersAsync();
            if (orders != null)
            {
                Orders = new ObservableCollection<Order>(orders);
                RaisePropertyChanged("Orders");
            }
            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = Orders.FirstOrDefault();
            }
        }
    }
}
