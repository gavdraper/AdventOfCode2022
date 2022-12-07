namespace DayFFive;

public class Disk
{
    public Directory RootDirectory { get; set; }
    public Directory CurrentDirectory { get; set; }
    public Disk()
    {
        RootDirectory = new Directory(null, "/");
        RootDirectory.Children = new List<Directory>();
        CurrentDirectory = RootDirectory;
    }

    public int findFoldrersSmallerThan(Directory dir, int maxSize, int currentTotal = 0)
    {
        var totalSize = currentTotal;
        if (dir.Size < maxSize)
            totalSize += dir.Size;
        foreach (var c in dir.Children)
            totalSize = findFoldrersSmallerThan(c, maxSize, totalSize);
        return totalSize;
    }

    public int findFolderGreaterThanAndClosestToSize(Directory dir, int size, int closestMatch = -1)
    {
        if (dir.Size > size && (dir.Size < closestMatch || closestMatch == -1))
            closestMatch = dir.Size;
        foreach (var c in dir.Children)
            closestMatch = findFolderGreaterThanAndClosestToSize(c, size, closestMatch);
        return closestMatch;
    }
}
