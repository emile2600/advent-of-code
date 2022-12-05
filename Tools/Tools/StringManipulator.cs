using System.Text.RegularExpressions;

namespace Tools.Tools;

public static class StringManipulator
{
    public static string[] SplitOnBreakLine(this string s) 
        => s.Split(new []{Environment.NewLine, "\n", "\r\n", "\r"}, StringSplitOptions.None);

    public static IEnumerable<string> SplitOnColumn(
        this string input,
        int regexMax,
        int regexMin = 1)
    {
        var splitInput = input.SplitOnBreakLine();
        var matches = splitInput
            .Select(s => Regex.Matches(s, @".{" + regexMin + "," + regexMax + "}"))
            .ToArray();
        var columns = new string[matches.Length];
        foreach (var match in matches.AsEnumerable())
        {
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] += match[i];
            }
        }
        return columns;
    }

    private static IEnumerable<string> Spread(this IEnumerable<string[]> list)
    {
        foreach (var array in list)
        {
            foreach (var s in array)
            {
                yield return s;
            }
        }
    }
    public static string Merge(this string[] strings)
        => strings.Aggregate("", (current, sInput) => current + sInput);
    public static string Merge(this IEnumerable<string> strings)
        => strings.ToArray().Merge();

}