namespace DayNine;

public class DayNineTest
{
    public Dictionary<char, Vector2D> Velocities = new Dictionary<char, Vector2D>{
        {'R',new Vector2D(1,0) },{'L',new Vector2D(-1,0) },{'D',new Vector2D(0,1) },{'U',new Vector2D(0,-1) },
    };

    [Fact]
    public void Test()
    {
        var inputs = File.ReadLines("../../../input.txt");
        var knotCount = 10; //2 for Part One
        var knots = new List<Vector2D>();
        for (var i = 0; i < knotCount; i++)
            knots.Add(new Vector2D(0, 0));
        List<string> visitedLocations = new List<string> { knots[0].ToString() };
        foreach (var i in inputs)
        {
            var operations = i.Split(' ');
            repeatCommand(int.Parse(operations[1]), Velocities[operations[0][0]], knots, visitedLocations);
        }
        //Assert.Equal(6266, visitedLocations.Count()); //Part1
        Assert.Equal(2369, visitedLocations.Count());
    }

    private void repeatCommand(int times, Vector2D velocity, List<Vector2D> knots, List<string> locations)
    {
        for (var x = 0; x < times; x++)
        {
            for (var knot = 0; knot < knots.Count(); knot++)
            {
                if (knot == 0)
                {
                    knots[0] = knots[0].Move(velocity);
                    continue;
                }
                knots[knot].MoveToward(knots[knot - 1]);
                if (knot == knots.Count() - 1)
                {
                    if (!locations.Any(x => x == knots[knot].ToString()))
                        locations.Add(knots[knot].ToString());
                }
            }
        }
    }

}

