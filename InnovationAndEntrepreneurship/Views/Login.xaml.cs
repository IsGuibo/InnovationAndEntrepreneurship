using InnovationAndEntrepreneurship.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace InnovationAndEntrepreneurship.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    /// 
    public sealed partial class Login : Page
    {

        public Login()
        {
            this.InitializeComponent();

        }
        public void PassportSignInButton_Click(object sender, RoutedEventArgs e)
        {

            string username = UsernameTextBox.Text;
            string passwords = PasswordsTextBox.Password;
            string connectionString = "Data Source=SURFACELAPTOP;Initial Catalog=创新创业管理系统;Persist Security Info=True;User ID=" + username + ";Password=" + passwords;
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                LoginFrame.Navigate(typeof(ShellPage));

            }
            catch (Exception error)
            {
               
                DisplayLoginFailedDialog(error.ToString());  
            }

        }
        private static async void DisplayLoginFailedDialog(string e)
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = " Login Failed!",
                Content=e,

                CloseButtonText = "Ok"
            };

            await dialog.ShowAsync();
        }

        private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
        
        }
    }
}
