using InnovationAndEntrepreneurship.Models;
using InnovationAndEntrepreneurship.Services;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace InnovationAndEntrepreneurship.Views
{
    public sealed partial class FindPage : Page, INotifyPropertyChanged
    {
        private XM _selected;

        public XM Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<XM> SampleItems { get; private set; } = new ObservableCollection<XM>();

        public FindPage()
        {
            InitializeComponent();
            Loaded += FindPage_Loaded;
          
        }

        public void FindPage_Loaded(object sender, RoutedEventArgs e)
        {
            SampleItems.Clear();
            const string GetProductsQuery = "select 编号, 名称, 类别, 经费, 起始时间, 截止日期, 人数, 获奖情况 ,描述 from 项目表  ";
            var data = SampleDataService.GetSampleModelData(GetProductsQuery);


            foreach (var item in data)
            {
                SampleItems.Add(item);

            }

            if (MasterDetailsViewControl.ViewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.FirstOrDefault();
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





        private void Control2_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            SampleItems.Clear();
            string varible = SuBox.Text;
            string GetProductsQuery = "select 编号, 名称, 类别, 经费, 起始时间, 截止日期, 人数, 获奖情况,描述 from 项目表  where 名称='" + varible + "'or 编号='" + varible + "'";

            var data = SampleDataService.GetSampleModelData(GetProductsQuery);


            foreach (var item in data)
            {
                SampleItems.Add(item);

            }

            if (MasterDetailsViewControl.ViewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.FirstOrDefault();
            }
            
        }
       
    }
}
