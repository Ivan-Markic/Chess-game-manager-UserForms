using ChessGameManager.Models;
using ChessGameManager.ViewModels;
using System.Windows;
using System.Windows.Controls;
using ViewModels;

namespace ChessGameManager.Pages
{
    /// <summary>
    /// Interaction logic for ListChessGamesPage.xaml
    /// </summary>
    public partial class ListChessGamesPage : FramedPage
    {
        public ListChessGamesPage(ChessGameViewModel chessGameViewModel, PersonViewModel personViewModel) : base(chessGameViewModel, personViewModel)
        {
            InitializeComponent();
            LvChessGames.ItemsSource = chessGameViewModel.ChessGames;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvChessGames.SelectedItem != null)
            {
                Frame.Navigate(new EditChessGamePage(ChessGameViewModel, PersonViewModel, LvChessGames.SelectedItem as ChessGame) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvChessGames.SelectedItem != null)
            {
                ChessGameViewModel.ChessGames.Remove(LvChessGames.SelectedItem as ChessGame);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditChessGamePage(ChessGameViewModel, PersonViewModel) { Frame = Frame });

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.Navigate(new ListPeoplePage(new PersonViewModel()) { Frame = Frame });
    }
}
