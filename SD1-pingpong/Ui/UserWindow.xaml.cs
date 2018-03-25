using Business;
using Entity;
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private Tournament currentTournament;
        private Match currentMatch;

        public UserWindow()
        {
            InitializeComponent();
            var getTournaments = new GetTournaments();
            var allTournaments = getTournaments.GetAll();
            foreach (Tournament trn in allTournaments)
            {
                tounamentList.Items.Add(trn.Name);
            }
        }

        private void tounamentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearScores();

            var getTournaments = new GetTournaments();
            var tournament = getTournaments.GetByName(tounamentList.SelectedItem.ToString());
            currentTournament = tournament;
            labelPlayer11.Content = tournament.Matches[0].Player1.Name;
            labelPlayer12.Content = tournament.Matches[1].Player2.Name;
            labelPlayer13.Content = tournament.Matches[2].Player1.Name;
            labelPlayer14.Content = tournament.Matches[3].Player2.Name;
            labelPlayer15.Content = tournament.Matches[4].Player1.Name;
            labelPlayer16.Content = tournament.Matches[5].Player2.Name;
            labelPlayer17.Content = tournament.Matches[6].Player1.Name;
            labelPlayer18.Content = tournament.Matches[7].Player2.Name;

            if (tournament.Matches[0].Player1.Equals(Login.LoggedInUser) || tournament.Matches[1].Player1.Equals(Login.LoggedInUser))
            {
                currentMatch = tournament.Matches[0];
                match1P1.IsReadOnly = false;
                match1P2.IsReadOnly = false;
            }
            if (tournament.Matches[2].Player1.Equals(Login.LoggedInUser) || tournament.Matches[3].Player1.Equals(Login.LoggedInUser))
            {
                currentMatch = tournament.Matches[2];
                match2P1.IsReadOnly = false;
                match2P2.IsReadOnly = false;
            }
            if (tournament.Matches[4].Player1.Equals(Login.LoggedInUser) || tournament.Matches[5].Player1.Equals(Login.LoggedInUser))
            {
                currentMatch = tournament.Matches[4];
                match3P1.IsReadOnly = false;
                match3P2.IsReadOnly = false;
            }
            if (tournament.Matches[6].Player1.Equals(Login.LoggedInUser) || tournament.Matches[7].Player1.Equals(Login.LoggedInUser))
            {
                currentMatch = tournament.Matches[6];
                match4P1.IsReadOnly = false;
                match4P2.IsReadOnly = false;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.match1P1.Text) && !string.IsNullOrWhiteSpace(this.match1P2.Text))
            {
                var saveScore = new SaveScore();
                var response = saveScore.Execute(currentMatch, match1P1.Text, match1P2.Text);
                switch (response)
                {
                    case SaveScore.ScoreResponeType.nonnumeric:
                        {
                            var result = MessageBox.Show("Pleae input numbers!");
                            break;
                        }
                    case SaveScore.ScoreResponeType.too_big_values:
                        {
                            var result = MessageBox.Show("Please input realistic scores!");
                            break;
                        }
                    case SaveScore.ScoreResponeType.player1_won:
                        {
                            labelPlayer21.Content = currentMatch.Player1.Name;
                            break;
                        }
                    case SaveScore.ScoreResponeType.player2_won:
                        {
                            labelPlayer21.Content = currentMatch.Player2.Name;
                            break;
                        }
                }

            }

        }

        public void ClearScores()
        {
            match1P1.Clear();
            match1P2.Clear();
        }
    }
}
