using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips;

namespace Battleships.Models;

public enum CellState
{
    Empty,
    Ship,
    Hit,
    Miss
}
class GameManagerModel
{
    public Player player1;
    public Player player2;
    Game game;

    bool PlayerJoined(int id)
    {

        if (id == 1 && player1 == null)
            player1 = new Player(id);
        else if (id == 2 && player2 == null)
            player2 = new Player(id);
        else
            return false;

        if (player1 != null && player2 != null)
            game = new Game(player1, player2);

        return true;
    }

    void Main(string[] args)
    {
        Game game = new Game(player1, player2);
        game.PlaceShipsRandomly(game._player1);
        game.PlaceShipsRandomly(game._player2);

        while (true)
        {
            Console.WriteLine("Player's turn.");
            Console.Write("Enter target row (0-9): ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter target column (0-9): ");
            int col = int.Parse(Console.ReadLine());
            game.Play(row, col);
        }
    }



}

