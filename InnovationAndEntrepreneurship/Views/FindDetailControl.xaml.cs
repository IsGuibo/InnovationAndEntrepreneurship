using System;

using InnovationAndEntrepreneurship.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace InnovationAndEntrepreneurship.Views
{
    public sealed partial class FindDetailControl : UserControl
    {
        public XM MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as XM; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(XM), typeof(FindDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public FindDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as FindDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
