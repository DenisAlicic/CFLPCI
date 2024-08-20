// See https://aka.ms/new-console-template for more information

namespace CFLPCI;

internal class Program
{
    private static readonly string projectDir =
        Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

    private static void Main(string[] args)
    {
        Console.WriteLine("Ucitavanje");
        var context = new OptimizationContext(Path.Combine(projectDir, @"PublicInstances\PublicInstances\wlp01.dzn"));
        Console.WriteLine("Pocetak optimizacije");
        context.Optimize();
        Console.WriteLine("Kraj!");
    }
}