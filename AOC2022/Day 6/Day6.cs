using Tools.Models;

namespace AOC2022.Day_6;

public static class Day6
{
    private static readonly Input Input = new (@"Day 6\input.txt");
    public static int GetStartOfPacket(int amountOfUniqueChars)
    {
        for (int i = 0; i < Input.Data.Length; i++)
        {
            var groupedString = Input.Data.Substring(i, amountOfUniqueChars);
            if (AllUnique(groupedString))
                return i + amountOfUniqueChars;
        }
        return -1;
    }
    private static bool AllUnique(string input)
    {
        var array = input.ToCharArray();
        foreach (var value in array)
        {
            var ignoreSelf = false;
            foreach (var value2 in array)
            {
                if (value == value2)
                {
                    if (ignoreSelf)
                    {
                        return false;
                    }
                    ignoreSelf = true;
                }
            }
        }
        return true;
    }
}