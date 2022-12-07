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
                _ => CommandType.Into
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
    private interface FOO
    {
        public string Name { get; set; }
        
    }
    private class File : FOO
    {
        public int    Size { get; set; }
        public string Name { get; set; }
        public File(string s)
        {
            var matches = Regex.Matches(s, @"\w{1,}");
            SetProperties(matches, this);
        }
        private static void SetProperties(MatchCollection matches, File file)
        {
            for (var i = 0; i < matches.Count; i++)
            {
                if (i == 0)
                    file.Size = int.Parse(matches[i].Value);
                else
                    file.Name = matches[i].Value;
            }
        }
    }
    private class Folder : FOO
    {

        public string           Name  { get; set; }
        public IEnumerable<FOO> Files { get; set; }
        
    }
    public static void GoThrough()
    {
        var inputs = Input.DataSplitOnBreakLines;
        var files = new List<FOO>();
        Command command = null;
        for (var i = 0; i < inputs.Length; i++)
        {
            if (command != null)
            {
                if (command.Type == Command.CommandType.List)
                {
                    
                }
            }
            command = new Command(inputs[0]);
            
        }
    }
}