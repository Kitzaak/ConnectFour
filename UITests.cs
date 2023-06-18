using Xunit;

namespace Game
{
  public class UITests
  {
    [Fact]
    void can_new_UI()
    {
      var ui = new UI(new ConnectFour(), new Board());
      
      var startScreen = "Hello World\n" +
          "Let's play Connect Four!\n" +
          "  1   2   3   4   5   6   7\n" +
          "-----------------------------\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "=============================\n" +
          "Enter column for next piece: ";

      Assert.Equal(startScreen, ui.StartScreen());
    }

    [Fact]
    void display_first_move()
    {
      var ui = new UI(new ConnectFour(), new Board());
      var firstMove = "\n" +
          "\n" +
          "  1   2   3   4   5   6   7\n" +
          "-----------------------------\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . |-X-| . | . | . |\n" +
          "=============================\n" +
          "Enter column for next piece: ";

      ui.StartScreen();
      
      Assert.Equal(firstMove, ui.UserMove("4"));
    }

    [Fact]
    void display_second_move()
    {
      var ui = new UI(new ConnectFour(), new Board());

      var firstMove = "\n" +
          "\n" +
          "  1   2   3   4   5   6   7\n" +
          "-----------------------------\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . |-O-| . | . | . |\n" +
          "| . | . | . | X | . | . | . |\n" +
          "=============================\n" +
          "Enter column for next piece: ";

      ui.StartScreen();
      ui.UserMove("4");

      Assert.Equal(firstMove, ui.UserMove("4"));
    }

    [Fact]
    void display_win()
    {
      var ui = new UI(new ConnectFour(), new Board());

      var firstMove = "\n" +
          "\n" +
          "  1   2   3   4   5   6   7\n" +
          "-----------------------------\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | X |-X-| . | . |\n" +
          "| . | . | . |-X-| O | . | . |\n" +
          "| . | . |-X-| O | O | . | . |\n" +
          "| . |-X-| O | X | O | . | . |\n" +
          "=============================\n" +
          "Player 1 won!";

      ui.StartScreen();
      ui.UserMove("4");
      ui.UserMove("4");
      ui.UserMove("4");
      ui.UserMove("3");
      ui.UserMove("3");
      ui.UserMove("5");
      ui.UserMove("2");
      ui.UserMove("5");
      ui.UserMove("4");
      ui.UserMove("5");
      ui.UserMove("5");

      Assert.Equal(firstMove, ui.DisplayWin());
    }

    [Fact]
    void display_column_full_error()
    {
      var ui = new UI(new ConnectFour(), new Board());

      var firstMove = "Column full\n" +
          "\n" +
          "  1   2   3   4   5   6   7\n" +
          "-----------------------------\n" +
          "| . | . | . |-O-| . | . | . |\n" +
          "| . | . | . | X | . | . | . |\n" +
          "| . | . | . | O | . | . | . |\n" +
          "| . | . | . | X | . | . | . |\n" +
          "| . | . | . | O | . | . | . |\n" +
          "| . | . | . | X | . | . | . |\n" +
          "=============================\n" +
          "Enter column for next piece: ";

      ui.StartScreen();
      ui.UserMove("4");
      ui.UserMove("4");
      ui.UserMove("4");
      ui.UserMove("4");
      ui.UserMove("4");
      ui.UserMove("4");

      Assert.Equal(firstMove, ui.UserMove("4"));
    }

    [Fact]
    void display_empty_input_error()
    {
      var ui = new UI(new ConnectFour(), new Board());

      var firstMove = "The input string '' was not in a correct format.\n" +
          "\n" +
          "  1   2   3   4   5   6   7\n" +
          "-----------------------------\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . |-X-| . | . | . |\n" +
          "=============================\n" +
          "Enter column for next piece: ";

      ui.StartScreen();
      ui.UserMove("4");

      Assert.Equal(firstMove, ui.UserMove(""));
    }

    [Fact]
    void display_out_of_range_error()
    {
      var ui = new UI(new ConnectFour(), new Board());

      var firstMove = "Index was outside the bounds of the array.\n" +
          "\n" +
          "  1   2   3   4   5   6   7\n" +
          "-----------------------------\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . | . | . | . | . |\n" +
          "| . | . | . |-X-| . | . | . |\n" +
          "=============================\n" +
          "Enter column for next piece: ";

      ui.StartScreen();
      ui.UserMove("4");

      Assert.Equal(firstMove, ui.UserMove("9"));
    }

  }
}