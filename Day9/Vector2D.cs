namespace DayNine;

public class Vector2D
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Touches(Vector2D other)
    {
        if (Math.Abs(other.X - X) < 2 && Math.Abs(other.Y - Y) < 2)
            return true;
        else
            return false;
    }

    private int getCloser(int source, int target)
    {
        if (source < target)
            source++;
        else if (source > target)
            source--;
        return source;
    }

    public void MoveToward(Vector2D other)
    {
        if (!this.Touches(other))
        {
            this.X = getCloser(X, other.X);
            this.Y = getCloser(Y, other.Y);
        }
    }

    public Vector2D Move(Vector2D velocity)
    {
        return new Vector2D(X + velocity.X, Y + velocity.Y);
    }

    public override string ToString()
    {
        return $"{X},{Y}";
    }
}


