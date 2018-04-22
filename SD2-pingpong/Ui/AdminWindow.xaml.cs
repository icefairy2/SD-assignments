using Business;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Model;

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
            updatePlayers();
        }

        private void updatePlayers()
        {
            playersListbox.Items.Clear();
            var getPlayers = new GetPlayers();
            var allPlayers = getPlayers.Execute();
            foreach (Model.User user in allPlayers)
            {
                playersListbox.Items.Add(user.Name);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            var succeded = _adminController.AddPlayer(playerEmailTextbox.Text, playerNameTextbox.Text, playerPasswordTextbox.Text);

            if (succeded)
            {
                MessageBox.Show($"Successfully added player \'{playerNameTextbox.Text}\'");
                updatePlayers();
            }
            else
            {
                MessageBox.Show($"Failed to add player \'{playerNameTextbox.Text}\'");
            }
        }

        private void UpdatePlayer_Click(object sender, RoutedEventArgs e)
        {
            var succeded = _adminController.UpdatePlayer(playerEmailTextbox.Text, playerNameTextbox.Text, playerPasswordTextbox.Text);

            if (succeded)
            {
                MessageBox.Show($"Successfully updated player \'{playerNameTextbox.Text}\'");
            }
            else
            {
                MessageBox.Show($"Failed to update player \'{playerNameTextbox.Text}\'");
            }
        }

        private void SelectPlayerName_Click(object sender, RoutedEventArgs e)
        {
            var player = _adminController.FindByName(playerNameTextbox.Text);

            if (player != null)
            {
                playerEmailTextbox.Text = player.Email;
                playerPasswordTextbox.Text = player.Password;
                MessageBox.Show($"Found player name: {player.Name}, email: {player.Email}, password: {player.Password}");
            }
            else
            {
                var result = MessageBox.Show("Player does not exist!");
            }

        }

        private void SelectPlayerEmail_Click(object sender, RoutedEventArgs e)
        {
            var player = _adminController.FindByEmail(playerEmailTextbox.Text);
            if (player != null)
            {
                playerNameTextbox.Text = player.Name;
                playerPasswordTextbox.Text = player.Password;
                MessageBox.Show($"Found player name: {player.Name}, email: {player.Email}, password: {player.Password}");
            }
            else
            {
                var result = MessageBox.Show("Player does not exist!");
            }
        }

        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            var succeded = _adminController.DeletePlayer(playerEmailTextbox.Text, playerNameTextbox.Text, playerPasswordTextbox.Text);

            if (succeded)
            {
                MessageBox.Show($"Successfully deleted player \'{playerNameTextbox.Text}\'");
            }
            else
            {
                MessageBox.Show($"Failed to delete player \'{playerNameTextbox.Text}\'");
            }
        }

        private void addTournamentButton_Click(object sender, RoutedEventArgs e)
        {
            var tournamentName = tournamentNameTextbox.Text;

            var selectedPlayers = playersListbox.SelectedItems;
            if (selectedPlayers.Count != 8)
            {
                MessageBox.Show($"You need to select 8 players to add them to the tournament");
                return;
            }

            var succeded = _adminController.AddTournament(tournamentName);

            if (succeded)
            {
                MessageBox.Show($"Successfully added tournament \'{tournamentName}\'");
                var getTournaments = new GetTournaments();
                var tournament = getTournaments.GetByName(tournamentName);
                var createMatches = new CreateMatches();
                var selectedUserList = new List<User>();
                foreach (var selUser in selectedPlayers)
                {
                    var newUser = new User();
                    newUser.Name = selUser.ToString();
                    selectedUserList.Add(newUser);
                }
                var succeededMatches = createMatches.Execute(tournament, selectedUserList);
            }
            else
            {
                MessageBox.Show($"Failed to add tournament \'{tournamentNameTextbox.Text}\'");
            }
        }

        private void findTournamentButton_Click(object sender, RoutedEventArgs e)
        {
            var succeded = _adminController.FindTournament(tournamentNameTextbox.Text);

            if (succeded)
            {
                MessageBox.Show($"Successfully found tournament \'{tournamentNameTextbox.Text}\'");
            }
            else
            {
                MessageBox.Show($"Failed to add tournament \'{tournamentNameTextbox.Text}\'");
            }
        }

        private void playerNameListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updatePlayers();
        }
    }
}
