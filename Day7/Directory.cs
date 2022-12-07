namespace DayFFive;

public class Directory
{
    public Directory Parent { get; set; }
    public string Name { get; set; }
    public List<Directory> Children { get; set; } = new List<Directory>();
    public int Size { get; set; }

    public Directory(Directory? parent, string name)
    {
        Parent = parent;
        Name = name;
    }
}
