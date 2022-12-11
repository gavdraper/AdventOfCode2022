namespace DayEleven;

public partial class DayElevenTest
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
            TestDivisibleBy = testDivisibleBy;
            this.operation = operation;
            this.trueAction = trueAction;
            this.falseAction = falseAction;
        }

        public Int64 Throw()
        {
            var item = Items[0];
            Items.Remove(item);
            return item;
        }

        public int CalculateDestinationMoney()
        {
            if (!Items.Any())
                return -1;

            InspectCount++;

            var result = operation.Split(new char[] { '+', '*' })
                       .Select(x => Int64.Parse(x.Replace("old", Items[0].ToString())))
                       .Aggregate((a, b) => operation.Contains("+") ? a + b : a * b);

            var roundedResult = result;
            //roundedResult = Math.Floor(result/3);
            Items[0] = roundedResult;

            if (roundedResult % TestDivisibleBy == 0)
                return trueAction;
            else return falseAction;
        }
    }
}
