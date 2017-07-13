using System;
using System.IO;
using CsvTest.Data;

namespace CsvTest.Import
{
    public class ImportService
    {
        private static ImportService _instance;

        public static ImportService Instance => _instance ?? (_instance = new ImportService());

        public WordsCollection Import(string filename)
        {
            var extension = Path.GetExtension(filename);
            if (extension != null && extension.ToLower() == ".csv")
            {
                var csvImporter = new CsvImporter();
                return csvImporter.Import(filename);
            }
            else
            {
                throw new ArgumentException("Not supported format");
            }
        }
    }
}
