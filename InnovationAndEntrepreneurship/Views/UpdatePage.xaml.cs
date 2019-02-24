using InnovationAndEntrepreneurship.Models;
using InnovationAndEntrepreneurship.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Telerik.Data.Core;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml.Controls;

namespace InnovationAndEntrepreneurship.Views
{
    public sealed partial class UpdatePage : Page, INotifyPropertyChanged
    {
        public UpdatePage()
        {
            InitializeComponent();
        }
        public IEnumerable<XM> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data

                const string GetProductsQuery = "select 编号, 名称, 类别, 经费, 起始时间, 截止日期, 人数, 获奖情况 ,描述 from 项目表  ";
                return SampleDataService.GetSampleModelData(GetProductsQuery);
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
        private class EmployeeSearchFilter : IFilter
        {
            private string matchString;

            private DataGridTypedColumn column;

            public EmployeeSearchFilter(string match, DataGridTypedColumn column)
            {
                this.matchString = match;
                this.column = column;
            }

            public bool PassesFilter(object item)
            {
                var model = item as XM;

                if (column == null)
                {
                    return false;
                }

                switch (column.PropertyName)
                {
                    case "PName":
                        return model.PName.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    case "LastName":
                        return model.PName.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    case "CountryName":
                        return model.PName.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    case "City":
                        return model.PName.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    case "PostalCode":
                        return model.PName.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    case "PhoneNumber":
                        return model.PName.Contains(this.matchString, StringComparison.OrdinalIgnoreCase);
                    default:
                        break;
                }

                return false;
            }
        }


        
    }
}
