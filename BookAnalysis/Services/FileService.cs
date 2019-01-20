using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAnalysis.Services
{
    public class FileService
    {

        const string chaptersFile = @"C:\Users\Tristan\GoT anaysis\chapters.json";



        private BookCollection _books;
        private List<Chapter> _chapters;
        private List<WordToMatch> _wordsToMatch;

        public BookCollection Books
        {
            get
            {
                if (_books == null)
                {
                    _books = GetBooks();
                }

                return _books;

            }
        }

        public List<Chapter> Chapters
        {
            get
            {
                if (_chapters == null)
                {
                    _chapters = GetChapters();
                }

                return _chapters;

            }
        }

        public List<WordToMatch> WordsToMatch
        {
            get
            {
                if (_wordsToMatch == null)
                {
                    _wordsToMatch= GetWordsToMatch();
                }

                return _wordsToMatch;

            }
        }

        private BookCollection GetBooks()
        {
            var text = File.ReadAllText(chaptersFile);

            var books = JsonConvert.DeserializeObject<BookCollection>(text);

            books.books.ForEach(b => b.chapters.ForEach(c => c.book = b)); // set book ref.

            return books;
        }

        private List<Chapter> GetChapters()
        {
            var books = GetBooks();

            var allChapters = new List<Chapter>();


            books.books.ForEach(b => allChapters.AddRange(b.chapters));

            return allChapters;
        }

        private List<WordToMatch> GetWordsToMatch()
        {

            List<WordToMatch> words;
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\Tristan\source\repos\BookAnalysis\BookAnalysis\words.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                words = (List<WordToMatch>)serializer.Deserialize(file, typeof(List<WordToMatch>));
            }

            return words;
        }
    }
}
