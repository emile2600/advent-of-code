using Tools.Models;

namespace AOC2022.Day_3;

public static class Day3
{
    private static readonly Input Input = new(@"Day 3/input.txt");
    private class Rucksack
    {
        public readonly char[] Compartment1;
        public readonly char[] Compartment2;
        public readonly char[] RucksackContent;
        public Rucksack(string rucksackContent)
        {
            RucksackContent = rucksackContent.ToCharArray();
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
            .Select(input => new Rucksack(input))
            .ToArray();
        var groupedRucksacks = GroupRucksack(rucksacks);
        return groupedRucksacks.Sum(CalculatePriority);
    }
    private static IEnumerable<IEnumerable<Rucksack>> GroupRucksack(Rucksack[] rucksacks, int groupSize = 3)
    {
        for (var i = 0; i < rucksacks.Length / groupSize; i++)
            yield return rucksacks.Skip(i * groupSize).Take(groupSize);
    }
    private static int CalculatePriority(IEnumerable<Rucksack> rucksacks)
    {
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
    // Uses unicode trickery to calculate the priority 
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
        char[]? duplicateItems = null;
        foreach (var rucksack in rucksacks)
        {
            duplicateItems = duplicateItems is null ?
                rucksack.RucksackContent :
                GetDuplicateChar(rucksack.RucksackContent, duplicateItems);
        }
        
        return duplicateItems![0];
    }
    private static char[] GetDuplicateChar(char[] itemsRucksack1, char[] itemsRucksack2)
    {
        var duplicate = itemsRucksack1
            .Where(itemsRucksack2.Contains);
        return duplicate.ToArray();
    }
}