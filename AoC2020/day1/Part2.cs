namespace AoC2020.day1;

public static class Part2
{
    public static int GetResult()
    {
        var lines = System.IO.File.ReadLines(
            @"/home/ma/Programming/Csharp/AdventOfCode2020/AoC2020/AoC2020/day1/input2.txt");

        var en = lines as string[] ?? lines.ToArray();
        return (from line1 in en
            select int.Parse(line1)
            into num1
            from line2 in en
            let num2 = int.Parse(line2)
            from line3 in en
            let num3 = int.Parse(line3)
            where num1 + num2 + num3 == 2020
            select num1 * num2 * num3).FirstOrDefault();
    }
}