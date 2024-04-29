using projekt_lodě.Models;

namespace BattleShips;

public class Game
{
    public Player _player1;
    public Player _player2;
    private Player _currentPlayer;
    private Player _opponent;
    public Game(Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;
        _currentPlayer = _player1;
        _opponent = _player2;
    }
    public void PlaceShipsRandomly(Player player)
    {
        Random random = new Random();
        for (int size = 5; size >= 2; size--)
        {
            bool vertical = random.Next(0, 2) == 0;
            int row = random.Next(0, 10);
            int col = random.Next(0, 10);
            while (!CanPlaceShip(player.Board, row, col, size, vertical))
            {
                vertical = random.Next(0, 2) == 0;
                row = random.Next(0, 10);
                col = random.Next(0, 10);
            }
            player.Board.PlaceShip(row, col, size, vertical);
        }
    }
    private bool CanPlaceShip(Board board, int row, int col, int size, bool vertical)
    {
        if (vertical)
        {
            if (row + size > 10)
                return false;
            for (int i = row; i < row + size; i++)
            {
                if (board.GetGrid()[i, col] != CellState.Empty)
                    return false;
            }
        }
        else
        {
            if (col + size > 10)
                return false;
            for (int j = col; j < col + size; j++)
            {
                if (board.GetGrid()[row, j] != CellState.Empty)
                    return false;
            }
        }
        return true;
    }
    public void SwitchTurn()
    {
        Player temp = _currentPlayer;
        _currentPlayer = _opponent;
        _opponent = temp;
    }
    public void Play(int row, int col)
    {
        bool hit = _opponent.Board.Attack(row, col);
        if (hit)
        {
            Console.WriteLine("Hit!");
            if (_opponent.Board.AllShipsSunk())
            {
                Console.WriteLine("Game Over! You Win!");
                return;
            }
        }
        else
        {
            Console.WriteLine("Miss!");
        }
        SwitchTurn();
    }
}
