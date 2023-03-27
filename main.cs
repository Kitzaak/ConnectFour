using System;

namespace Game
{
  class Program {
    public static void Main (string[] args) {
      Console.WriteLine ("Hello World");
      var board = new Board();
      Console.WriteLine("Here is my board:");
      Console.Write(board.EmptyBoard());
    }
  }  
}

