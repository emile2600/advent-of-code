namespace Tools.Tools;

public static class StringManipulator
{
    public static string[] SplitOnBreakLine(this string s) 
        => s.Split(new []{Environment.NewLine, "\n", "\r\n", "\r"}, StringSplitOptions.None);

}