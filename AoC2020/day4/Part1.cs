namespace AoC2020.day4;

public static class Part1
{
    public static int GetResult()
    {
        // beware: the last line has to be a blank one for this to work
        var passportBatch = System.IO.File.ReadLines(
            @"/home/ma/Programming/Csharp/AdventOfCode2020/AoC2020/AoC2020/day4/input1.txt");

        var passport = "";

        var validPassportCount = 0;
        foreach (var line in passportBatch)
        {
            if (line.Equals(""))
            {
                Console.WriteLine(passport);
                if (IsPasswordValid(passport))
                {
                    validPassportCount++;
                }

                passport = "";
                continue;
            }

            passport += line;
        }

        return validPassportCount;
    }

    private static bool IsPasswordValid(string passport)
    {
        const string birthYear = "byr";
        const string issueYear = "iyr";
        const string expirationYear = "eyr";
        const string height = "hgt";
        const string hairColor = "hcl";
        const string eyeColor = "ecl";
        const string passportId = "pid";

        return (
            passport.Contains(birthYear)
            && passport.Contains(issueYear)
            && passport.Contains(expirationYear)
            && passport.Contains(height)
            && passport.Contains(hairColor)
            && passport.Contains(eyeColor)
            && passport.Contains(passportId)
        );
    }
}