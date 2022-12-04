namespace Day1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var inputs = File.ReadLines("../../../input.txt");
        var elfCalories = new List<int>();
        int currentElf = 0;

        foreach (var d in inputs)
        {
            if (string.IsNullOrEmpty(d))
            {
                elfCalories.Add(currentElf);
                currentElf = 0;
                continue;
            }
            currentElf += int.Parse(d);
        }
        elfCalories.Add(currentElf);

        var topThree = elfCalories
            .OrderByDescending(x => x)
            .Take(3).Sum();

        var first = elfCalories
            .OrderByDescending(x => x)
            .First();

        Assert.Equal(68787, first);
        Assert.Equal(198041, topThree);

    }
}