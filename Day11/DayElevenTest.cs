namespace DayEleven;

public class DayElevenTest
{

    public class Monkey
    {
        public List<Int64> Items { get; set; }
        private string operation = "";
        public int TestDivisibleBy { get; set; }
        private int trueAction;
        private int falseAction;
        public Int64 InspectCount { get; set; }

        public Monkey(IEnumerable<Int64> items, string operation, int testDivisibleBy, int trueAction, int falseAction)
        {
            Items = items.ToList();
            this.operation = operation;
            TestDivisibleBy = testDivisibleBy;
            this.trueAction = trueAction;
            this.falseAction = falseAction;
        }

        public Int64 Throw()
        {
            var item = Items[0];
            Items.Remove(item);
            return item;
        }

        public int CalculateDestinationMoney(int no)
        {
            if (!Items.Any())
                return -1;

            InspectCount++;
            var worryLevel = Items[0];
            Int64 result = 0;
            if (operation.Contains('+'))
            {
                var sides = operation.Split('+').Select(x =>
                    Int64.Parse(x
                        .Trim()
                        .Replace("old", worryLevel.ToString()))
                ).ToList();
                result = sides[0] + sides[1];
            }
            if (operation.Contains('*'))
            {
                var sides = operation.Split('*').Select(x =>
                    Int64.Parse(x
                        .Trim()
                        .Replace("old", worryLevel.ToString()))
                ).ToList();
                result = sides[0] * sides[1];
            }
            // var roundedResult = (int)Math.Floor(result / 3f); //Part 1
            var roundedResult = result;
            var destination = -1;
            if (roundedResult % TestDivisibleBy == 0)
                destination = trueAction;
            else destination = falseAction;
            if (result < 0)
            {
                Console.WriteLine("Boom");
                Console.WriteLine(worryLevel);
                Console.WriteLine(operation);
                throw (new Exception());
            }
            Items[0] = roundedResult;
            return destination;
        }
    }

    public static class MonkeyBuilder
    {
        public static Monkey Build(string starting, string operation, string test, string trueAction, string falseAction)
        {
            var items = starting.Trim().Replace("Starting items: ", "").Split(',').Select(x => Int64.Parse(x));
            operation = operation.Replace("Operation: new =", "").Trim();
            var testInt = int.Parse(test.Trim().Replace("Test: divisible by ", ""));
            var trueActionMonkey = int.Parse(trueAction.Trim().Replace("If true: throw to monkey ", ""));
            var falseActionMonkey = int.Parse(falseAction.Trim().Replace("If false: throw to monkey ", ""));
            return new Monkey(
                items,
                operation,
                testInt,
                trueActionMonkey,
                falseActionMonkey
            );
        }
    }

    private void playRound(List<Monkey> monkeys)
    {
        //Devisor involved some Google KungFu :(
        //Melted Laptop on first attempt with BigInteger
        var commonDeviser = 1;
        foreach (var m in monkeys)
            commonDeviser *= m.TestDivisibleBy;

        for (var m = 0; m < monkeys.Count(); m++)
        {
            int ndxItem = 0;
            int totalCount = monkeys[m].Items.Count();
            while (ndxItem < totalCount)
            {
                var destination = monkeys[m].CalculateDestinationMoney(m);
                var item = monkeys[m].Throw();
                item = item % commonDeviser;
                monkeys[destination].Items.Add(item);
                ndxItem++;
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
            monkeys.Add(MonkeyBuilder.Build(
                    inputs[i + 1],
                    inputs[i + 2],
                    inputs[i + 3],
                    inputs[i + 4],
                    inputs[i + 5]));
            i += 7;
        }

        for (var round = 0; round < 10000; round++)
            playRound(monkeys);

        var topTwo = monkeys.OrderByDescending(x => x.InspectCount)
        .Take(2).Select(x => x.InspectCount).ToList();

        Int64 levelOfMonkeyBusiness = (topTwo[0] * topTwo[1]);
        // Assert.Equal(10605, levelOfMonkeyBusiness); //Part1
        Assert.Equal(2713310158, levelOfMonkeyBusiness);
    }
}
