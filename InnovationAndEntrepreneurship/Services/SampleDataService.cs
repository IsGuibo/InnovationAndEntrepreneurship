using InnovationAndEntrepreneurship.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace InnovationAndEntrepreneurship.Services
{
    // This class holds sample data used by some generated pages to show how they can be used.
    // TODO WTS: Delete this file once your app is using real data.
    public static class SampleDataService
    {
        private static readonly string connectionString = "Data Source=SURFACELAPTOP;Initial Catalog=创新创业管理系统;Persist Security Info=True;User ID=admin;Password=huang980302";
        private static IEnumerable<XM> AllOrders(string GetProductsQuery)
        {
            // The following is order summary data
            var xmlist = new ObservableCollection<XM>();

            try
            {
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                
                                while (reader.Read())
                                {
                                    var product = new XM
                                    {
                                        xmbh = reader.GetString(0),
                                        xmmz = reader.GetString(1),
                                        xmlb = reader.GetString(2),
                                        qssj = reader.GetDateTime(3),
                                        jzsj = reader.GetDateTime(4),
                                        xmjb = reader.GetString(5),
                                        xmjf = reader.GetString(6),



                                    };
                                    xmlist.Add(product);
                                }
                            }
                        }
                    }
                }
                return xmlist;
            }

            catch (Exception eSql)
            {
                string e = eSql.ToString();
                DisplayNoWifiDialog(e);
            }
            return xmlist;

        }


        private static IEnumerable<XM> AllOrders(string GetProductsQuery)
        {
            // The following is order summary data
            var xmlist = new ObservableCollection<XM>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    var product = new XM
                                    {
                                        xmbh = reader.GetString(0),
                                        xmmz = reader.GetString(1),
                                        xmlb = reader.GetString(2),
                                        qssj = reader.GetDateTime(3),
                                        jzsj = reader.GetDateTime(4),
                                        xmjb = reader.GetString(5),
                                        xmjf = reader.GetString(6),



                                    };
                                    xmlist.Add(product);
                                }
                            }
                        }
                    }
                }
                return xmlist;
            }

            catch (Exception eSql)
            {
                string e = eSql.ToString();
                DisplayNoWifiDialog(e);
            }
            return xmlist;

        }



        // TODO WTS: Remove this once your chart page is displaying real data
        public static ObservableCollection<DataPoint> GetChartSampleData(string GetProductsQuery)
        {
            var data = AllOrders(GetProductsQuery).Select(o => new DataPoint() { Category = o.PName, Value = o.count })
                                  .OrderBy(dp => dp.Category);

            return new ObservableCollection<DataPoint>(data);
        }

        // TODO WTS: Remove this once your MasterDetail pages are displaying real data

        public static IEnumerable<XM> GetSampleModelData(string GetProductsQuery)
        {

            return AllOrders(GetProductsQuery);
        }




        private static async void DisplayNoWifiDialog(String e)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Query Error!",
                Content = e,
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();
        }
        private static  void DisplayNoWifiDialog1()
        {
            ProgressRing progressRing = new ProgressRing
            {
                IsActive = true
            };
            progressRing.IsActive = true;
        }



        // TODO WTS: Remove this once your grid page is displaying real data
        public static ObservableCollection<XM> GetGridSampleData(string GetProductsQuery)
        {
            return new ObservableCollection<XM>(AllOrders(GetProductsQuery));
        }
    }

}
