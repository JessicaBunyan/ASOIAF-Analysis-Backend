﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAnalysis
{
    class ResultsService
    {
        public void Output(List<List<Reference>> results)
        {

            foreach(var wordRefs in results)
            {

                Print("==================================");
                Print("WORD: " +wordRefs.FirstOrDefault()?.Word);
                Print("==================================");


                var res2 = wordRefs.GroupBy(r => r.Chapter.pov_character).Select(x => new
                {
                    character = x.Key,
                    count = x.Count()
                }

                ).OrderBy(c => c.count); // kinda messy think i want a new type here

                foreach (var r in res2)
                {
                    Print(r.character + " : " + r.count);
                }

            }
        }

        public void FormatForJSON(List<List<Reference>> results)
        {
            var dict = new Dictionary<string, List<OutputReference>>();
            
            foreach (var wordRefs in results)
            {
                var refsForThisWord = wordRefs.Select(r => new OutputReference()
                {
                    book = r.Chapter.book.title,
                    chapter = r.Chapter.title,
                    cid = r.Chapter.id,
                    pov = r.Chapter.pov_character

                });
                if (wordRefs.Count > 0)
                {

                dict.Add(wordRefs.FirstOrDefault()?.Word.Word, refsForThisWord.ToList());
                }
            }
            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);


            return;


        }

        public void Print(string s)
        {
            Console.WriteLine(s);
        }

    }
}