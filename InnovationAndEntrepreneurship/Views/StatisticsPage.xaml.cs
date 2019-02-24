using InnovationAndEntrepreneurship.Models;
using InnovationAndEntrepreneurship.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;

namespace InnovationAndEntrepreneurship.Views
{
    public sealed partial class StatisticsPage : Page, INotifyPropertyChanged
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }
        public ObservableCollection<DataPoint> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data

                const string GetProductsQuery = "select 编号, 名称, 类别, 经费, 起始时间, 截止日期, 人数, 获奖情况 ,描述 from 项目表  ";
                return SampleDataService.GetChartSampleData(GetProductsQuery);
            }
        }

     

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
