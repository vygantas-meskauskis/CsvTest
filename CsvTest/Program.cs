using System;
using System.Linq;
using CsvTest.Export;
using CsvTest.Import;

namespace CsvTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length < 1)
                {
                    throw new ArgumentException("Arguments not found");
                }
                var fileName = args.Length > 1 ? args[1] : "CsvText.txt";

                var words = ImportService.Instance.Import(args[0]);
                var anagrams = words.GetAnagrams()
                    .OrderBy(w => w.Length)
                    .SelectMany(a => a.Anagrams)
                    .ToArray();

                ExportService.Instance.Export(anagrams, fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
