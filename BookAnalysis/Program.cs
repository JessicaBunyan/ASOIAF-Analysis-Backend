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

        public static List<WordToMatch> getWordsToMatch()
        {

            List<WordToMatch> words;
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\Tristan\source\repos\BookAnalysis\BookAnalysis\words.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                words  = (List<WordToMatch>)serializer.Deserialize(file, typeof(List<WordToMatch>));
            }

            return words;
        }
    }
}
