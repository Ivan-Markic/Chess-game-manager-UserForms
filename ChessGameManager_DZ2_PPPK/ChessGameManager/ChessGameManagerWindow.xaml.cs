using ChessGameManager.Pages;
using ChessGameManager.ViewModels;
using System.Windows;
using System.Windows.Controls;
using ViewModels;

namespace ChessGameManager
{
    /// <summary>
    /// Interaction logic for ChessGameManagerWindow.xaml
    /// </summary>
    public partial class ChessGameManagerWindow : Window
    {
        public ChessGameManagerWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BtnOpenPlayers_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListPeoplePage(new PersonViewModel()) { Frame = Frame });
        }

        private void BtnOpenChessGames_Click(object sender, RoutedEventArgs e)
        => Frame.Navigate(new ListChessGamesPage(new ChessGameViewModel(), new PersonViewModel()) { Frame = Frame });
        
    }
}
