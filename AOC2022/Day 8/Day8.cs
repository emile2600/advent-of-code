using Tools.Models;
using Tools.Tools;

namespace AOC2022.Day_8;

public static class Day8
{
    private static readonly Input Input = new(@"Day 8/input.txt");
    private class Tree
    {
        public int Length { get; }
        public Tree(int length)
        {
            Length = length;
        }
    }
    public static int TreesVisible()
    {
        var input = Input.DataSplitOnBreakLines;
        var parsedInput = input
            .Select(stringInput => stringInput
                .Select(charInput => new Tree(int.Parse(charInput.ToString())))
                .ToList())
            .ToList();
        var colInput = Input.Data
            .SplitOnColumn(1,parsedInput[0].Count);
        var parsedCol = colInput
            .Select(s => s.Select(Parse)).ToArray();

        var count = 0;
        var colIndex = 0;
        foreach (var row in parsedInput)
        {
            var rowIndex = 0;
            var col = parsedCol[colIndex];
            foreach (var tree in row)
            {
                if (IsVisible(rowIndex, colIndex, tree, row,col))
                    count++;
                rowIndex++;
            }
            colIndex++;
        }
        return count;
    }

    private static Tree Parse(char c)
        => new(int.Parse(c.ToString()));
    private static bool IsVisible(int rowIndex, int colIndex, Tree tree, IEnumerable<Tree> row, IEnumerable<Tree> column)
    {
        var rowReversed = row.Reverse();
        var rowIndexReversed = rowReversed.Count() - rowIndex;
        var colReversed = column.Reverse();
        var colIndexReversed = colReversed.Count() - colIndex;
        return IsVisible(rowIndex, tree, row) 
               || IsVisible(rowIndexReversed, tree, rowReversed)
               || IsVisible(colIndex, tree, column) 
               || IsVisible(colIndexReversed, tree, colReversed);
    }
    private static bool IsVisible(int treeIndex, Tree tree, IEnumerable<Tree> lineOfSight)
    {
        Tree tallestTree = null;
        var index = 0;
        foreach (var treeInLightOfSight in lineOfSight)
        {
            if (index == treeIndex)
                return true;
            tallestTree ??= treeInLightOfSight;
            if (tree.Length <= tallestTree.Length)
                return false;
            if (treeInLightOfSight.Length > tallestTree.Length)
                tallestTree = treeInLightOfSight;
            index++;
        }
        throw new Exception("no exit");
    }
    
}