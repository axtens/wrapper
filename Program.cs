using System.Diagnostics;

namespace wrapper;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2) {
            Console.WriteLine("wrapper.exe path_to_exe path_to_arguments");
            return;
        }
        if (!File.Exists(args[0])) {
            Console.WriteLine("path_to_exe file not found.");
            return;
        }
        if (!File.Exists(args[1])) {
            Console.WriteLine("path_to_arguments file not found.");
            return;
        }
        string argumentList = string.Join(' ',File.ReadAllLines(args[1]).Select(x => "\"" + x.Trim() + "\"").ToArray());
        ProcessStartInfo psi = new ProcessStartInfo(args[0]) {
            UseShellExecute = false,
            Arguments = argumentList
        };
        Console.WriteLine(argumentList);
        Process.Start(psi);
    }
}