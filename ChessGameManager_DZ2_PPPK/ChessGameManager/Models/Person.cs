using ChessGameManager.Utils;
using System.Windows.Media.Imaging;

namespace ChessGameManager.Models
{
    public class Person
    {
        public int IDPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }
        public BitmapImage Image
        {
            get => ImageUtils.ByteArrayToBitmapImage(Picture);
        }

        public override int GetHashCode()
        => IDPerson.GetHashCode();

        public override bool Equals(object obj)
        => obj is Person other ? other.IDPerson.Equals(IDPerson) : false; 
    }
}
