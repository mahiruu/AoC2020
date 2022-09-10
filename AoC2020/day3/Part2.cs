namespace AoC2020.day3;

public static class Part2
{
    public static long GetResult()
    {
        const char tree = '#';

        long treeCount1 = 0;
        long treeCount3 = 0;
        long treeCount5 = 0;
        long treeCount7 = 0;
        long treeCount2Vertically = 0;

        var rowIndex = 0;

        var grid = System.IO.File.ReadLines(
            @"/home/ma/Programming/Csharp/AdventOfCode2020/AoC2020/AoC2020/day3/input1.txt");

        var gridRows = grid as string[] ?? grid.ToArray();
        var defaultGridRowLength = gridRows.First().Length;

        var horizontalPos1 = 0;
        var horizontalPos3 = 0;
        var horizontalPos5 = 0;
        var horizontalPos7 = 0;
        var horizontalPos2Vertically = 0;

        foreach (var row in gridRows)
        {
            // 1 jump checker
            if (horizontalPos1 >= defaultGridRowLength)
            {
                if (row[horizontalPos1 % defaultGridRowLength] == tree)
                {
                    treeCount1++;
                }
            }
            else
            {
                if (row[horizontalPos1] == tree)
                {
                    treeCount1++;
                }
            }

            horizontalPos1++;

            // 3 jump checker
            if (horizontalPos3 >= defaultGridRowLength)
            {
                if (row[horizontalPos3 % defaultGridRowLength] == tree)
                {
                    treeCount3++;
                }
            }
            else
            {
                if (row[horizontalPos3] == tree)
                {
                    treeCount3++;
                }
            }

            horizontalPos3 += 3;

            // 5 jump checker
            if (horizontalPos5 >= defaultGridRowLength)
            {
                if (row[horizontalPos5 % defaultGridRowLength] == tree)
                {
                    treeCount5++;
                }
            }
            else
            {
                if (row[horizontalPos5] == tree)
                {
                    treeCount5++;
                }
            }

            horizontalPos5 += 5;

            // 7 jump checker
            if (horizontalPos7 >= defaultGridRowLength)
            {
                if (row[horizontalPos7 % defaultGridRowLength] == tree)
                {
                    treeCount7++;
                }
            }
            else
            {
                if (row[horizontalPos7] == tree)
                {
                    treeCount7++;
                }
            }

            horizontalPos7 += 7;

            // 2 vertically jump checker, 1 horizontally
            if (rowIndex % 2 == 0 || rowIndex == 0)
            {
                if (horizontalPos2Vertically >= defaultGridRowLength)
                {
                    if (row[horizontalPos2Vertically % defaultGridRowLength] == tree)
                    {
                        treeCount2Vertically++;
                    }
                }
                else
                {
                    if (row[horizontalPos2Vertically] == tree)
                    {
                        treeCount2Vertically++;
                    }
                }

                horizontalPos2Vertically++;
            }

            rowIndex++;
        }

        return treeCount1 * treeCount3 * treeCount5 * treeCount7 * treeCount2Vertically;
    }
}