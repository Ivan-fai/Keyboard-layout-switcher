using Switcher;
using System;
using System.Text;
using System.Text.Json;

class Program
{
    static void Main()
    {
        var converter = new LayoutConverter("TextFile1.txt");

        Console.Write("Enter text to convert: ");
        string? input = Console.ReadLine();

        string result = converter.Convert(input) ?? "Can't recognize";
        Console.WriteLine($"Result: {result}");
    }
}