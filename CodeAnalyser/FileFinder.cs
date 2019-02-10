using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeAnalyser
{
    public static class FileFinder
    {        
        public static IEnumerable<SourceFile> GetCsFiles(string path)
        {
            if (!IsExcluded(path))
            {
                foreach (var fileName in Directory.EnumerateFiles(path))
                {
                    if(fileName.EndsWith(".cs"))
                        yield return new SourceFile(GetLineCount(fileName), fileName);
                }

                foreach (var directoryName in Directory.EnumerateDirectories(path))
                {
                    foreach (var fileName in GetCsFiles(directoryName))
                    {
                        yield return fileName;
                    }
                }
            }
        }

        static bool IsExcluded(string path)
        {
            var excluded = new[] {"obj", "bin"};
            return excluded.Any(path.EndsWith);
        }

        static long GetLineCount(string file)
        {
            return File.ReadLines(file).Count(x => !string.IsNullOrWhiteSpace(x));
        }
    }
}