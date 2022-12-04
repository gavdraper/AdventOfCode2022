namespace Day1;

public class UnitTest1
{

    List<Item> Items = new List<Item>();

    public class Item
    {
        public List<char> Mappings { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Beats { get; set; }

        public Item(List<char> mappings, string name, int score, string beats)
        {
            Mappings = mappings;
            Name = name;
            Score = score;
            Beats = beats;
        }
    }

    public UnitTest1()
    {
        Items.Add(new Item(new List<char> { 'A', 'X' }, "Rock", 1, "Scissors"));
        Items.Add(new Item(new List<char> { 'B', 'Y' }, "Paper", 2, "Rock"));
        Items.Add(new Item(new List<char> { 'C', 'Z' }, "Scissors", 3, "Paper"));
    }

    [Fact]
    public void Test1()
    {
        var input = File.ReadAllText("../../../input.txt");
        var inputs = input.Split(Environment.NewLine);
        var score = 0;

        foreach (var d in inputs)
        {
            var players = d.Split(' ');
            var roundScore = 0;

            var player1 = Items.Single(x => x.Mappings.Contains(d[0]));

            Item player2;
            if (d[2] == 'X')
                player2 = Items.Single(x => player1.Beats == x.Name);
            else if (d[2] == 'Y')
                player2 = Items.Single(x => x.Name == player1.Name);
            else
                player2 = Items.Single(x => x.Beats == player1.Name);

            roundScore += player2.Score;
            string status = "";
            if (player1.Name == player2.Name)
            {
                status = "Draw";
                score += 3;
            }
            else
            if (player2.Beats == player1.Name)
            {
                roundScore += 6;
                status = "Win";
            }
            else status = "Lost";


            Console.WriteLine($"{player1.Name} {player2.Name} {status}  {roundScore}");
            score += roundScore;
        }

        Console.WriteLine(score);

    }
}