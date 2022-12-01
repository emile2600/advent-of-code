namespace Tools.Models;

public class Input
{
    public readonly string Data;
    public readonly string AbsolutePath;
    public Input(string absolutePath)
    {
        AbsolutePath = absolutePath;
        Data = File.OpenText(AbsolutePath).ReadToEnd();
    }
}