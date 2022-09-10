namespace AoC2020.day4;

public static class Part2
{
    private const string BirthYear = "byr";
    private const string IssueYear = "iyr";
    private const string ExpirationYear = "eyr";
    private const string Height = "hgt";
    private const string HairColor = "hcl";
    private const string EyeColor = "ecl";
    private const string PassportId = "pid";
    private const string CountryId = "cid";

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
                if (ContainsPassportValidParams(passport))
                {
                    if (ArePassportParamsValid(passport))
                    {
                        Console.WriteLine(passport);
                        validPassportCount++;
                    }
                }

                passport = "";
                continue;
            }

            passport += (line + " ");
        }

        return validPassportCount;
    }

    private static bool ContainsPassportValidParams(string passport)
    {
        return (
            passport.Contains(BirthYear)
            && passport.Contains(IssueYear)
            && passport.Contains(ExpirationYear)
            && passport.Contains(Height)
            && passport.Contains(HairColor)
            && passport.Contains(EyeColor)
            && passport.Contains(PassportId)
        );
    }

    private static bool ArePassportParamsValid(string passport)
    {
        var splitPassport = passport.Split(" ");

        foreach (var passportParam in splitPassport)
        {
            var splitPassportParam = passportParam.Split(":");
            switch (splitPassportParam.First())
            {
                case BirthYear:
                    if (int.Parse(splitPassportParam.Last()) is not (>= 1920 and <= 2002)) return false;
                    break;

                case IssueYear:
                    if (int.Parse(splitPassportParam.Last()) is not (>= 2010 and <= 2020)) return false;
                    break;

                case ExpirationYear:
                    if (int.Parse(splitPassportParam.Last()) is not (>= 2020 and <= 2030)) return false;
                    break;

                case Height:
                    if (splitPassportParam.Last().Last().Equals('m'))
                    {
                        var h = int.Parse(
                            (splitPassportParam.Last().First() + splitPassportParam.Last()[1] +
                             splitPassportParam.Last()[2]).ToString()
                        );
                        if (h is not (>= 150 and <= 193)) return false;
                    }

                    if (!splitPassportParam.Last().Last().Equals('n')) return false;

                    var h2 = int.Parse(splitPassportParam.Last().First() + splitPassportParam.Last()[1].ToString());
                    if (h2 is not (>= 59 and <= 76)) return false;
                    break;


                case HairColor:
                    if (!splitPassportParam.Last().Length.Equals(7)) return false;
                    if (!splitPassportParam.Last().First().Equals('#')) return false;
                    for (var i = 1; i < splitPassportParam.Last().Length; i++)
                    {
                        if (!"0123456789abcdef".Contains(splitPassportParam.Last()[i])) return false;
                        //if (splitPasswordParam.Last()[i] is not (< 'f' and > 'a' or > '0' and < '9')) return false;
                    }

                    break;

                case EyeColor:
                    if (!(
                            splitPassportParam.Last().Equals("amb")
                            || splitPassportParam.Last().Equals("blu")
                            || splitPassportParam.Last().Equals("brn")
                            || splitPassportParam.Last().Equals("gry")
                            || splitPassportParam.Last().Equals("grn")
                            || splitPassportParam.Last().Equals("hzl")
                            || splitPassportParam.Last().Equals("oth")
                        ))
                    {
                        return false;
                    }

                    break;
                case PassportId:
                    if (!(splitPassportParam.Last().Length.Equals(9)
                          && int.TryParse(splitPassportParam.Last(), out var o)))
                    {
                        return false;
                    }

                    break;
                case CountryId:
                    break;
            }
        }

        return true;
    }
}