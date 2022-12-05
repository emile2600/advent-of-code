using System.Text.RegularExpressions;
using Tools.Models;
using Tools.Tools;

namespace AOC2022.Day_5;

public static class Day5
{
    private static readonly Input Input = new(@"Day 5/Input.txt");
    private class Command
    {
        public readonly int Move;
        public readonly int From;
        public readonly int To;

        public Command(string input)
        {
            var matches = Regex.Matches(input, @".\d+");
            var parsedMatches = matches
                .Select(match => int.Parse(match.Value))
                .ToArray();
            Move = parsedMatches[0];
            From = parsedMatches[1];
            To = parsedMatches[2];
        }
    }

    public static string GetTopOrder()
    {
        var splitInput = Input.Data.Split("\r\n\r\n");
        var stringTable = splitInput[0];
        var stringCommands = splitInput[1];
        var columns = stringTable
            .SplitOnColumn(4)
            .Select(Parse)
            .ToArray();
        var commands = GetCommands(stringCommands);
        Execute(columns, commands, true);
        return GetTop(columns);
    }
    private static Stack<string> Parse(string input)
    {
        input = input.Replace(" ", "");
        var matches = Regex.Matches(input, @".{1,3}");
        var stack = new Stack<string>();
        foreach (var match in matches.Reverse())
        {
            if (int.TryParse(match.Value, out _))
                continue;
            var value = match.Value
                .Replace("[", "")
                .Replace("]", "");
            stack.Push(value);
        }
        return stack;
    }
    private static IEnumerable<Command> GetCommands(string input)
    {
        var splitInput = input
            .SplitOnBreakLine()
            .RemoveEmptySpace()
            .ToArray();
        var returnValue = splitInput
            .Select(s => new Command(s));
        return returnValue;
    }
    private static void Execute(Stack<string>[] columns, IEnumerable<Command> commands, bool crateMover9001 = false)
    {
        foreach (var command in commands)
        {
            var move = command.Move;
            var from = command.From - 1;
            var to = command.To - 1;
            var taken = new List<string>();
            for (var i = 0; i < move; i++)
                taken.Add(columns[from].Pop());
            if (crateMover9001)
                taken.Reverse();
            foreach (var s in taken)
                columns[to].Push(s);
        }
    }
    private static string GetTop(Stack<string>[] columns)
        => columns
            .Aggregate("", (current, t) => current + t.Pop());
    
}