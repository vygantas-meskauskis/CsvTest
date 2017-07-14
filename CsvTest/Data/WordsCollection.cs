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
    }
}
