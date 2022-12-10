namespace DayEight;

public class DayTenTest
{


    public int magicCycleInterval(int cycle, int x)
    {
        if (cycle == 20 || (cycle - 20) % 40 == 0)
            return (cycle * x);
        return 0;
    }

    [Fact]
    public void TestPart1()
    {
        var inputs = File.ReadLines("../../../input.txt").ToList();
        var x = 1;
        var sum = 0;
        var cycle = 0;
        for (var i = 0; i < inputs.Count(); i++)
        {
            cycle += 1;
            sum += magicCycleInterval(cycle, x);
            if (!inputs[i].StartsWith("noop"))
            {
                cycle += 1;
                sum += magicCycleInterval(cycle, x);
                x += int.Parse(inputs[i].Replace("addx ", ""));
            }
        }
        Assert.Equal(14220, sum);
    }


    public string Draw(int cycle, int x, List<string> rows)
    {
        var rowCycle = cycle % 40;
        var row = rows.Last();
        if (rowCycle - 1 == x - 1 || rowCycle - 1 == x || rowCycle - 1 == x + 1)
            row += "#";
        else row += ".";
        if (rowCycle == 0)
            rows.Add("");
        return row;
    }

    [Fact]
    public void TestPart2()
    {
        int cycle = 0;
        var inputs = File.ReadLines("../../../input.txt").ToList();
        List<string> rows = new List<string>() { "" };
        var x = 1;
        for (var i = 0; i < inputs.Count(); i++)
        {
            cycle += 1;
            rows[rows.Count() - 1] = Draw(cycle, x, rows);
            if (!inputs[i].StartsWith("noop"))
            {
                cycle += 1;
                rows[rows.Count() - 1] = Draw(cycle, x, rows);
                x += int.Parse(inputs[i].Replace("addx ", ""));
            }
        }
        Assert.Equal("####.###...##..###..#....####.####.#..#.", rows[0]);
    }

}
