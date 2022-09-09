namespace AoC2020.day2;

public static class Part2
{
    public static int GetResult()
    {
        return (from line in System.IO.File.ReadLines(
                    @"/home/ma/Programming/Csharp/AdventOfCode2020/AoC2020/AoC2020/day2/input1.txt")
                select line.Split(" ")
                into splitLine
                let firstOccurenceIndex = int.Parse(splitLine[0].Split("-")[0]) - 1
                let secondOccurenceIndex = int.Parse(splitLine[0].Split("-")[1]) - 1
                let susChar = splitLine[1][0]
                let pswd = splitLine[2]
                where pswd[firstOccurenceIndex] == susChar || pswd[secondOccurenceIndex] == susChar
                where pswd[firstOccurenceIndex] != pswd[secondOccurenceIndex]
                select firstOccurenceIndex)
            .Count();
    }
}