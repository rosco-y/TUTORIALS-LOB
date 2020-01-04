using System;

using TUTORIALS_LOB.Core.Models;
using TUTORIALS_LOB.Core.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TUTORIALS_LOB.Views
{
    public sealed partial class SalesDetailControl : UserControl
    {
        public Order MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Order; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(Order), typeof(SalesDetailControl), new PropertyMetadata(null, OnMasterMenuItemChangedAsync));
        private static async void OnMasterMenuItemChangedAsync(DependencyObject d,   DependencyPropertyChangedEventArgs e)
        {
            var newOrder = e.NewValue as Order;
            if (newOrder != null && newOrder.OrderItems == null)
            {
                newOrder.OrderItems = await
                DataService.GetOrderItemsAsync((int)newOrder.OrderId);
            } 
        }

        public SalesDetailControl()
        {
            InitializeComponent();
        }

        //private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var control = d as SalesDetailControl;
        //    control.ForegroundElement.ChangeView(0, 0, 1);
        //}
    }
}
