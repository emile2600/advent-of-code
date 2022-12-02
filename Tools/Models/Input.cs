using System.Collections.Immutable;

namespace Tools.Models;

public class Input
{
    public readonly ImmutableArray<string> DataSplitOnBreakLines;
    public readonly string Data;
    public readonly string AbsolutePath;
    public Input(string absolutePath)
    {
        AbsolutePath = absolutePath;
        Data = File.OpenText(AbsolutePath).ReadToEnd();
        DataSplitOnBreakLines =
            ImmutableArray.Create(Data.Split(Environment.NewLine));
    }
}