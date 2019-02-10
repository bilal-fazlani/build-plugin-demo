using CommandDotNet;

namespace CodeAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            var appRunner = new AppRunner<App>();
            appRunner.Run(args);
        }
    }
}