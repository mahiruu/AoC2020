namespace AoC2020.day3;

public static class Part1
{
    public static int GetResult()
    {
        var treeCount = 0;

        var grid = System.IO.File.ReadLines(
            @"/home/ma/Programming/Csharp/AdventOfCode2020/AoC2020/AoC2020/day3/input1.txt");

        var gridRows = grid as string[] ?? grid.ToArray();
        var defaultGridRowLength = gridRows.First().Length;

        var horizontalPos = 0;
        foreach (var row in gridRows)
        {
            if (horizontalPos >= defaultGridRowLength)
            {
                if (row[horizontalPos % defaultGridRowLength] == '#')
                {
                    treeCount++;
                }
            }
            else
            {
                if (row[horizontalPos] == '#')
                {
                    treeCount++;
                }
            }

            horizontalPos += 3;
        }

        return treeCount;
    }
}