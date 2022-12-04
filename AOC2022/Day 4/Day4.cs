using Tools.Models;

namespace AOC2022.Day_4;

public class Day4
{
    private static readonly Input Input = new(@"Day 4/input.txt");
    private class ElfPair
    {
        private readonly int[] Sections1;
        private readonly int[] Sections2;
        public ElfPair(string sections)
        {
            var pair = sections.Split(",");
            Sections1 = ParseToSections(pair[0]).ToArray();
            Sections2 = ParseToSections(pair[1]).ToArray();
        }
        private static IEnumerable<int> ParseToSections(string input)
        {
            var splitInput = input.Split("-");
            var min = int.Parse(splitInput[0]); 
            var max = int.Parse(splitInput[1]);
            for (var i = min; i <= max; i++)
                yield return i;
        }

        public bool IsFullyInContained
            => Sections1[0] >= Sections2[0] && Sections1[^1] <= Sections2[^1] ||
               Sections2[0] >= Sections1[0] && Sections2[^1] <= Sections1[^1];
        
        public bool IsOverlap 
            => Sections1.Any(section => Sections2.Contains(section));
    }
    public static int GetTotal(bool fullContained = false)
    {
        var pairs = Input.DataSplitOnBreakLines
            .Select(input => new ElfPair(input));
        return fullContained ? 
            AmountOfFullyContained(pairs) : 
            AmountOfOverlaps(pairs);
    }

    private static int AmountOfFullyContained(IEnumerable<ElfPair> elfPairs)
        => elfPairs.Sum(pair => pair.IsFullyInContained ? 1 : 0);
    private static int AmountOfOverlaps(IEnumerable<ElfPair> elfPairs)
        => elfPairs.Sum(pair => pair.IsOverlap ? 1 : 0);
}