using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAnalysis
{
    public class Chapter
    {

        public int id { get; set; }
        public int chapter_num { get; set; }
        public string title { get; set; }
        public string pov_character { get; set; }
        public string text { get; set; }
        public int words => text.Split(' ').Length;
        public Book book { get; set; }
    }
}
