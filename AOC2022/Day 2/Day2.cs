using Tools.Models;

namespace AOC2022.Day2;

public static class Day2
{
    private static Input Input = new(@"Day 2/input.txt");
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
        if (me == Shapes.Rock && other == Shapes.Scissors)
            return Outcomes.Win;
        if (me == Shapes.Scissors && other == Shapes.Rock)
            return Outcomes.Loss;
        if (me > other)
            return Outcomes.Win;
        return Outcomes.Loss;
    }
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

    public static int CalculateStrategyPoints(bool onResult = false)
    {
        var doubleInput = Input.DataSplitOnBreakLines
            .Select(input => input.Split(" "));
        var sanitizedInputs = doubleInput
            .Where(array => !array.Any(s => string.IsNullOrWhiteSpace(s)));
        return onResult ? 
            CalculateStrategyPointsTotalResult(sanitizedInputs) :
            CalculateStrategyPointsTotalMatch(sanitizedInputs);
    }

    private static int CalculateStrategyPointsTotalMatch(IEnumerable<string[]> input)
    {
        var parsedInput = input
            .Select(inputs => new Tuple<Shapes,Shapes>(Parse(inputs[0]),Parse(inputs[1])));
        var sum = parsedInput
            .Sum(input => CalculatePoints(input.Item1,input.Item2));
        return sum;
    }
    private static int CalculateStrategyPointsTotalResult(IEnumerable<string[]> input)
    {
        
        var parsedInput = input
            .Select(inputs => new Tuple<Shapes,Outcomes>(Parse(inputs[0]),ParseOutcomes(inputs[1])));
        var sum = parsedInput
            .Sum(input => CalculatePoints(input.Item2, input.Item1));
        return sum;
    }
}