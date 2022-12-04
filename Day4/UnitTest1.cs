namespace Day1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var inputs = File.ReadLines("../../../input.txt");
        var coveredCount = 0;
        var partialCoveredCount = 0;

        foreach (var d in inputs)
        {
            var parts = d.Split(',');

            var rangeOne = parts[0].Split('-').Select(x => int.Parse(x.ToString())).ToList();
            var rangeTwo = parts[1].Split('-').Select(x => int.Parse(x.ToString())).ToList();

            var rangeOneItems = Enumerable.Range(rangeOne[0], rangeOne[1] - (rangeOne[0] - 1));
            var rangeTwoItems = Enumerable.Range(rangeTwo[0], rangeTwo[1] - (rangeTwo[0] - 1));

            //Part1
            if (new int[] { rangeOneItems.Count(), rangeTwoItems.Count() }.Contains(rangeOneItems.Intersect(rangeTwoItems).Count()))
                coveredCount++;

            //Part2
            if (rangeOneItems.Intersect(rangeTwoItems).Any())
                partialCoveredCount++;

        }
        Assert.Equal(511, coveredCount);
        Assert.Equal(821, partialCoveredCount);

    }


}