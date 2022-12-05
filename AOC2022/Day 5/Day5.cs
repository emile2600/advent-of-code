using System.Text.RegularExpressions;
using Tools.Models;
using Tools.Tools;

namespace AOC2022.Day_5;

public class Day5
{
    private static Input Input = new(@"Day 5/Input.txt");
    private class Column
    {
        private Stack<string> Values;

        public Column(Stack<string> values)
        {
            Values = values;
        }

        public IEnumerable<string> Take(int amount)
        {
            for (int i = 0; i < amount; i++)
                yield return Values.Pop();
            
        }

        public void Add(IEnumerable<string> toAdd)
        {
            foreach (var s in toAdd)
                Values.Push(s);
        }

        public string GetTop
            => Values
                .Last()
                .Replace("[","")
                .Replace("]","");
    }
    private class Command
    {
        public readonly int Move;
        public readonly int From;
        public readonly int To;

        public Command(string s)
        {
            var replace = s.Replace(" ","");
            replace = replace.Replace("move","");
            Move = int.Parse(char.ToString(replace[0]));
            replace = replace[1..].Replace("from", "");
            From = int.Parse(char.ToString(replace[0]));
            replace = replace[1..].Replace("to", "");
            To = int.Parse(char.ToString(replace[0]));
        }
    }

    public static string GetTopOrder()
    {
        var splitInput = Input.Data.Split("\n\n");
        var stringTable = splitInput[0];
        var stringCommands = splitInput[1];
        var columns = stringTable
            .SplitOnColumn(4)
            .Select(s => s
                .Reverse()
                .Take(s.Length - 1)
                .Reverse()
                .Aggregate("", (current, sInput) => current + sInput))
            .Select(Parse);
        var commands = GetCommands(stringCommands);
        Execute(columns, commands);
        return columns
            .Select(column => column.GetTop)
            .Merge();
    }
    private static Column Parse(string input)
    {
        var regex = new Regex(@"/.{1,4}/g");
        var stringArray = regex.Split(input);
        var stack = new Stack<string>(stringArray);
        var column = new Column(stack);
        return column;
    } 
    private static IEnumerable<Command> GetCommands(string input)
        => input
            .SplitOnBreakLine()
            .Select(s => new Command(s));
    private static void Execute(IEnumerable<Column> columns, IEnumerable<Command> commands)
    {
        var columnList = columns.ToList();
        foreach (var command in commands)
        {
            var move = command.Move;
            var from = command.From - 1;
            var to = command.To - 1;
            var taken = columnList[from].Take(move);
            columnList[to].Add(taken);
        }
    }
}