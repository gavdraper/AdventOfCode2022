namespace DayEight;

public class DaySixTest
{
    public Dictionary<char, Vector2D> Velocities = new Dictionary<char, Vector2D>
    {
        {'R',new Vector2D(1,0) },
        {'L',new Vector2D(-1,0) },
        {'D',new Vector2D(0,1) },
        {'U',new Vector2D(0,-1) },
    };

    [Fact]
    public void TestPart1()
    {
        var inputs = File.ReadLines("../../../input.txt");
        List<string> visitedLocations = new List<string>();
        var headPos = new Vector2D(0, 0);
        var tailPos = new Vector2D(-1, 0);
        foreach (var i in inputs)
        {
            var moveCount = 0;
            var operations = i.Split(' ');
            for (var x = 0; x < int.Parse(operations[1]); x++)
            {
                headPos = headPos.Move(Velocities[operations[0][0]]);
                if (!headPos.Touches(tailPos))
                {
                    moveCount++;
                    tailPos.MoveToward(headPos);
                    if (!visitedLocations.Any(x => x == tailPos.ToString()))
                        visitedLocations.Add(tailPos.ToString());
                }
            }
        }
        Assert.Equal(6266, visitedLocations.Count());
    }

    [Fact]
    public void TestPart2()
    {
        var ropeLength = 10;
        var knots = new List<Vector2D>();
        var inputs = File.ReadLines("../../../input.txt");
        List<string> visitedLocations = new List<string>();
        for (var i = 0; i < ropeLength; i++)
            knots.Add(new Vector2D(0, 0));
        visitedLocations.Add(knots[0].ToString());
        foreach (var i in inputs)
        {
            var operations = i.Split(' ');
            for (var x = 0; x < int.Parse(operations[1]); x++)
            {
                for (var knot = 0; knot < knots.Count(); knot++)
                {
                    if (knot == 0)
                    {
                        knots[0] = knots[0].Move(Velocities[operations[0][0]]);
                        continue;
                    }
                    if (!knots[knot].Touches(knots[knot - 1]))
                    {
                        knots[knot].MoveToward(knots[knot - 1]);
                        if (knot == knots.Count() - 1)
                        {
                            if (!visitedLocations.Any(x => x == knots[knot].ToString()))
                                visitedLocations.Add(knots[knot].ToString());

                        }
                    }
                }
            }
        }
        Assert.Equal(2369, visitedLocations.Count());
    }
}

