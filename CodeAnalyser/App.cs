using System;
using System.Drawing;
using System.IO;
using CommandDotNet.Attributes;
using Console = Colorful.Console;

namespace CodeAnalyser
{
    [ApplicationMetadata(Name = "analyse-code", Description = "reads the number of lines for every source file and breaks the build" +
                                                              " if they are more than the threshold value")]
    class App
    {
        private readonly int _lineThreshold;
        private readonly bool _verbose;

        public App([Option(ShortName = "l", LongName = "line-threshold", Description = "analysis will report error if a file has more number of lines than this value")]int lineThreshold = 10, [Option(
            Description = "shows all files with their number of lines")]bool verbose = false)
        {
            _lineThreshold = lineThreshold;
            _verbose = verbose;
        }
        
        [DefaultMethod]
        public void Run()
        {            
            int errors = 0;
            
            foreach (var file in FileFinder.GetSourceFiles(Directory.GetCurrentDirectory()))
            {
                if(file.LineCount > _lineThreshold)
                {
                    errors += 1;
                    Console.WriteLine(file, Color.Red);
                }
                else if(_verbose) Console.WriteLine(file, Color.DarkGray);
            }

            if (errors > 0)
            {
                Console.WriteLine($"\n{errors} file(s) have greater than {_lineThreshold} lines", Color.Red);
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("\nAnalysis completed successfully", Color.LimeGreen);
            }
        }
    }
}