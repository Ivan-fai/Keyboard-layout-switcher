using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{
    internal class LanguageDetector
    {
        HashSet<char> latinChars = "qwertyuiopasdfghjklzxcvbnm".ToHashSet();
        HashSet<char> kirilChars = "йцукенгшщзхъфывапролджэячсмитьбюё".ToHashSet();
        public bool? CountLatinKiril(string inputText)//for counting the amount of l/k chars to choose dictionary
        {
            int Lcount = 0, Kcount = 0;

            foreach (char c in inputText)
            {
                char lower = char.ToLower(c);
                if (latinChars.Contains(lower)) Lcount++;
                else if (kirilChars.Contains(lower)) Kcount++;
                else continue;
            }

            if (Lcount == Kcount && Lcount == 0)
                return null;

            return Lcount > Kcount ? true : false;
        }
    }
}
