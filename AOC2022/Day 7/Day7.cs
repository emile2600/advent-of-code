using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Tools.Models;

namespace AOC2022.Day_7;

public class Day7
{
    private static Input Input = new(@"Day 7\input.txt");
    private class Command
    {
        public enum CommandType
        {
            Into,
            OutOf,
            Reset,
            List
        }
        public CommandType Type { get; }
        public string?     To   { get; }
        public Command(string s)
        {
            s = s.Replace("$", "");
            s = s.Replace(" ", "");
            Type = GetCommandType(s);
            if (Type == CommandType.Into)
                To = GetFile(s);
        }
        private static string GetFile(string s)
        {
            s = s.Replace("cd", "");
            s = s.Replace(" ", "");
            return s;
        }
        private static CommandType GetCommandType(string s)
        {
            return s[0] switch
            {
                'c' => Parse(s),
                _ => CommandType.List
            };
        }
        private static CommandType Parse(string s)
        {
            s = s.Replace("cd", "");
            return s switch
            {
                "/" => CommandType.Reset,
                ".." => CommandType.OutOf,
                _ => CommandType.Into
            };
        }
    }
    private class File
    {
        public Folder Parent { get; set; }
        public int    Size { get; set; }
        public string Name { get; set; }
        public File(int size, string name, Folder parent)
        {
            Size = size;
            Name = name;
            Parent = parent;
        }
    }
    private class Folder : File
    {
        public List<File> Childeren { get; } = new();

        public Folder(string name, Folder parent) : base(0, name, parent) { }

        public int GetSum()
        {
            var sum = 0;
            foreach (var child in Childeren)
            {
                if (child is Folder folder)
                    sum += folder.GetSum();
                else
                    sum += child.Size;
            }

            return sum;
        }

        public IEnumerable<Folder> GetFolders()
        {
            var childeren = new List<Folder>();
            foreach (var child in Childeren)
            {
                if (child is Folder folder)
                {
                    childeren.Add(folder);
                    childeren.AddRange(folder.GetFolders());
                }
            }

            return childeren;
        }
    }
    public static int GetSum(int maxFileSize)
    {
        var inputs = Input.DataSplitOnBreakLines;
        var topFolder = MapSystem(inputs.ToArray());

        var foo = topFolder
            .GetFolders()
            .Where(c=> c.GetSum() < maxFileSize);
        return foo.Sum(f => f.GetSum());
    }

    private static int GetSum()
    {
        var inputs = Input.DataSplitOnBreakLines;
        var topFolder = MapSystem(inputs.ToArray());
        return topFolder.GetSum();
    }

    public static int DeleteSum(int updateSize, int systemSpecs)
    {
        var inputs = Input.DataSplitOnBreakLines;
        var sizeRn = GetSum();
        var spaceToFreeUp = Math.Abs(systemSpecs - sizeRn - updateSize);
        var topFolder = MapSystem(inputs.ToArray());
        var foo = topFolder.GetFolders().Where(f => f.GetSum() >= spaceToFreeUp);
        return foo.Min(f => f.GetSum());
    }

    private static Folder MapSystem(string[] inputs)
    {
        Folder topFolder = null;
        Folder currentFolder = null;
        Command currentCommand;
        foreach (var input in inputs)
        {
            if (IsCommand(input))
            {
                currentCommand = new Command(input);
                switch (currentCommand.Type)
                {
                    case Command.CommandType.Reset:
                        topFolder = new Folder("/", null);
                        currentFolder = topFolder;
                        break;
                    case Command.CommandType.Into:
                        currentFolder = (Folder)currentFolder
                            .Childeren
                            .Single(file => file.Name.Equals(currentCommand.To) && file is Folder);
                        break;
                    case Command.CommandType.List:
                        continue;
                    case Command.CommandType.OutOf:
                        currentFolder = currentFolder.Parent;
                        break;
                }
            }
            else
            {
                currentFolder.Childeren.Add(
                    IsFolder(input) ?
                        new Folder(GetFolderName(input), currentFolder) :
                        new File(GetFileSize(input),GetFileName(input),currentFolder));
            }
        }

        return topFolder!;
    }

    

    private static string GetFileName(string s)
        => Regex.Matches(s, @"\w{1,}")[1].Value;
    private static int GetFileSize(string s)
        => int.Parse(Regex.Match(s, @"\d{1,}").Value);
    private static string GetFolderName(string s)
        => s.Replace("dir ", "");
    private static bool IsCommand(string s)
        => s[0] == '$';

    private static bool IsFolder(string s)
        => s[0] == 'd';
}