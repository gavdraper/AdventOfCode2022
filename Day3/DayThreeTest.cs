namespace DayThree;

public class DayThreeTest
{
    private int getPriorityScore(char str) => Char.IsUpper(str) ? str - 38 : str - 96;

    [Fact]
    public void Test1()
    {
        var inputs = File.ReadLines("../../../input.txt");
        //Part 1
        var prioritySum = 0;
        foreach (var d in inputs)
        {
            var parts = d.Chunk(d.Length / 2).ToList();
            prioritySum += getPriorityScore(parts[0].First(x => parts[1].Contains(x)));
        }
        Assert.Equal(7795, prioritySum);

        //Part2
        int partTwoScore = 0;
        foreach (var c in inputs.Chunk(3))
            partTwoScore += getPriorityScore(c[0].First(x => c[1].Contains(x) && c[2].Contains(x)));
        Assert.Equal(2703, partTwoScore);
    }


}