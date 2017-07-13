using System;
using System.IO;

namespace CsvTest.Export
{
    public class ExportService
    {
        private static ExportService _instance;

        public static ExportService Instance => _instance ?? (_instance = new ExportService());

        public void Export(string[] data, string filename)
        {
            var extension = Path.GetExtension(filename);
            if (extension != null && extension.ToLower() == ".txt")
            {
                var textExporter = new TextExporter();

                if (File.Exists(filename))
                {
                    filename = ChangeFileName(filename, extension);
                }
                textExporter.Export(data, filename);
            }
            else
            {
                throw new ArgumentException("Unsupported output format.");
            }
        }

        private static string ChangeFileName(string filename, string extension)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
            var directoryName = Path.GetDirectoryName(filename);

            var i = 0;
            while (true)
            {
                var newName = string.IsNullOrEmpty(directoryName) ? 
                              string.Format(fileNameWithoutExtension + " ({0}){1}", i, extension) : 
                              string.Format(directoryName + "\\" + fileNameWithoutExtension + " ({0}){1}", i, extension);

                if (!File.Exists(newName))
                {
                    return newName;
                }
                i++;
            }
        }
    }
}