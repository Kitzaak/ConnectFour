using Xunit;
using Xunit.Abstractions;
using System;
using System.Linq;
using System.Diagnostics;

namespace Game
{
  public class ConnectFourTests
  {
    private readonly ITestOutputHelper Output;

    public ConnectFourTests(ITestOutputHelper output)
    {
        this.Output = output;
    }

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

      game.PlacePiece(0);
      var currentPieces = game.Pieces();

      // Output.WriteLine("Expected:");
      // ConsoleDisplayPieces(pieces);
      // Output.WriteLine("Actual:");
      // ConsoleDisplayPieces(currentPieces);

      Assert.True(ArraysEqual(pieces, currentPieces));
      Assert.Equal(0, game.LastColumn());
      Assert.Equal(5, game.LastRow());
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

      game.PlacePiece(0);
      game.PlacePiece(1);
      game.PlacePiece(1);
      game.PlacePiece(6);
      game.PlacePiece(4);
      game.PlacePiece(4);
      game.PlacePiece(4);
      game.PlacePiece(4);
      var currentPieces = game.Pieces();

      // Output.WriteLine("Expected:");
      // ConsoleDisplayPieces(pieces);
      // Output.WriteLine("Actual:");
      // ConsoleDisplayPieces(currentPieces);

      Assert.True(ArraysEqual(pieces, currentPieces));
      Assert.Equal(4, game.LastColumn());
      Assert.Equal(2, game.LastRow());
    }

    [Fact]
    void can_identify_cats_game()
    {
      var game = new ConnectFour();

      int[,] pieces = new int[,] {
        {2,1,2,1,2,1,2},
        {2,1,2,1,2,1,2},
        {2,1,2,1,2,1,2},
        {1,2,1,2,1,2,1},
        {1,2,1,2,1,2,1},
        {1,2,1,2,1,2,1}
      };

      game.SetAllPieces(pieces);
      //var currentPieces = game.Pieces();

      // Output.WriteLine("Expected:");
      // ConsoleDisplayPieces(pieces);
      // Output.WriteLine("Actual:");
      // ConsoleDisplayPieces(currentPieces);

      Assert.False(game.IsWin());
      Assert.Equal(0, game.WhoWon());
      Assert.True(game.IsOver());
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
      
      Assert.Throws<Exception>(() => game.PlacePiece(4));
    }

    [Fact]
    void new_game_is_not_won()
    {
      var game = new ConnectFour();

      Assert.False(game.IsWin());
      Assert.Equal(0, game.WhoWon());
      Assert.False(game.IsOver());
      Assert.Equal(-1, game.LastColumn());
      Assert.Equal(-1, game.LastRow());
    }

    [Fact]
    void can_win_game_vitically()
    {
      var game = new ConnectFour();

      int[,] pieces = new int[,] {
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,1,0,0},
        {0,0,0,0,1,0,0},
        {0,0,0,0,1,0,0},
        {0,0,0,0,1,0,0}
      };
      game.SetAllPieces(pieces);

      Assert.True(game.IsWin());
      Assert.Equal(1, game.WhoWon());
      Assert.True(game.IsOver());
    }

    [Fact]
    void can_win_game_horizontally()
    {
      var game = new ConnectFour();

      int[,] pieces = new int[,] {
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,2,2,2,2,0,0}
      };
      game.SetAllPieces(pieces);

      Assert.True(game.IsWin());
      Assert.Equal(2, game.WhoWon());
      Assert.True(game.IsOver());
    }

    [Fact]
    void can_win_game_diagonally_down()
    {
      var game = new ConnectFour();

      int[,] pieces = new int[,] {
        {0,0,0,0,0,0,0},
        {0,0,0,1,0,0,0},
        {0,0,0,0,1,0,0},
        {0,0,0,0,0,1,0},
        {0,0,0,0,0,0,1},
        {0,0,0,0,0,0,0}
      };
      game.SetAllPieces(pieces);

      Assert.True(game.IsWin());
      Assert.Equal(1, game.WhoWon());
      Assert.True(game.IsOver());
    }

    [Fact]
    void can_win_game_diagonally_up()
    {
      var game = new ConnectFour();

      int[,] pieces = new int[,] {
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,2,0},
        {0,0,0,0,2,0,0},
        {0,0,0,2,0,0,0},
        {0,0,2,0,0,0,0}
      };
      game.SetAllPieces(pieces);

      Assert.True(game.IsWin());
      Assert.Equal(2, game.WhoWon());
      Assert.True(game.IsOver());
    }

    void ConsoleDisplayPieces(int[,] pieces)
    {
      var board = new Board();
      Output.WriteLine(board.PieceBoard(pieces));
    }
    
    bool ArraysEqual(int[,] array1, int[,] array2)
    {
      return array1.Rank == array2.Rank &&
          Enumerable.Range(0, array1.Rank).All(dimension => array1.GetLength(dimension) == array2.GetLength(dimension)) &&
          array1.Cast<int>().SequenceEqual(array2.Cast<int>());
    }  
  }
}