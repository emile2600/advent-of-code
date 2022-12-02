using Tools.Models;

namespace AOC2022.Day2;

public class Day2
{
    private static Input Input = new("C:/Users/Emile/RiderProjects/advent-of-code/AOC2022/Day2/input");
    private enum Shapes
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    };

    private enum Outcomes
    {
        Loss = 0,
        Draw = 3,
        Win = 6
    }

    private static Outcomes Condition(Shapes me, Shapes other)
    {
        if (me == other)
            return Outcomes.Draw;
        if (me ==Shapes.Rock && other == Shapes.Scissors)
            return Outcomes.Win;
        if (me == Shapes.Scissors && other == Shapes.Rock)
            return Outcomes.Loss;
        if (me > other)
            return Outcomes.Win;
        return Outcomes.Loss;
    }
    // debug this
    private static int CalculatePoints(Shapes other, Shapes me)
    {
        return (int)Condition(me, other) + (int)me;
    }
    private static int CalculatePoints(Outcomes outcomes, Shapes shape)
    {
        foreach (Shapes shapeValue in Enum.GetValues(typeof(Shapes)))
        {
            var fooOutcome = Condition(shapeValue, shape);
            if (fooOutcome == outcomes)
                return (int) shapeValue + (int)fooOutcome;
        }
        return 0;
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

    private static Outcomes ParseOutcomes(string input)
    {
        switch (input)
        {
            case "X":
                return Outcomes.Loss;
            case "Y":
                return Outcomes.Draw;
            default:
                return Outcomes.Win;
        }
    }
    public static int CalculateStrategy()
    {
        var inputs =
            Input.Data.Split(new[] {Environment.NewLine, "\r\n", "\n", "\r","\n\n", ""}, StringSplitOptions.None);
        var doubleInput = inputs.Select(input => input.Split(" "));
        var filterdInputs = doubleInput.Where(array => !array.Any(s => string.IsNullOrWhiteSpace(s)));
        var parsedinput = filterdInputs.Select(inputs => inputs.Select(Parse));
        var sum = 0;
        foreach (var doubleParsedInput in parsedinput)
        {
            var list = doubleParsedInput.ToArray();
            sum += CalculatePoints(list[0], list[1]);
        }
        return sum;
    }
    public static int CalculateResult()
    {
        var inputs =
            Input.Data.Split(new[] {Environment.NewLine, "\r\n", "\n", "\r","\n\n", ""}, StringSplitOptions.None);
        var doubleInput = inputs.Select(input => input.Split(" "));
        var filterdInputs = doubleInput.Where(array => !array.Any(s => string.IsNullOrWhiteSpace(s)));
        var parsedinput = filterdInputs.Select(inputs => new Tuple<Shapes,Outcomes>(Parse(inputs[0]),ParseOutcomes(inputs[1])));
        var sum = 0;
        foreach (var doubleParsedInput in parsedinput)
        {
            sum += CalculatePoints(doubleParsedInput.Item2, doubleParsedInput.Item1);
        }
        return sum;
    }
}