using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace touchsides
{
    public static class WordScoring
    {
        public static List<KeyValuePair<char, int>> ScoringMatrix = new List<KeyValuePair<char, int>>()
        {
            new KeyValuePair<char, int>('A', 1),
            new KeyValuePair<char, int>('B', 3),
            new KeyValuePair<char, int>('C', 3),
            new KeyValuePair<char, int>('D', 2),
            new KeyValuePair<char, int>('E', 1),
            new KeyValuePair<char, int>('F', 4),
            new KeyValuePair<char, int>('G', 2),
            new KeyValuePair<char, int>('H', 4),
            new KeyValuePair<char, int>('I', 1),
            new KeyValuePair<char, int>('J', 8),
            new KeyValuePair<char, int>('K', 5),
            new KeyValuePair<char, int>('L', 1),
            new KeyValuePair<char, int>('M', 3),
            new KeyValuePair<char, int>('N', 1),
            new KeyValuePair<char, int>('O', 1),
            new KeyValuePair<char, int>('P', 3),
            new KeyValuePair<char, int>('Q', 10),
            new KeyValuePair<char, int>('R', 1),
            new KeyValuePair<char, int>('S', 1),
            new KeyValuePair<char, int>('T', 1),
            new KeyValuePair<char, int>('U', 1),
            new KeyValuePair<char, int>('V', 4),
            new KeyValuePair<char, int>('W', 4),
            new KeyValuePair<char, int>('X', 8),
            new KeyValuePair<char, int>('Y', 4),
            new KeyValuePair<char, int>('Z', 10),
        };

        public static int getWordScore(string word)
        {
            int wordScore = 0;

            foreach (var letter in word)
            {
                wordScore += WordScoring.ScoringMatrix.FirstOrDefault(ml => ml.Key.ToString().ToLower() == letter.ToString().ToLower()).Value;
            }

            return wordScore;
        }
    }
}
