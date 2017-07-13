using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvTest.Data;

namespace CsvTest.Import
{
    public class CsvImporter
    {
        public WordsCollection Import(string filename)
        {
            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return Read(stream);
            }
        }

        private static WordsCollection Read(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var list = new List<string>();

                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    var splitedWords = line.Split(';', ',');
                    list.AddRange(splitedWords.Select(word => word.Trim()));
                }

                var words = new WordsCollection
                {
                    Words = list.ToArray()
                };

                return words;
            }
        }
    }
}