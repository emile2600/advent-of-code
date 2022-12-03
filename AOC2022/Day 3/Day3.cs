using Tools.Models;

namespace AOC2022.Day_3;

public class Day3
{
    private static readonly Input Input = new(@"Day 3/input.txt");
    private class Rucksack
    {
        public readonly char[] Compartment1;
        public readonly char[] Compartment2;
        public readonly string RucksackContent;
        public Rucksack(string rucksackContent)
        {
            RucksackContent = rucksackContent;
            var splitContent = SplitContent(rucksackContent);
            Compartment1 = splitContent[0].ToCharArray();
            Compartment2 = splitContent[1].ToCharArray();
            
        }
        private static string[] SplitContent(string rucksackContent)
        {
            const int splitAmount = 2;
            var content = rucksackContent.ToCharArray();
            var compartments = new string[2];
            var middlePoint = content.Length / splitAmount;
            for (var i = 0; i < middlePoint; i++)
                compartments[0] += content[i];
            
            for (var i = content.Length - 1; i >= middlePoint; i--)
                compartments[1] += content[i];
            
            return compartments;
        }
    }
    public static int GetPrioritySum()
    {
        var rucksacks = Input.DataSplitOnBreakLines
            .Select(input => new Rucksack(input));
        return rucksacks.Sum(CalculatePriority);
    }
    public static int GetBadgeGroupSum()
    {
        var rucksacks = Input.DataSplitOnBreakLines
            .Select(input => new Rucksack(input));
        var groupedRucksacks = GroupRucksack(rucksacks);
        return groupedRucksacks.Sum(CalculatePriority);
    }
    private static IEnumerable<IEnumerable<Rucksack>> GroupRucksack(IEnumerable<Rucksack> rucksacks, int groupSize = 3)
        => rucksacks
            .Select((_, i) => rucksacks
                .Skip(groupSize * i)
                .Take(groupSize));
    
    private static int CalculatePriority(IEnumerable<Rucksack> rucksacks)
    {
        if (!rucksacks.Any())
            return 0;
        var duplicateItem = GetDuplicateChar(rucksacks);
        var priorityValue = CalculatePriority(duplicateItem);
        return priorityValue;
    }
    private static int CalculatePriority(Rucksack rucksack)
    {
        var duplicateItem = GetDuplicateChar(rucksack);
        var priorityValue = CalculatePriority(duplicateItem);
        return priorityValue;
    }
    private static int CalculatePriority(char duplicate)
    {
        var capitalizedChar = duplicate.ToString().ToUpperInvariant().ToCharArray()[0];
        var alphabetPosition = capitalizedChar - 64;
        var priorityValue = alphabetPosition + (capitalizedChar.Equals(duplicate) ? 26 : 0);
        return priorityValue;
    }
    private static char GetDuplicateChar(Rucksack rucksack)
    =>  GetDuplicateChar(rucksack.Compartment1, rucksack.Compartment2)[0];
    private static char GetDuplicateChar(IEnumerable<Rucksack> rucksacks)
    {
        char[] duplicateItems = null;
        foreach (var rucksack in rucksacks)
        {
            var rucksackItems = rucksack.RucksackContent.ToCharArray();
            duplicateItems = GetDuplicateChar(rucksackItems, duplicateItems);
        }
        return duplicateItems![0];
    }
    private static char[] GetDuplicateChar(char[] itemsRucksack1, char[]? itemsRucksack2)
    {
        if (itemsRucksack2 is null)
            return itemsRucksack1;
        var duplicate = itemsRucksack1
            .Where(itemsRucksack2.Contains);
        return duplicate.ToArray();
    }
}