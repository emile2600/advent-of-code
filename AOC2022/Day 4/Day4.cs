using Tools.Models;

namespace AOC2022.Day_4;

public class Day4
{
    private static Input Input = new(@"Day 4/input.txt");
    private class ElfPair
    {
        private IEnumerable<int> Sections1;
        private IEnumerable<int> Sections2;
        public ElfPair(string sections)
        {
            var pair = sections.Split(",");
            Sections1 = ParseToSections(pair[0]);
            Sections2 = ParseToSections(pair[1]);
        }
        private static IEnumerable<int> ParseToSections(string input)
        {
            var splitInput = input.Split("-");
            var min = int.Parse(splitInput[0]); 
            var max = int.Parse(splitInput[1]);
            for (var i = min; i <= max; i++)
                yield return i;
            
        } 
        public bool IsFullyInContained()
        {
            var section2ContainsSection1 = 
                Sections1.All(section => Sections2.Contains(section));
            if (section2ContainsSection1)
                return true;
            var section1ContainsSection2 = Sections2.All(section => Sections1.Contains(section));
            return section1ContainsSection2;
        }
        public bool IsOverlap()
        {
            var section2ContainsSection1 = 
                Sections1.Any(section => Sections2.Contains(section));
            if (section2ContainsSection1)
                return true;
            var section1ContainsSection2 = Sections2.Any(section => Sections1.Contains(section));
            return section1ContainsSection2;
        }
    }

    public static int AmountOfFullyContained()
    {
        var pairs = Input.DataSplitOnBreakLines
            .Select(input => new ElfPair(input));
        var sum = 
            pairs.Sum(pair => pair.IsFullyInContained() ? 1 : 0);
        return sum;
    }
    public static int AmountOfOverlaps()
    {
        var pairs = Input.DataSplitOnBreakLines
            .Select(input => new ElfPair(input));
        var sum = 
            pairs.Sum(pair => pair.IsOverlap() ? 1 : 0);
        return sum;
    }
}