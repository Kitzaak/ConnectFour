namespace Game
{
  public class Board
  {
    int _lastColumn = -1;
    int _lastRow = -1;
    int[,] _winline = new int[,] {
      {-1,-1},
      {-1,-1},
      {-1,-1},
      {-1,-1}
    };

    public string EmptyBoard()
    {
      var screen = "";
      screen += SpecialRow("numbers") + "\n";
      screen += SpecialRow("top") + "\n";
      screen += EmptyPieceRow(0) + "\n";
      screen += EmptyPieceRow(1) + "\n";
      screen += EmptyPieceRow(2) + "\n";
      screen += EmptyPieceRow(3) + "\n";
      screen += EmptyPieceRow(4) + "\n";
      screen += EmptyPieceRow(5) + "\n";
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

    public string PieceRow(int[] rowPieces, int row)
    {
      if(rowPieces.Length != 7) return "| . | . | . | . | . | . | . |";
      else return $"|{Piece(rowPieces[0], row, 0)}|{Piece(rowPieces[1], row, 1)}|{Piece(rowPieces[2], row, 2)}|{Piece(rowPieces[3], row, 3)}|{Piece(rowPieces[4], row, 4)}|{Piece(rowPieces[5], row, 5)}|{Piece(rowPieces[6], row, 6)}|";
    }

    public string EmptyPieceRow(int row)
    {
      return PieceRow(new int[] {0,0,0,0,0,0,0}, row);
    }

    string Piece(int code, int row, int col)
    {
      var filler = " ";
      if(row == _lastRow && col == _lastColumn) 
        filler = "-";
      if((row == _winline[0,0] && col == _winline[0,1])
          || (row == _winline[1,0] && col == _winline[1,1])
          || (row == _winline[2,0] && col == _winline[2,1])
          || (row == _winline[3,0] && col == _winline[3,1]))
        filler = "-";  
      if(code == 1) return $"{filler}X{filler}";
      if(code == 2) return $"{filler}O{filler}";
      return " . ";
    }

    string PieceBoard(int[,] pieces, int lastRow, int lastColumn, int[,] winline)
    {
      _winline = winline;
      _lastColumn = lastColumn;
      _lastRow = lastRow;
      var screen = "";
      screen += SpecialRow("numbers") + "\n";
      screen += SpecialRow("top") + "\n";
      screen += PieceRow(pieces.GetRow(0), 0) + "\n";
      screen += PieceRow(pieces.GetRow(1), 1) + "\n";
      screen += PieceRow(pieces.GetRow(2), 2) + "\n";
      screen += PieceRow(pieces.GetRow(3), 3) + "\n";
      screen += PieceRow(pieces.GetRow(4), 4) + "\n";
      screen += PieceRow(pieces.GetRow(5), 5) + "\n";
      screen += SpecialRow("bottom") + "\n";

      return screen;
    }

    public string PieceBoard(int[,] pieces)
    {
      int[,] _winline = new int[,] {
        {-1,-1},
        {-1,-1},
        {-1,-1},
        {-1,-1}
      };
      return PieceBoard(pieces, -1, -1, _winline);
    }

    public string PieceBoard(int[,] pieces, int lastRow, int lastColumn)
    {
      int[,] _winline = new int[,] {
        {-1,-1},
        {-1,-1},
        {-1,-1},
        {-1,-1}
      };
      return PieceBoard(pieces, lastRow, lastColumn, _winline);
    }

    public string PieceBoard(int[,] pieces, int[,] winline)
    {
      return PieceBoard(pieces, -1, -1, winline);
    }
  }
}