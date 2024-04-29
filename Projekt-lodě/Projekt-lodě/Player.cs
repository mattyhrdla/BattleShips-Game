namespace BattleShips;
public class Player
{
    public Board Board { get; set; }
    public int Id { get; set; }

    public string Name { get; set; }

    public Player(int id, string name)
    {
        Board = new Board();
        Id = id;
        Name = name;
    }
}