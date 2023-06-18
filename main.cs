using System;

namespace Game
{
  class Program {
    public static void Main (string[] args) {
      Console.Clear();
      var board = new Board();
      var game = new ConnectFour();
      var ui = new UI(game, board);
      Console.Write(ui.StartScreen());

      while (!game.IsOver())
      {
        var input = Console.ReadLine();
        Console.Clear();
        Console.Write(ui.UserMove(input));    
      }
      Console.Clear();
      Console.Write(ui.DisplayWin());
    }
  }  
}

