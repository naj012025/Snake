using Snake.Controller;
namespace Snake.Models;

internal class Coord
{
    private int x;
    private int y;
    public int X { get { return x; } }
    public int Y { get { return y; } }
    public Coord(int x, int y)
    {

        this.x = x;
        this.y = y;
    }

    // les mer om Hash equal...
    public override bool Equals(object? obj)
    {
        if ((obj == null) || !GetType().Equals(obj.GetType()))
            return false;

        Coord other = (Coord)obj;
        return X == other.x && y == other.y;
    }

    public void ApplyMovementDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                x--;
                break;
            case Direction.Right:
                x++;
                break;
            case Direction.Up:
                y--;
                break;
            case Direction.Down:
                y++;
                break;
        }
    }




}