using System;

using TUTORIALS_LOB.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TUTORIALS_LOB.Views
{
    public sealed partial class SalesDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(SalesDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public SalesDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as SalesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
