using BookAnalysis.Services;
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

        FileService fileService = new FileService();
        ResultsService resultService = new ResultsService();


        static void Main(string[] args)
        {

            new Program().Run();


        }
        public void Run() {

            var allChapters = fileService.Chapters;
            var words = fileService.WordsToMatch;
            
            var cs = new ChapterService(words, allChapters);
            var refList = cs.Analyse();


            var dataJson = resultService.FormatForJSON(refList);

             System.IO.File.WriteAllText(@"C:\Users\Tristan\source\repos\BookAnalysis\BookAnalysis\outputdata.json", dataJson);

            

            Console.ReadLine();




        }

    }
}
