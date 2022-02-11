using ChessGameManager.Dal;
using ChessGameManager.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace ViewModels
{
    public class ChessGameViewModel
    {
        public ObservableCollection<ChessGame> ChessGames { get;}
        public ChessGameViewModel()
        {
            ChessGames = new ObservableCollection<ChessGame>(RepositoryFactory.GetRepository().GetChessGames());
            ChessGames.CollectionChanged += ChessGames_CollectionChanged;
        }

        private void ChessGames_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddChessGame(ChessGames[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteChessGame(e.OldItems.OfType<ChessGame>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateChessGame(e.NewItems.OfType<ChessGame>().ToList()[0]);
                    break;
            }
        }

        internal void Update(ChessGame chessGame) => ChessGames[ChessGames.IndexOf(chessGame)] = chessGame;
    }
}