using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Switcher;

public class LayoutConverter
{
    private readonly Dictionary<char, char> _engRusDict;
    private readonly Dictionary<char, char> _rusEngDict;
    private readonly LanguageDetector _detector = new();

    public LayoutConverter(string configPath)
    {
        string json = File.ReadAllText(configPath);
        _engRusDict = JsonSerializer.Deserialize<Dictionary<char, char>>(json) ?? new();
        _rusEngDict = _engRusDict.ToDictionary(pair => pair.Value, pair => pair.Key);
    }

    public string? Convert(string? unformattedText)
    {
        if (string.IsNullOrEmpty(unformattedText))
            return null;

        bool? isLatin = _detector.CountLatinKiril(unformattedText);
        if (isLatin == null)
            return null;

        var currentDict = isLatin.Value ? _engRusDict : _rusEngDict;
        var stringBuilder = new StringBuilder(unformattedText.Length);

        foreach (char ch in unformattedText)
        {
            stringBuilder.Append(currentDict.TryGetValue(ch, out char newChar) ? newChar : ch);
        }

        return stringBuilder.ToString();
    }
}