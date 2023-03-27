using Xunit;
using System;
using System.Linq;

namespace Game
{
  public class ConnectFourTests
  {
    [Fact]
    void can_new_up_connect_four_game()
    {
      var game = new ConnectFour();
    }
    
    [Fact]
    void new_board_is_empty()
    {
      var game = new ConnectFour();

      int[,] pieces = new int[,] {
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0}
      };

      var currentPieces = game.Pieces();

      Assert.True(ArraysEqual(pieces, currentPieces));
    }

    [Fact]
    void can_place_first_piece()
    {
      var game = new ConnectFour();

      int[,] pieces = new int[,] {
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {1,0,0,0,0,0,0}
      };

      game.PlacePiece(1, 0);
      var currentPieces = game.Pieces();

      //ConsoleDisplayPieces(pieces);
      //ConsoleDisplayPieces(currentPieces);

      Assert.True(ArraysEqual(pieces, currentPieces));
    }

    [Fact]
    void can_place_many_pieces()
    {
      var game = new ConnectFour();

      int[,] pieces = new int[,] {
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,2,0,0},
        {0,0,0,0,1,0,0},
        {0,1,0,0,2,0,0},
        {1,2,0,0,1,0,2}
      };

      game.PlacePiece(1, 0);
      game.PlacePiece(2, 1);
      game.PlacePiece(1, 1);
      game.PlacePiece(2, 6);
      game.PlacePiece(1, 4);
      game.PlacePiece(2, 4);
      game.PlacePiece(1, 4);
      game.PlacePiece(2, 4);
      var currentPieces = game.Pieces();

      //ConsoleDisplayPieces(pieces);
      //ConsoleDisplayPieces(currentPieces);

      Assert.True(ArraysEqual(pieces, currentPieces));
    }

    [Fact]
    void if_column_is_full_error_is_thrown()
    {
      var game = new ConnectFour();

      int[,] pieces = new int[,] {
        {0,0,0,0,2,0,0},
        {0,0,0,0,1,0,0},
        {0,0,0,0,2,0,0},
        {0,0,0,0,1,0,0},
        {0,0,0,0,2,0,0},
        {0,0,0,0,1,0,0}
      };

      game.SetAllPieces(pieces);
      
      var currentPieces = game.Pieces();

      //ConsoleDisplayPieces(pieces);
      //ConsoleDisplayPieces(currentPieces);
      
      Assert.Throws<Exception>(() => game.PlacePiece(1, 4));
    }

    void ConsoleDisplayPieces(int[,] pieces)
    {
      var board = new Board();
      Console.Write(board.PieceBoard(pieces));
    }
    
    bool ArraysEqual(int[,] array1, int[,] array2)
    {
      return array1.Rank == array2.Rank &&
          Enumerable.Range(0, array1.Rank).All(dimension => array1.GetLength(dimension) == array2.GetLength(dimension)) &&
          array1.Cast<int>().SequenceEqual(array2.Cast<int>());
    }  
  }
}