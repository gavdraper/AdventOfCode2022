namespace DayFFive;

public class DaySixTest
{
    [Fact]
    public void TestPart1()
    {
        var disk = new Disk();
        int diskSize = 70000000;
        int requiredSpace = 30000000;

        var input = File.ReadLines("../../../input.txt");
        var dirListing = false;
        foreach (var line in input)
        {
            if (dirListing && line.StartsWith("$"))
                dirListing = false;
            else if (dirListing && !line.StartsWith("dir"))
            {
                var size = int.Parse(line.Substring(0, line.IndexOf(" ")));
                disk.CurrentDirectory.Size += size;
                var curDir = disk.CurrentDirectory;
                while (curDir.Parent != null)
                {
                    curDir.Parent.Size += size;
                    curDir = curDir.Parent;
                }
            }
            if (line.StartsWith("$ cd"))
            {
                if (line == "$ cd /")
                    disk.CurrentDirectory = disk.RootDirectory;
                else if (line == "$ cd ..")
                    disk.CurrentDirectory = disk.CurrentDirectory.Parent;
                else
                {
                    var dir = line.Replace("$ cd ", "");
                    if (!disk.CurrentDirectory.Children.Any(x => x.Name == dir))
                        disk.CurrentDirectory.Children.Add(new Directory(disk.CurrentDirectory, dir));
                    disk.CurrentDirectory = disk.CurrentDirectory.Children.Single(x => x.Name == dir);
                }
            }
            if (line == "$ ls")
                dirListing = true;
        }

        var result = disk.findFoldrersSmallerThan(disk.RootDirectory, 100000);
        Assert.Equal(1477771, result);

        var folderToDelete = disk.findFolderGreaterThanAndClosestToSize(disk.RootDirectory,
               requiredSpace - (diskSize - disk.RootDirectory.Size));
        Assert.Equal(3579501, folderToDelete);

    }



}