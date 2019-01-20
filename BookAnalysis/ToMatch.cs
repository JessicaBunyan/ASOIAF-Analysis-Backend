namespace BookAnalysis
{
    public class ToMatch
    {
        public ToMatch(string w)
        {
            Word = w;
            Regex = w;
        }
        public ToMatch(string w, string r)
        {
            Word = w;
            Regex = r;
        }
        public string Word;
        public string Regex;
    }
}