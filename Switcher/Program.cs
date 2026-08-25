using Switcher;
using System;
using System.Text;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string filePath = "TextFile1.txt";
        var dictionaty = InitDictionary(filePath);

        //Entering text
        Console.Write("Enter text to convert: ");
        string? unformattedText = Console.ReadLine();
        string? formattedText = Switch(dictionaty, unformattedText) ?? "Can't recognize";

        Console.Write("Result: ");
        Console.WriteLine(formattedText);
    }
    public static Dictionary<char, char> InitDictionary(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var dict = JsonSerializer.Deserialize<Dictionary<char, char>>(json) ?? new();
        return dict;
    }
    static public string? Switch(Dictionary<char, char> dict, string? unformattedText)
    {
        string formattedText;
        StringBuilder stringBuilder = new StringBuilder();
        SpecialChars specialChars = new SpecialChars();

        if (dict != null)
        {
            bool? isLatin = specialChars.CountLatinKiril(unformattedText);
            if (isLatin == null)
                return null;

            if (!isLatin.Value)
            {
                dict = dict.ToDictionary(pair => pair.Value, pair => pair.Key);
            }

            foreach (char ch in unformattedText)
            {
                if (dict.TryGetValue(ch, out char newChar))
                {
                    stringBuilder.Append(newChar);
                }
                else
                {
                    stringBuilder.Append(ch);
                }
            }
            return formattedText = stringBuilder.ToString();
        }
        else
        {
            return null;
        }
    }
}