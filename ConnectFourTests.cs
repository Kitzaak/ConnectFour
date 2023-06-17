using Xunit;
using Xunit.Abstractions;
using System;
using System.Linq;

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
    void new_game_is_not_won()
    {
      var game = new ConnectFour();
      int[,] winline = new int[,] {
        {-1,-1},
        {-1,-1},
        {-1,-1},
        {-1,-1}
      };

      Assert.False(game.IsWin());
      Assert.Equal(0, game.WhoWon());
      Assert.False(game.IsOver());
      Assert.Equal(-1, game.LastColumn());
      Assert.Equal(-1, game.LastRow());
      Assert.Equal(winline, game.WinLine());
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
      
      Assert.Throws<Exception>(() => game.PlacePiece(4));
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
      int[,] winline = new int[,] {
        {2,4},
        {3,4},
        {4,4},
        {5,4}
      };

      game.SetAllPieces(pieces);

      Assert.True(game.IsWin());
      Assert.Equal(1, game.WhoWon());
      Assert.True(game.IsOver());
      Assert.Equal(winline, game.WinLine());
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
      int[,] winline = new int[,] {
        {5,1},
        {5,2},
        {5,3},
        {5,4}
      };

      game.SetAllPieces(pieces);

      Assert.True(game.IsWin());
      Assert.Equal(2, game.WhoWon());
      Assert.True(game.IsOver());
      Assert.Equal(winline, game.WinLine());
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
      int[,] winline = new int[,] {
        {1,3},
        {2,4},
        {3,5},
        {4,6}
      };

      game.SetAllPieces(pieces);

      Assert.True(game.IsWin());
      Assert.Equal(1, game.WhoWon());
      Assert.True(game.IsOver());
      Assert.Equal(winline, game.WinLine());
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
      int[,] winline = new int[,] {
        {5,2},
        {4,3},
        {3,4},
        {2,5}
      };

      game.SetAllPieces(pieces);

      Assert.True(game.IsWin());
      Assert.Equal(2, game.WhoWon());
      Assert.True(game.IsOver());
      Assert.Equal(winline, game.WinLine());
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