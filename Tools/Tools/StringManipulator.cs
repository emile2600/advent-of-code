namespace Tools.Tools;

public static class StringManipulator
{
    public static string[] SplitOnBreakLine(this string s) => s.Split(Environment.NewLine);

}