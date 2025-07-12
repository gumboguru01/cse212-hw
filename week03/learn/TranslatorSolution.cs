using System;
using System.Collections.Generic;

public class TranslatorSolution
{
    public static void Run()
    {
        var englishToGerman = new TranslatorSolution();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));    // Output: Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));  // Output: Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));  // Output: ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Adds a word pair to the dictionary.
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Returns the translation of the word or "???" if it doesn't exist.
    /// </summary>
    public string Translate(string fromWord)
    {
        return _words.ContainsKey(fromWord) ? _words[fromWord] : "???";
    }
}
