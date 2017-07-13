using System.IO;

namespace CsvTest.Export
{
    public class TextExporter
    {
        public void Export(string[] data, string filename)
        {
            using (var stream = File.CreateText(filename))
            {
                foreach (var word in data)
                {
                    stream.WriteLine(word);
                }
            }
        }
    }
}