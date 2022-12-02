using Tools;
using Tools.Models;
using Tools.Tools;

namespace AOC_2022.Day_1;

public class Day1
{
    private static readonly Input Input = new("Day 1/input.txt");
    private class Elf
    {
        public readonly decimal SumOfCalories;
        public Elf(string calories)
        {
            SumOfCalories = calories
                .SplitOnBreakLine()
                .Sum(s => {
                    decimal.TryParse(s, out var parsedValue);
                    return parsedValue;
                });
        }
    }
    public static decimal GetTopCalories(int topAmount = 1)
    {
        var elves = Input.Data
            .Split(new[] {"\n\n"}, StringSplitOptions.None)
            .Select(calories => new Elf(calories));
        return elves
            .OrderByDescending(elf => elf.SumOfCalories)
            .Take(topAmount)
            .Sum(elf => elf.SumOfCalories);
    }
}