using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{
    internal class SpecialChars
    {
        List<char> specialChars = "{}:\",[];'`./~<>?@#№$^&".ToList();
        List<char> latinChars = "qwertyuiopasdfghjklzxcvbnm".ToList();
        List<char> kirilChars = "йцукенгшщзхъфывапролджэячсмитьбюё".ToList();
        private bool ExceptionChar(char excChar)//for special chars like dots, parenthess or math signs
        {
            if (specialChars.Contains(excChar)) 
                return true;
            else
                return false;
        }
        public bool? CountLatinKiril(string inputText)//for counting the amount of l/k chars to choose dictionary
        {
            int Lcount = 0, Kcount = 0;

            foreach (char c in inputText)
            {
                if (!ExceptionChar(c))
                {
                    Lcount += Convert.ToInt32(latinChars.Contains(c));
                    Kcount += Convert.ToInt32(kirilChars.Contains(c));
                }
                else continue;
            }

            if (Lcount == Kcount && Lcount == 0)
                return null;

            return Lcount > Kcount ? true : false;
        }
    }
}
