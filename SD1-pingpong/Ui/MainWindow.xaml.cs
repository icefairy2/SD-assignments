using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string emailText = emailBox.Text;
            string passwordText = passwordBox.Password.ToString();

            var login = new Login();
            var loginType = login.Execute(emailText, passwordText);

            switch (loginType)
            {
                case Login.UserLoginType.nonexistent_user:
                    {
                        var result = MessageBox.Show("User does not exist!");
                        break;
                    }
                case Login.UserLoginType.incorrect_password:
                    {
                        var result = MessageBox.Show("Incorrect password!");
                        break;
                    }
                case Login.UserLoginType.administrator:
                    {
                        var adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                        break;
                    }
                case Login.UserLoginType.player:
                    {
                        var userWindow = new UserWindow();
                        userWindow.Show();
                        this.Close();
                        break;
                    }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
