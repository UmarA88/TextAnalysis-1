using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<string> SplitSentences(string sentences)
        {
            List<string> wordsList = new List<string>();

            var words = sentences.Split(new string[] {
                ". ", ": ", "; ", "? ", "! ", "( ", ") ", ".", ",", ":", ";",
                "?", "!", "(", ")", "[", "]", " ", "[", "]", "^", "#", "$",
                "@", "%", "&", "*", "-", "+", "=", "~", "`", "\"", "<", ">",
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "\t",
                "\n", "\r", "“", "”", "—", "…", "‘", "/"
                                                     },
                StringSplitOptions.None);
            foreach (var word in words)
                if (word.Trim() != " " && word.Trim() != "" && word.Trim() != "\n" && word.Trim() != "\t")
                    wordsList.Add(word.TrimEnd().TrimStart().ToLower());

            return wordsList;
        }

        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            string[] sentences = text.Split(new string[] {
                ". ", ": ", "; ", "? ", "! ", "( ", ") ", ".", ":", ";",
                "?", "!", "(", ")"
            },
                StringSplitOptions.None);
            foreach (var sentence in sentences)
            {
                List<string> temp = SplitSentences(sentence);
                if (temp.Capacity != 0)
                    if (sentence.Trim() != " " && sentence.Trim() != ""
                        && sentence.Trim() != "\n" && sentence.Trim() != "\n")
                        sentencesList.Add(temp);
            }

            return sentencesList;
        }
    }
}