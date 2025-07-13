using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
{
    HashSet<string> wordSet = new HashSet<string>(words);
    List<string> result = new List<string>();

    foreach (string word in words)
    {
        string reversed = new string(word.Reverse().ToArray());

        // Skip same-letter words like "aa"
        if (word[0] == word[1]) continue;

        // Check if reverse exists and hasn't already been used
        if (wordSet.Contains(reversed))
        {
            result.Add($"{word} & {reversed}");

            // Remove both to avoid duplicate matching
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

        // Check for at least 4 columns
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


    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
   public static bool IsAnagram(string word1, string word2)
{
    // Normalize input: remove spaces and convert to lowercase
    word1 = word1.Replace(" ", "").ToLower();
    word2 = word2.Replace(" ", "").ToLower();

    if (word1.Length != word2.Length)
        return false;

    // Count letters in word1
    var letterCount = new Dictionary<char, int>();

    foreach (char c in word1)
    {
        if (letterCount.ContainsKey(c))
            letterCount[c]++;
        else
            letterCount[c] = 1;
    }

    // Subtract letter counts using word2
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