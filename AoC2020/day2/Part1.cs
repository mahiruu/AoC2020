namespace AoC2020.day2;

public static class Part1
{
    public static int GetResult()
    {
        return (from line in System.IO.File.ReadLines(
                    @"/home/rob/Programming/Csharp/AdventOfCode2020/AoC2020/AoC2020/day2/input1.txt")
                select line.Split(" ")
                into splitLine
                let lowerBound = int.Parse(splitLine[0].Split("-")[0])
                let upperBound = int.Parse(splitLine[0].Split("-")[1])
                let susChar = splitLine[1][0]
                let pswd = splitLine[2]
                where pswd.Count(c => c == susChar) >= lowerBound && pswd.Count(c => c == susChar) <= upperBound
                select lowerBound)
            .Count();
    }
}