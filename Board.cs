namespace Game
{
  public class Board
  {
    public string EmptyBoard()
    {
      var screen = "";
      screen += SpecialRow("numbers") + "\n";
      screen += SpecialRow("top") + "\n";
      screen += EmptyPieceRow() + "\n";
      screen += EmptyPieceRow() + "\n";
      screen += EmptyPieceRow() + "\n";
      screen += EmptyPieceRow() + "\n";
      screen += EmptyPieceRow() + "\n";
      screen += EmptyPieceRow() + "\n";
      screen += SpecialRow("bottom") + "\n";

      return screen;
    }

    public string SpecialRow(string rowName)
    {
      if(rowName == "numbers") return "  1   2   3   4   5   6   7";
      if(rowName == "top") return "-----------------------------";
      if(rowName == "bottom") return "=============================";
      return "";
    }

    public string PieceRow(int[] rowPieces)
    {
      if(rowPieces.Length != 7) return "| . | . | . | . | . | . | . |";
      else return $"| {Piece(rowPieces[0])} | {Piece(rowPieces[1])} | {Piece(rowPieces[2])} | {Piece(rowPieces[3])} | {Piece(rowPieces[4])} | {Piece(rowPieces[5])} | {Piece(rowPieces[6])} |";
    }

    public string EmptyPieceRow()
    {
      return PieceRow(new int[] {0,0,0,0,0,0,0});
    }

    public string Piece(int code)
    {
      if(code == 1) return "X";
      if(code == 2) return "O";
      return ".";
    }

    public string PieceBoard(int[,] pieces)
    {
      var screen = "";
      screen += SpecialRow("numbers") + "\n";
      screen += SpecialRow("top") + "\n";
      screen += PieceRow(pieces.GetRow(0)) + "\n";
      screen += PieceRow(pieces.GetRow(1)) + "\n";
      screen += PieceRow(pieces.GetRow(2)) + "\n";
      screen += PieceRow(pieces.GetRow(3)) + "\n";
      screen += PieceRow(pieces.GetRow(4)) + "\n";
      screen += PieceRow(pieces.GetRow(5)) + "\n";
      screen += SpecialRow("bottom") + "\n";

      return screen;
    }
  }
}