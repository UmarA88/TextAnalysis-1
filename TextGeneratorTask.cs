using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            int i = 0;

            if (wordsCount > 0)
            {
                while (i < wordsCount)
                {
                    var arrPhB = phraseBeginning.Split(' ');
                    int lenPhr = arrPhB.Length;
                    if (lenPhr >= 2 && nextWords.ContainsKey(arrPhB[lenPhr
                            - 2] + " " + arrPhB[lenPhr - 1]))
                        phraseBeginning = phraseBeginning + " " +
                            nextWords[arrPhB[lenPhr
                            - 2] + " " + arrPhB[lenPhr - 1]];
                    else if (nextWords.ContainsKey(arrPhB[lenPhr - 1]))
                        phraseBeginning = phraseBeginning + " " +
                            nextWords[arrPhB[lenPhr - 1]];
                    else
                        return phraseBeginning;
                    i++;
                }
            }

            return phraseBeginning;
        }
    }
}