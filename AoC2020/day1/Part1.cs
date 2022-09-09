namespace AoC2020.day1;

public static class Part1
{
    public static int GetResult()
    {
        return (from line1 in System.IO.File.ReadLines(
                @"/home/ma/Programming/Csharp/AdventOfCode2020/AoC2020/AoC2020/day1/input1.txt")
            select int.Parse(line1)
            into num1
            from line2 in System.IO.File.ReadLines(
                @"/home/ma/Programming/Csharp/AdventOfCode2020/AoC2020/AoC2020/day1/input1.txt")
            let num2 = int.Parse(line2)
            where num1 + num2 == 2020
            select num1 * num2).FirstOrDefault();
    }
}