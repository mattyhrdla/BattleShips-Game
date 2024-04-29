using projekt_lodě.Models;

namespace BattleShips;
public class Board
{
    private CellState[,] _grid;

    public Board()
    {
        _grid = new CellState[10, 10];
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _grid[i, j] = CellState.Empty;
            }
        }
    }

    public void PlaceShip(int row, int col, int size, bool vertical)
    {
        if (vertical)
        {
            for (int i = row; i < row + size; i++)
            {
                _grid[i, col] = CellState.Ship;
            }
        }
        else
        {
            for (int j = col; j < col + size; j++)
            {
                _grid[row, j] = CellState.Ship;
            }
        }
    }

    public bool Attack(int row, int col)
    {
        if (_grid[row, col] == CellState.Ship)
        {
            _grid[row, col] = CellState.Hit;
            return true;
        }
        else
        {
            _grid[row, col] = CellState.Miss;
            return false;
        }
    }

    public bool AllShipsSunk()
    {
        foreach (var cell in _grid)
        {
            if (cell == CellState.Ship)
            {
                return false;
            }
        }
        return true;
    }

    public CellState[,] GetGrid()
    {
        return _grid;
    }
}
