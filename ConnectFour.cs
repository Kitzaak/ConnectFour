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

    int _whoWon = 0;

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

    public bool Won()
    {
      var who = LookForVirticalWin();
      if(who > 0)
      {
        _whoWon = who;
        return true;
      }

      who = LookForHorizontalWin();
      if(who > 0)
      {
        _whoWon = who;
        return true;
      }

      who = LookForDiagonalWin();
      if(who > 0)
      {
        _whoWon = who;
        return true;
      }

      return false;
    }

    public int WhoWon()
    {
      return _whoWon;
    }

    int LookForVirticalWin()
    {
      int one;
      int two;
      for (int column = 0; column < 7; column++)
      {
        one = 0;
        two = 0;

        for (int row = 0; row < 6; row++)
        {
          if (_pieces[row, column] == 1)
          {
            one++;
            two = 0;
            if(one == 4)
              return 1;
          }
          else if (_pieces[row, column] == 2)
          {
            two++;
            one = 0;
            if(two == 4)
              return 2;
          }
          else
          {
            one = 0;
            two = 0;
          }
        }
      }
      return 0;
    }

    int LookForHorizontalWin()
    {
      int one;
      int two;
      for (int row = 0; row < 6; row++)
      {
        one = 0;
        two = 0;

        for (int column = 0; column < 7; column++)
        {
          if (_pieces[row, column] == 1)
          {
            one++;
            two = 0;
            if(one == 4)
              return 1;
          }
          else if (_pieces[row, column] == 2)
          {
            two++;
            one = 0;
            if(two == 4)
              return 2;
          }
          else
          {
            one = 0;
            two = 0;
          }
        }
      }
      return 0;
    }

    int LookForDiagonalWin()
    {
      for (int column = 0; column < 7; column++)
      {
        for (int row = 0; row < 6; row++)
        {
          // diagonal down
          if(column + 3 < 7 && row + 3 < 6)
            if(_pieces[row, column] != 0 &&
                 _pieces[row, column] == _pieces[row + 1, column + 1] &&
                 _pieces[row, column] == _pieces[row + 2, column + 2] &&
                 _pieces[row, column] == _pieces[row + 3, column + 3])
               return _pieces[row, column];
          // diagonal up
          if(column + 3 < 7 && row - 3 > -1)
            if(_pieces[row, column] != 0 &&
                 _pieces[row, column] == _pieces[row - 1, column + 1] &&
                 _pieces[row, column] == _pieces[row - 2, column + 2] &&
                 _pieces[row, column] == _pieces[row - 3, column + 3])
               return _pieces[row, column];
        }
      }

      return 0;
    }
  }
}