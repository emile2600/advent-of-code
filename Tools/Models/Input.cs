using System.Collections.Immutable;

namespace Tools.Models;

public class Input
{
    // If you add a new input.txt file remeber to add it to the build files
    public readonly ImmutableArray<string> DataSplitOnBreakLines;
    public readonly string Data;
    public Input(string relativePath)
    {
        Data = File.OpenText(relativePath).ReadToEnd();
        DataSplitOnBreakLines =
            ImmutableArray.Create(Data.Split(Environment.NewLine));
    }
}