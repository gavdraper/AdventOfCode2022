namespace DayEleven;

public partial class DayElevenTest
{

    private void playRound(List<Monkey> monkeys)
    {
        //Devisor involved some Google KungFu :(
        //Melted Laptop on first attempt with BigInteger
        var commonDeviser = 1;
        foreach (var m in monkeys)
            commonDeviser *= m.TestDivisibleBy;

        for (var m = 0; m < monkeys.Count(); m++)
        {
            int totalCount = monkeys[m].Items.Count();
            for (var ndxItem = 0; ndxItem < totalCount; ndxItem++)
            {
                var destination = monkeys[m].CalculateDestinationMoney();
                monkeys[destination].Items.Add(monkeys[m].Throw() % commonDeviser);
            }
        }
    }

    [Fact]
    public void Test()
    {
        var inputs = File.ReadLines("../../../input.txt").ToList();
        var monkeys = new List<Monkey>();
        var i = 0;
        while (i < inputs.Count())
        {
            monkeys.Add(MonkeyBuilder.Build(inputs[i + 1], inputs[i + 2], inputs[i + 3], inputs[i + 4], inputs[i + 5]));
            i += 7;
        }

        for (var round = 0; round < 10000; round++)
            playRound(monkeys);

        var topTwo = monkeys
            .Select(x => x.InspectCount)
            .OrderByDescending(x => x)
            .Take(2)
            .Aggregate((a, b) => a * b);

        // Assert.Equal(10605, topTwo); //Part1
        Assert.Equal(15447387620, topTwo);
    }
}
