using System.Text.RegularExpressions;

namespace Tools.Tools;

public static class StringManipulator
{
    public static IEnumerable<string> SplitOnBreakLine(this string s) 
        => s
            .Split(new []{Environment.NewLine, "\n", "\r\n", "\r"}, StringSplitOptions.None);
    public static IEnumerable<string> RemoveEmptySpace(this IEnumerable<string> array)
        => array.Where(s => !string.IsNullOrWhiteSpace(s));
    
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

}