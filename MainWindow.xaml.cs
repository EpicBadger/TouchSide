using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace touchsides
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<WordDetail> wordStats = new List<WordDetail>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                FileNameTextBox.Text = openFileDlg.FileName;

                getAllWords(System.IO.File.ReadAllText(openFileDlg.FileName));
            }
        }

        private void getAllWords(string fileContent)
        {
            char[] splitChars = { ' ', ',', '.', ':', '\t' };
            string[] words = fileContent.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
            
            this.wordStats.Clear();
            this.wordStats = words.GroupBy(word => word).Select(w => new WordDetail(w.Key, WordScoring.getWordScore(w.Key), w.Count())).OrderByDescending(word => word.Occurrences).ToList();
            var temp = wordStats.Select(f => $"{f.Word} - Occurrences:{f.Occurrences}, Score: {f.Score}").ToArray();
            FileContentsTextBox.Text = string.Join('\n', temp);

            var MaxOccurrences = this.wordStats.Max(f => f.Occurrences);
            var Max7CharOccurrences = this.wordStats.Where(wd => wd.Word.Length == 7).Max(f => f.Occurrences);
            var MaxScore = this.wordStats.Max(f => f.Score);

            mostFrequentTB.Text = $"{ String.Join(", ", this.wordStats.Where(wordDetail => wordDetail.Occurrences == MaxOccurrences).Select(f => f.WordTrim())) } \nWith {MaxOccurrences} occurrence(s)";

            mostFrequent7CharTB.Text = $"{ String.Join(", ", this.wordStats.Where(wd => wd.Word.Length == 7 && wd.Occurrences == Max7CharOccurrences).Select(wd => wd.WordTrim())) } \n\nWith {Max7CharOccurrences} occurrence(s)";

            highestScoreTB.Text = $"{ String.Join(", ", this.wordStats.Where(wd => wd.Score == MaxScore).Select(wd => wd.Word.Trim()))} \nWith a word score of {MaxScore}";
        }
    }

    
}
