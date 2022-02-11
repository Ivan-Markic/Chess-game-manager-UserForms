using ChessGameManager.ViewModels;
using System.Windows.Controls;

namespace ChessGameManager.Pages
{
    public class FramedPagePerson : Page
    {
        public PersonViewModel PersonViewModel { get; }
        public Frame Frame { get; set; }

        public FramedPagePerson(PersonViewModel personViewModel)
        {
            PersonViewModel = personViewModel;
        }
        
    }
}
