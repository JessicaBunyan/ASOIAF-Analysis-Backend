using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAnalysis
{
    public class OutputChapter
    {
        public int id;
        public int seq;
        public string book;
        public string title;
        public string pov_character;
        public int words;

        public OutputChapter(Chapter c)
        {
            this.id = c.id;
            this.seq = c.chapter_num;
            this.book = c.book.title;
            this.title = c.title;
            this.pov_character = c.pov_character;
            this.words = c.words;

        }
    }
}
