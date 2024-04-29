namespace BattleShips;
public class Player
{
    public Board Board { get; set; }
    public int Id { get; init; }

    public Player(int id)
    {
        Board = new Board();
        Id = id;
    }
}