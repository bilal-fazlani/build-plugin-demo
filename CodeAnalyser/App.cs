using System;
using System.Drawing;
using System.IO;
using CommandDotNet.Attributes;
using Console = Colorful.Console;

namespace CodeAnalyser
{
    class App
    {
        private readonly int _lineThreshold;
        private readonly bool _verbose;

        public App([Option(ShortName = "l")]int lineThreshold = 10, bool verbose = false)
        {
            _lineThreshold = lineThreshold;
            _verbose = verbose;
        }
        
        [DefaultMethod]
        public void Run()
        {            
            int errors = 0;
            
            foreach (var file in FileFinder.GetCsFiles(Directory.GetCurrentDirectory()))
            {
                if(file.LineCount > _lineThreshold)
                {
                    errors += 1;
                    Console.WriteLine(file, Color.Red);
                }
                else if(_verbose) Console.WriteLine(file);
            }

            if (errors > 0)
            {
                Console.WriteLine($"\n{errors} file(s) have greater than {_lineThreshold} lines", Color.Red);
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("\nAnalysis completed successfully");
            }
        }
    }
}