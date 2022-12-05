namespace DayFFive;

public class DayFiveTest
{
    List<Stack<Char>> stacks = new List<Stack<Char>>();

    private void CreateStacks(IEnumerable<string> input)
    {
        foreach (var row in input)
        {
            var boxes = row.Chunk(4);
            var itemNo = 0;
            foreach (var b in boxes)
            {
                char letter = b.Where(x => Char.IsLetter(x)).SingleOrDefault();
                if (letter != '\0')
                {
                    while (stacks.Count() <= itemNo)
                        stacks.Add(new Stack<char>());
                    stacks[itemNo].Push(letter);
                }
                itemNo++;
            }
        }
        //Reverse Stacks
        for (var t = 0; t < stacks.Count(); t++)
            stacks[t] = new Stack<char>(stacks[t]);
    }

    private void moveBoxes(IEnumerable<string> input, bool preservePopOrder)
    {
        foreach (var row in input)
        {
            var tmp = row.Replace(" ", "").Replace("move", "");
            var moves = tmp.Split(new string[] { "from", "to" }, StringSplitOptions.None);
            if (!moves.Any())
                continue;
            var popped = new List<char>();
            for (var y = 0; y < int.Parse(moves[0]); y++)
                popped.Add(stacks[int.Parse(moves[1]) - 1].Pop());

            if (preservePopOrder)
                popped.Reverse();

            foreach (var item in popped)
                stacks[int.Parse(moves[2]) - 1].Push(item);
        }
    }

    private string getTopCreates()
    {
        var result = "";
        foreach (var c in stacks)
        {
            if (c.Any())
                result += c.Peek();
        }
        return result;
    }

    [Fact]
    public void TestPart1()
    {
        var inputs = File.ReadLines("../../../input.txt").ToList();
        var stageOne = inputs.Take(inputs.FindIndex(x => x == ""));
        var stageTwo = inputs.Skip(inputs.FindIndex(x => x == "") + 1);

        CreateStacks(stageOne);
        moveBoxes(stageTwo, false);
        Assert.Equal("CMZ", getTopCreates());
    }

    [Fact]
    public void TestPart2()
    {
        var inputs = File.ReadLines("../../../input.txt").ToList();
        var stageOne = inputs.Take(inputs.FindIndex(x => x == ""));
        var stageTwo = inputs.Skip(inputs.FindIndex(x => x == "") + 1);

        CreateStacks(stageOne);
        moveBoxes(stageTwo, true);

        Assert.Equal("MCD", getTopCreates());
    }

}