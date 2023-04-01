using System;

namespace Game
{
  class Program {
    public static void Main (string[] args) {
      Console.Clear();
      Console.WriteLine ("Hello World");
      var board = new Board();
      var game = new ConnectFour();
      Console.WriteLine("Here is my board:");
      while (!game.IsOver())
      {
        Console.Write(board.PieceBoard(game.Pieces(), game.LastRow(), game.LastColumn()));
        Console.Write("Enter column for next piece: ");
        var input = Console.ReadLine();
        var col = int.Parse(input);
        game.PlacePiece(col - 1);
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
      }
      Console.Write(board.PieceBoard(game.Pieces(), game.WinLine()));
      Console.WriteLine($"Player {game.WhoWon()} won!");
    }
  }  
}

