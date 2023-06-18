using System;

namespace Game
{
  public class UI
  {
    ConnectFour _game;
    Board _board;

    public UI(ConnectFour game, Board board)
    {
      _game = game;
      _board = board;
    }

    public string StartScreen()
    {
      var display = "Hello World\n";
      display += "Let's play Connect Four!\n";

      display += _board.PieceBoard(_game.Pieces(), _game.LastRow(), _game.LastColumn());
      display += $"Enter column for next piece: ";

      return display;
    }

    public string UserMove(string input)
    {
      var display = "";
      var message = "";
      try
      {
        var col = int.Parse(input);
        _game.PlacePiece(col - 1);
      }
      catch(Exception ex)
      {
        message = ex.Message;
      }
      display += message + "\n\n";
      display += _board.PieceBoard(_game.Pieces(), _game.LastRow(), _game.LastColumn());
      display += $"Enter column for next piece: ";

      return display;
    }

    public string DisplayWin()
    {
      var display = "\n\n";
      display += _board.PieceBoard(_game.Pieces(), _game.WinLine());
      display += $"Player {_game.WhoWon()} won!";

      return display;
    }
  }
}