using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Session_1_LINQ.Classes
{
    internal class WordsComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return x?.ToLower().CompareTo(y?.ToLower()) ?? 0;  
        }
    }
}
