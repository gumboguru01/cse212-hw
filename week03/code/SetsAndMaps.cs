using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> wordSet = new HashSet<string>(words);
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            string reversed = new string(word.Reverse().ToArray());

            if (word[0] == word[1]) continue;

            if (wordSet.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
                wordSet.Remove(word);
                wordSet.Remove(reversed);
            }
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();

                if (!string.IsNullOrEmpty(degree))
                {
                    if (degrees.ContainsKey(degree))
                        degrees[degree]++;
                    else
                        degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var letterCount = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (letterCount.ContainsKey(c))
                letterCount[c]++;
            else
                letterCount[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!letterCount.ContainsKey(c))
                return false;

            letterCount[c]--;

            if (letterCount[c] < 0)
                return false;
        }

        return true;
    }

    public static (int, int) MoveLeft((int x, int y) current, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (maze.TryGetValue(current, out var directions) && directions.left)
        {
            return (current.x - 1, current.y);
        }
        return current;
    }

    public static (int, int) MoveRight((int x, int y) current, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (maze.TryGetValue(current, out var directions) && directions.right)
        {
            return (current.x + 1, current.y);
        }
        return current;
    }

    public static (int, int) MoveUp((int x, int y) current, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (maze.TryGetValue(current, out var directions) && directions.up)
        {
            return (current.x, current.y - 1);
        }
        return current;
    }

    public static (int, int) MoveDown((int x, int y) current, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (maze.TryGetValue(current, out var directions) && directions.down)
        {
            return (current.x, current.y + 1);
        }
        return current;
    }
}
