using System;

namespace Game
{
  public class ConnectFour
  {
    int[,] _pieces = new int[,] {
      {0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0}
    };

    public int[,] Pieces()
    {
      return _pieces;
    }

    public void PlacePiece(int player, int column)
    {
      bool piecePlaced = false;
      
      for (int i = 5; i >= 0; i--)
      {
        if (_pieces.GetRow(i)[column] == 0)
        {
          _pieces[i, column] = player;
          piecePlaced = true;
          i = -1;
        }
      }
      if(!piecePlaced)
        throw new Exception("Column full");
    }

    public void SetAllPieces(int[,] pieces)
    {
      _pieces = pieces;
    }
  }
}