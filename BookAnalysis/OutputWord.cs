using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAnalysis
{
    class OutputWord
    {

        public OutputWord(WordToMatch word, List<OutputReference> refs )
        {
            Word = word.Word;
            CssClass = word.CssClass;
            DisplayName = word.DisplayName;
            Descriptor = word.Descriptor;
            IsNSFW = word.IsNSFW;
            References = refs;
        }

        public string Word;
        public string CssClass;
        public string DisplayName;
        public string Descriptor;
        public bool IsNSFW;
        public List<OutputReference> References;

    }
}
