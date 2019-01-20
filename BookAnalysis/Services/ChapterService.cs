using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookAnalysis
{
    class ChapterService
    {
        private List<WordToMatch> searchWords;
        private List<List<Reference>> references= new List<List<Reference>>();
        private List<Chapter> chapters;

        public ChapterService(List<WordToMatch> words, List<Chapter> chapters)
        {
            searchWords = words;
            this.chapters = chapters;
        }

        


        public List<List<Reference>> Analyse()
        {

            foreach(var w in searchWords)
            {

            var refsForThisWord = new List<Reference>();

                foreach(Chapter c in chapters)
                {
                    CheckChapter(c, w, refsForThisWord);
                }

                references.Add(refsForThisWord);
            }

            return references;
        }

        private void CheckChapter(Chapter chapter, WordToMatch word,  List<Reference> refList)
        {
  

            var rgx = new Regex(@"\b" + word.Regex + @"\b", RegexOptions.IgnoreCase); // needs testing 
                foreach (Match match in rgx.Matches(chapter.text)) // willl this only match whole words?
                {
                    refList.Add(new Reference()
                    {
                        Word = word,
                        Chapter = chapter
                    });
                }

            }
        


    }
}
