namespace CsvTest.Data
{
    public struct Anagram
    {
        public Anagram(string[] anagrams)
        {
            Anagrams = anagrams;
        }

        public string[] Anagrams { get; set; }
        public int Length => Anagrams != null && Anagrams.Length > 0 ? Anagrams[0].Length : 0;
    }
}