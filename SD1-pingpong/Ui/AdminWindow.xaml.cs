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
using System.Windows.Shapes;

namespace Ui
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        private AdminController _adminController;

        public AdminWindow()
        {
            InitializeComponent();
            _adminController = new AdminController();  
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            //TODO check email format
            //TODO show confirmation window
            var succeded = _adminController.AddPlayer(playerEmailTextbox.Text, playerNameTextbox.Text, playerPasswordTextbox.Text);

            var messageWindow = new MessageWindow();

            if (succeded)
            {
                messageWindow.messageTextLabel.Content = $"Successfully added player \'{playerNameTextbox.Text}\'";
            }
            else
            {
                messageWindow.messageTextLabel.Content = $"Failed to add player \'{playerNameTextbox.Text}\'";
            }
            messageWindow.Show();
        }

        private void UpdatePlayer_Click(object sender, RoutedEventArgs e)
        {
            var succeded = _adminController.UpdatePlayer(playerEmailTextbox.Text, playerNameTextbox.Text, playerPasswordTextbox.Text);

            var messageWindow = new MessageWindow();

            if (succeded)
            {
                messageWindow.messageTextLabel.Content = $"Successfully updated player \'{playerNameTextbox.Text}\'";
            }
            else
            {
                messageWindow.messageTextLabel.Content = $"Failed to update player \'{playerNameTextbox.Text}\'";
            }
            messageWindow.Show();
        }

        private void SelectPlayerName_Click(object sender, RoutedEventArgs e)
        {
            var player = _adminController.FindByName(playerNameTextbox.Text);
            if (player != null)
            {
                playerEmailTextbox.Text = player.Email;
                playerPasswordTextbox.Text = player.Password;
            }
            else
            {
                var result = MessageBox.Show("Player does not exist!");
            }

        }

        private void SelectPlayerEmail_Click(object sender, RoutedEventArgs e)
        {
            var player = _adminController.FindByName(playerNameTextbox.Text);
            if (player != null)
            {
                playerNameTextbox.Text = player.Name;
                playerPasswordTextbox.Text = player.Password;
            }
            else
            {
                var result = MessageBox.Show("Player does not exist!");
            }
        }

        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            var succeded = _adminController.DeletePlayer(playerEmailTextbox.Text, playerNameTextbox.Text, playerPasswordTextbox.Text);

            var messageWindow = new MessageWindow();

            if (succeded)
            {
                messageWindow.messageTextLabel.Content = $"Successfully deleted player \'{playerNameTextbox.Text}\'";
            }
            else
            {
                messageWindow.messageTextLabel.Content = $"Failed to delete player \'{playerNameTextbox.Text}\'";
            }
            messageWindow.Show();
        }
    }
}
