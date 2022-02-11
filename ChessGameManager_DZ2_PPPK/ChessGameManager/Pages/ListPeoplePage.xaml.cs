using ChessGameManager.Models;
using ChessGameManager.ViewModels;
using System.Windows;
using System.Windows.Controls;
using ViewModels;

namespace ChessGameManager.Pages
{
    /// <summary>
    /// Interaction logic for ListPeoplePage.xaml
    /// </summary>
    public partial class ListPeoplePage : FramedPagePerson
    {
        public ListPeoplePage(PersonViewModel personViewModel) : base(personViewModel)
        {
            InitializeComponent();
            LvUsers.ItemsSource = personViewModel.People;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e) 
        {
            if (LvUsers.SelectedItem != null)
            {
                Frame.Navigate(new EditPersonPage(PersonViewModel, LvUsers.SelectedItem as Person) { Frame = Frame });
            }
}
        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditPersonPage(PersonViewModel) { Frame = Frame });

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvUsers.SelectedItem != null)
            {
                PersonViewModel.People.Remove(LvUsers.SelectedItem as Person);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.Navigate(new ListChessGamesPage(new ChessGameViewModel(), PersonViewModel) { Frame = Frame });
    }
}
