using System.Collections.Immutable;
using Tools.Tools;

namespace Tools.Models;

public class Input
{
    // If you add a new input.txt file remeber to add it to the build files
    public readonly ImmutableArray<string> DataSplitOnBreakLines;
    public readonly string Data;
    public Input(string relativePath)
    {
        Data = File.OpenText(relativePath).ReadToEnd();
        var dataSplitOnBreakLines = Data.SplitOnBreakLine();
        var sanitizedDataSplitOnBreakLines = dataSplitOnBreakLines
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();
        DataSplitOnBreakLines =
            ImmutableArray.Create(sanitizedDataSplitOnBreakLines);
    }
}