using Tools.Models;

namespace AOC2022.Day2;

public class Day2
{
    private static Input Input = new("C:/Users/Emile/RiderProjects/Advent of code/AOC2022/Day2/input");
    private enum Shapes
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    };
    private static int CalculatePoints(Shapes me, Shapes other)
    {
        if (me == other)
            return 3 + (int)me;
        if (me.Equals(3) && other.Equals(1))
            return 0 + (int)me;
        if (me < other)
            return 6 + (int)me;
        return 0 + (int)me;
    }
    private static Shapes Parse(string input)
    {
        switch (input)
        {
            case "A":
            case "X":
                return Shapes.Rock;
            case "B":
            case "Y":
                return Shapes.Paper;
            default:
                return Shapes.Scissors;
        }
    }
    public static int CalculateStrategy()
    {
        var inputs = Input.Data.Split(new[] {Environment.NewLine, "\r\n", "\n", "\r","\n\n", ""}, StringSplitOptions.None);
        var filterdInputs = inputs.Where(s => !string.IsNullOrWhiteSpace(s));
        var doubleInput = filterdInputs.Select(input => input.Split(" "));
        var parsedinput = doubleInput.Select(inputs => inputs.Select(Parse));
        var sum = 0;
        foreach (var doubleParsedInput in parsedinput)
        {
            var list = doubleParsedInput.ToArray();
            sum += CalculatePoints(list[0], list[1]);
        }
        return sum;
    }
}