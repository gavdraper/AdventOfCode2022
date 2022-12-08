namespace DayEight;

public class DaySixTest
{

    public int TreesInSight(List<List<Tree>> trees, int y, int x, int xVelocity, int yVelocity)
    {
        var curY = y + yVelocity;
        var curX = x + xVelocity;
        var visibleTrees = 0;
        while (curY < trees.Count() && curY >= 0 && curX < trees[curY].Count() && curX >= 0)
        {
            visibleTrees++;
            if (trees[y][x].Height <= trees[curY][curX].Height)
                break;
            curY += yVelocity;
            curX += xVelocity;
        }
        return visibleTrees;
    }

    public void MarkVisibleTrees(List<List<Tree>> trees, int x, int y, int xVelocity, int yVelocity)
    {
        var curHeight = -1;
        while (y < trees.Count() && y >= 0 && x < trees[y].Count() && x >= 0)
        {
            if (trees[y][x].Height > curHeight)
            {
                curHeight = trees[y][x].Height;
                trees[y][x].Visible = true;
            }
            y += yVelocity;
            x += xVelocity;
        }
    }

    [Fact]
    public void TestPart1()
    {
        var inputs = File.ReadLines("../../../input.txt");
        var trees = new List<List<Tree>>();

        foreach (var row in inputs)
        {
            trees.Add(new List<Tree>());
            foreach (var tree in row)
                trees.Last().Add(new Tree(int.Parse(tree.ToString())));
        }

        //Part 1
        //Right
        for (var r = 0; r < trees.Count(); r++)
            MarkVisibleTrees(trees, 0, r, 1, 0);
        //Left
        for (var r = 0; r < trees.Count(); r++)
            MarkVisibleTrees(trees, trees[0].Count() - 1, r, -1, 0);

        // //Down
        for (var c = 0; c < trees.Count(); c++)
            MarkVisibleTrees(trees, c, 0, 0, 1);
        // //Up    
        for (var c = 0; c < trees.Count(); c++)
            MarkVisibleTrees(trees, c, trees.Count() - 1, 0, -1);


        var sum = 0;
        foreach (var r in trees)
            foreach (var c in r)
                if (c.Visible)
                    sum += 1;


        Assert.Equal(1854, sum);
        //Part 2
        for (var r = 1; r < trees.Count() - 1; r++)
        {
            for (var c = 1; c < trees[r].Count() - 1; c++)
            {
                var left = TreesInSight(trees, r, c, -1, 0);
                var right = TreesInSight(trees, r, c, 1, 0);
                var up = TreesInSight(trees, r, c, 0, -1);
                var down = TreesInSight(trees, r, c, 0, 1);
                if (up == 0) up = 1;
                if (right == 0) right = 1;
                if (left == 0) left = 1;
                if (down == 0) down = 1;
                trees[r][c].ViewDistance = down * up * right * left;
            }
        }

        var maxDistance = 0;
        foreach (var r in trees)
            foreach (var c in r)
                if (c.ViewDistance > maxDistance)
                    maxDistance = c.ViewDistance;
        Assert.Equal(527340, maxDistance);
    }
}


