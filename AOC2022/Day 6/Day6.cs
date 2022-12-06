using Tools.Models;

namespace AOC2022.Day_6;

public static class Day6
{
    private static readonly Input Input = new (@"Day 6\input.txt");
    public static int GetStartOfPacket(int amountOfUniqueChars)
    {
        for (var i = 0; i < Input.Data.Length; i++)
        {
            var groupedString = Input.Data.Substring(i, amountOfUniqueChars);
            if (AllUnique(groupedString))
                return i + amountOfUniqueChars;
        }
        throw new Exception("No start of packet was found");
    }
    private static bool AllUnique(string input)
    {
        var array = input.ToCharArray();
        foreach (var value in array)
        {
            var isDuplicate = false;
            foreach (var value2 in array)
            {
                if (value != value2)
                    continue;
                if (isDuplicate)
                    return false;
                isDuplicate = true;
            }
        }
        return true;
    }
}