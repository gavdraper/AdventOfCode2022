namespace DayTwo;

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