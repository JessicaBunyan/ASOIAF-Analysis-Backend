using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {

            var text = File.ReadAllText(@"C:\Users\Tristan\GoT anaysis\chapters.json");
            var books = JsonConvert.DeserializeObject<BookCollection>(text);

            books.books.ForEach(b => b.chapters.ForEach(c => c.book = b)); // set book ref.

            var allChapters = new List<Chapter>();
            books.books.ForEach(b => allChapters.AddRange(b.chapters));

            allChapters.ForEach(c => Console.WriteLine(c.words));







            var words = getWordsToMatch();
            
            var cs = new ChapterService(words, allChapters);
            var refList = cs.Analyse();

            Console.WriteLine(refList.Count);

            var resultService = new ResultsService();
            resultService.Output(refList);
            resultService.FormatForJSON(refList);

            

            Console.ReadLine();




        }

        public static List<ToMatch> getWordsToMatch()
        {
            var words = new List<ToMatch>();
            words.Add(new ToMatch("ice"));
            words.Add(new ToMatch("bastard"));
            words.Add(new ToMatch("fire"));
            words.Add(new ToMatch("blood"));
            words.Add(new ToMatch("dragon", "dragons?"));
            words.Add(new ToMatch("weirwood", "weirwoods?"));
            words.Add(new ToMatch("star", "stars?"));
            words.Add(new ToMatch("ruby", "rub(y|ies)"));
            words.Add(new ToMatch("words are wind"));
            words.Add(new ToMatch("king", "kings?"));
            words.Add(new ToMatch("if I look back, I am lost", "if i look back,? i am lost"));
            words.Add(new ToMatch("fuck", "fuc(k|king|ked|ks)"));
            words.Add(new ToMatch("winter", "winters?"));
            words.Add(new ToMatch("magic"));
            words.Add(new ToMatch("skinchanger", "skinchangers?"));
            words.Add(new ToMatch("the Wall"));
            words.Add(new ToMatch("winter is coming"));
            words.Add(new ToMatch("prince", "princes?"));
            words.Add(new ToMatch("fire and Blood"));
            words.Add(new ToMatch("stark", "starks?"));
            words.Add(new ToMatch("lannister", "lannisters?"));
            words.Add(new ToMatch("north"));
            words.Add(new ToMatch("nipple", "nipples?"));
            words.Add(new ToMatch("king's blood", "king(’|')s blood"));
            words.Add(new ToMatch("queen", "queens?"));
            words.Add(new ToMatch("it is known"));
            words.Add(new ToMatch("sword", "swords?"));
            words.Add(new ToMatch("fear"));
            words.Add(new ToMatch("r’hllor", "R('|’)hllor"));
            words.Add(new ToMatch("promise", "promis(e|ed|es|)"));
            words.Add(new ToMatch("sea", "seas?"));
            words.Add(new ToMatch("gold"));
            words.Add(new ToMatch("raven", "ravens?"));
            words.Add(new ToMatch("targaryen", "targaryens?"));
            words.Add(new ToMatch("boiled leather"));
            words.Add(new ToMatch("seven"));
            words.Add(new ToMatch("mummer's farce", "mummer('|’)s farce"));
            words.Add(new ToMatch("stone"));
            words.Add(new ToMatch("cunt", "cunt"));
            words.Add(new ToMatch("snow", "sno(w|ws|wing|wed|wy)"));
            words.Add(new ToMatch("wine"));
            words.Add(new ToMatch("the north remembers"));
            words.Add(new ToMatch("hodor"));
            words.Add(new ToMatch("you know nothing"));
            words.Add(new ToMatch("teat", "teats?"));
            words.Add(new ToMatch("moonboy"));
            words.Add(new ToMatch("shit", "sh(i|a)t(ting)?"));
            words.Add(new ToMatch("Valar Morghulis"));
            words.Add(new ToMatch("dark wings, dark words"));
            words.Add(new ToMatch("egg, eggs?"));

            return words;
        }
    }
}
