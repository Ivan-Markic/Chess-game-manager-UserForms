using ChessGameManager.Models;
using System.Collections.Generic;

namespace ChessGameManager.Dal
{
    interface IRepository
    {
        void AddChessGame(ChessGame chessGame);
        void DeleteChessGame(ChessGame chessGame);
        IList<ChessGame> GetChessGames();
        ChessGame GetChessGame(int idChessGame);
        void UpdateChessGame(ChessGame chessGame);
        void AddPerson(Person person); 
        void DeletePerson(Person person);
        IList<Person> GetPeople();
        Person GetPerson(int idPerson);
        void UpdatePerson(Person person);

    }
}