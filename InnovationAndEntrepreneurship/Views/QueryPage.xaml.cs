using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using InnovationAndEntrepreneurship.Models;
using InnovationAndEntrepreneurship.Services;

using Windows.UI.Xaml.Controls;

namespace InnovationAndEntrepreneurship.Views
{
    public sealed partial class QueryPage : Page, INotifyPropertyChanged
    {
        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on QueryPage.xaml.
        // For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        // You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        public QueryPage()
        {
            InitializeComponent();
        }

        public ObservableCollection<XM> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                const string GetProductsQuery = "select 编号, 名称, 类别, 经费, 起始时间, 截止日期, 人数, 获奖情况 ,描述 from 项目表  ";
                return SampleDataService.GetGridSampleData(GetProductsQuery);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    }
}
