using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvTest.Data
{
    public class WordsCollection
    {
        public string[] Words { get; set; }

        public List<Anagram> GetAnagrams()
        {
            if (Words == null || !Words.Any())
            {
                return new List<Anagram>();
            }

            var dictionary = new Dictionary<string, List<string>>();
            foreach (var word in Words)
            {
                var wordChars = word.ToCharArray();
                Array.Sort(wordChars);
                var sortedWord = new string(wordChars);

                if (dictionary.ContainsKey(sortedWord))
                {
                    dictionary[sortedWord].Add(word);
                }
                else
                {
                    dictionary.Add(sortedWord, new List<string>
                    {
                        word
                    });
                }
            }

            var anagrams = new List<Anagram>();
            dictionary.Where(w => w.Value.Count > 1)
                      .Select(w => w.Value)
                      .ToList()
                      .ForEach(w => anagrams.Add(new Anagram(w.ToArray())));

            return anagrams;
        }













        public static Dictionary<string, System.Collections.Generic.List<string>> GetAnagramEquivalents(System.Collections.Generic.List<string> InputArray)
        {
            Dictionary<string, System.Collections.Generic.List<string>> ReturnList = new Dictionary<string, System.Collections.Generic.List<string>>();
            for (int x = 0; x < InputArray.Count; ++x)
            {
                char[] InputCharArray = InputArray[x].ToCharArray();
                Array.Sort(InputCharArray);
                string InputString = new string(InputCharArray);
                if (ReturnList.ContainsKey(InputString))
                {
                    ReturnList[InputString].Add(InputArray[x]);
                }
                else
                {
                    ReturnList.Add(InputString, new System.Collections.Generic.List<string>());
                    ReturnList[InputString].Add(InputArray[x]);
                }
            }

            var tst = ReturnList.Where(x => x.Value.Count > 1);
            return ReturnList;
        }
    }
}