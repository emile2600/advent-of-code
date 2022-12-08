using System.Text;
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
        int columnSize,
        int regexMin = 1)
    {
        var splitInput = input.SplitOnBreakLine();
        splitInput = splitInput.RemoveEmptySpace();
        var matches = splitInput
            .Select(s => Regex.Matches(s, @".{" + regexMin + "," + regexMax + "}"))
            .ToArray();
        var columns = new string[columnSize];
        foreach (var match in matches.AsEnumerable())
        {
            for (int i = 0; i < columnSize; i++)
            {
                columns[i] += match[i].Value;
            }
        }
        return columns;
    }

}