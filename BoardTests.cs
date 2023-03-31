using Xunit;

namespace Game
{
  public class BoardTests
  {
    [Fact]
    void new_board_is_empty()
    {
      var board = new Board();

      var screen = "";
      screen += board.SpecialRow("numbers") + "\n";
      screen += board.SpecialRow("top") + "\n";
      screen += board.EmptyPieceRow(0) + "\n";
      screen += board.EmptyPieceRow(1) + "\n";
      screen += board.EmptyPieceRow(2) + "\n";
      screen += board.EmptyPieceRow(3) + "\n";
      screen += board.EmptyPieceRow(4) + "\n";
      screen += board.EmptyPieceRow(5) + "\n";
      screen += board.SpecialRow("bottom") + "\n";
      
      Assert.Equal(
        "  1   2   3   4   5   6   7\n" +
        "-----------------------------\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "=============================\n", screen);
    }

    [Fact]
    void board_displays_number_row()
    {
      var board = new Board();

      var row = board.SpecialRow("numbers");

      Assert.Equal("  1   2   3   4   5   6   7", row);
    }

    [Fact]
    void board_displays_top_edge()
    {
      var board = new Board();

      var row = board.SpecialRow("top");

      Assert.Equal("-----------------------------", row);
    }

    [Fact]
    void board_displays_bottom_edge()
    {
      var board = new Board();

      var row = board.SpecialRow("bottom");

      Assert.Equal("=============================", row);
    }

    [Fact]
    void board_can_display_empty_row()
    {
      var board = new Board();

      var row = board.EmptyPieceRow(0);

      Assert.Equal("| . | . | . | . | . | . | . |", row);
    }

    [Fact]
    void board_can_display_row_with_one_x()
    {
      var board = new Board();

      int[] pieces = new int[] {1,0,0,0,0,0,0};
      var row = board.PieceRow(pieces, 0);

      Assert.Equal("| X | . | . | . | . | . | . |", row);
    }

    [Fact]
    void board_displays_multiple_pieces()
    {
      var board = new Board();

      int[] pieces = new int[] {1,0,2,1,0,2,0};
      var row = board.PieceRow(pieces, 0);   

      Assert.Equal("| X | . | O | X | . | O | . |", row);
    }

    [Fact]
    void board_displays_from_2_dimension_array()
    {
      var board = new Board();

      string expectedScreen = "  1   2   3   4   5   6   7\n" +
        "-----------------------------\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "=============================\n";

      int[,] pieces = new int[,] {
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0}
      };
      
      Assert.Equal(expectedScreen, board.PieceBoard(pieces));
    }
    
    [Fact]
    void board_displays_from_2_dimension_array_with_pieces()
    {
      var board = new Board();

      string expectedScreen = "  1   2   3   4   5   6   7\n" +
        "-----------------------------\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | X | . | . |\n" +
        "| . | . | . | O | O | X | . |\n" +
        "| X | O | X | O | X | O | X |\n" +
        "=============================\n";

      int[,] pieces = new int[,] {
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,1,0,0},
        {0,0,0,2,2,1,0},
        {1,2,1,2,1,2,1}
      };
      
      Assert.Equal(expectedScreen, board.PieceBoard(pieces));
    }
    
    [Fact]
    void board_marks_last_piece()
    {
      var board = new Board();

      string expectedScreen = "  1   2   3   4   5   6   7\n" +
        "-----------------------------\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . | . | . | . |\n" +
        "| . | . | . | . |-X-| . | . |\n" +
        "| . | . | . | O | O | X | . |\n" +
        "| X | O | X | O | X | O | X |\n" +
        "=============================\n";

      int[,] pieces = new int[,] {
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,1,0,0},
        {0,0,0,2,2,1,0},
        {1,2,1,2,1,2,1}
      };

      int row = 3;
      int col = 4;
      
      Assert.Equal(expectedScreen, board.PieceBoard(pieces, row, col));
    }
  }
}