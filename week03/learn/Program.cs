using System;
using System.Collections.Generic;

public class FirstDuplicateFinder
{
    public static char? FindFirstDuplicate(string input)
    {
        var seen = new HashSet<char>();

        foreach (char c in input)
        {
            if (seen.Contains(c))
                return c;

            seen.Add(c);
        }

        return null; // or '?' if you prefer a char fallback
    }

    public static void Run()
    {
        string[] tests = { "abcdef", "aabbcc", "abcdea", "", "abB", "aAa", "ñáéñ" };

        foreach (var test in tests)
        {
            var result = FindFirstDuplicate(test);
            Console.WriteLine($"Input: {test} → First duplicate: {(result.HasValue ? result.ToString() : "None")}");
        }
    }
}
