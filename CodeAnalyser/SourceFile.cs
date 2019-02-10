using System.IO;

namespace CodeAnalyser
{
    public class SourceFile
    {
        public long LineCount { get; }
        public string Name { get; }

        public SourceFile(long lineCount, string name)
        {
            LineCount = lineCount;
            Name = name;
        }
        
        public override string ToString()
        {
            return $"[{LineCount:000}] {ConvertToRelative(Name)}";
        }
        
        static string ConvertToRelative(string fullpath)
        {
            return fullpath.Replace(Directory.GetCurrentDirectory(), ".");
        }
    }
}