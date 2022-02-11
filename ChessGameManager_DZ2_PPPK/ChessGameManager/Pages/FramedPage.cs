using ChessGameManager.ViewModels;
using System.Windows.Controls;
using ViewModels;

namespace ChessGameManager.Pages
{
    public class FramedPage : Page
    {
        public ChessGameViewModel ChessGameViewModel { get;}
        public PersonViewModel PersonViewModel { get;}

        public Frame Frame { get; set; }

        public FramedPage(ChessGameViewModel chessGameViewModel, PersonViewModel personViewModel)
        {
            ChessGameViewModel = chessGameViewModel;
            PersonViewModel = personViewModel;

        }
    }
}
