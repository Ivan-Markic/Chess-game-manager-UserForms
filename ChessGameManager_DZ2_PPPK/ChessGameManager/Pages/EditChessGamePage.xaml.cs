using ChessGameManager.Models;
using ChessGameManager.Utils;
using ChessGameManager.ViewModels;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ViewModels;

namespace ChessGameManager.Pages
{
    /// <summary>
    /// Interaction logic for EditChessGamePage.xaml
    /// </summary>
    public partial class EditChessGamePage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly ChessGame chessGame;
        //private readonly Person firstPlayer;

        public EditChessGamePage(ChessGameViewModel chessGameViewModel, PersonViewModel personViewModel, ChessGame chessGame = null) : base(chessGameViewModel, personViewModel)
        {
            InitializeComponent();

            if (chessGame == null)
            {
                this.chessGame = new ChessGame();
                this.chessGame.FirstPlayer = new Person();
                this.chessGame.SecondPlayer = new Person();
            }
            else
                this.chessGame = chessGame;

             DataContext = chessGame;
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                fillChessGame();

                if (chessGame.IDChessGame == 0)
                {
                    ChessGameViewModel.ChessGames.Add(chessGame);
                }
                else
                {
                    ChessGameViewModel.Update(chessGame);
                }
                Frame.NavigationService.GoBack();
            }
        }

        private void fillChessGame()
        {
            chessGame.GameLocation = TbGameLocation.Text.Trim();

            //First Player
            chessGame.FirstPlayer.Age = int.Parse(TbFirstPlayerAge.Text.Trim());
            chessGame.FirstPlayer.Email = TbFirstPlayerEmail.Text.Trim();
            chessGame.FirstPlayer.FirstName = TbFirstPlayerFirstName.Text.Trim();
            chessGame.FirstPlayer.LastName = TbFirstPlayerLastName.Text.Trim();
            chessGame.FirstPlayer.Picture = ImageUtils.BitmapImageToByteArray(PictureFirstPlayer.Source as BitmapImage);
            if (chessGame.FirstPlayer.IDPerson == 0)
            {
                PersonViewModel.People.Add(chessGame.FirstPlayer);
            }
            else
            {
                PersonViewModel.Update(chessGame.FirstPlayer);
            }

            //Second player
            chessGame.SecondPlayer.Age = int.Parse(TbSecondPlayerAge.Text.Trim());
            chessGame.SecondPlayer.Email = TbSecondPlayerEmail.Text.Trim();
            chessGame.SecondPlayer.FirstName = TbSecondPlayerFirstName.Text.Trim();
            chessGame.SecondPlayer.LastName = TbSecondPlayerLastName.Text.Trim();
            chessGame.SecondPlayer.Picture = ImageUtils.BitmapImageToByteArray(PictureSecondPlayer.Source as BitmapImage);
            if (chessGame.SecondPlayer.IDPerson == 0)
            {
                PersonViewModel.People.Add(chessGame.SecondPlayer);
            }
            else
            {
                PersonViewModel.Update(chessGame.SecondPlayer);
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age))
                    || ("Email".Equals(e.Tag) && !ValidationUtils.isValidEmail(e.Text.Trim())))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            //cheking photos
            valid &= validPicture(PictureFirstPlayer, PictureBorderFirstPlayer);
            valid &= validPicture(PictureSecondPlayer, PictureBorderSecondPlayer);
           
            return valid;
        }

        private bool validPicture(Image picturePlayer, Border pictureBorderPlayer)
        {
            if (picturePlayer.Source == null)
            {
                pictureBorderPlayer.BorderBrush = Brushes.LightCoral;
                return false;
            }
            else
            {
                pictureBorderPlayer.BorderBrush = Brushes.WhiteSmoke;
                return true;
            }
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = Filter
            };
            if (openFileDialog.ShowDialog() == true)
            {
                if (button.Name.Equals("BtnUploadFirstPlayer"))
                    PictureFirstPlayer.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                
                else
                    PictureSecondPlayer.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
