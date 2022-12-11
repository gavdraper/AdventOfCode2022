namespace DayEleven;

public partial class DayElevenTest
{
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
}
