using System;
using System.Collections.Generic;
using System.Text;

namespace touchsides
{
    public class WordDetail
    {
        public string Word;
        public int Score;
        public int Occurrences;

        public WordDetail(string word, int score, int occurrences)
        {
            this.Word = word;
            this.Score = score;
            this.Occurrences = occurrences;
        }
    }
}
