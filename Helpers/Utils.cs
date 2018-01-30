using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helpers
{
    public class Utils
    {

        /// <summary>
        /// Valida si un email es correcto
        /// </summary>
        /// <param name="email">email</param>
        public static bool emailIsValid(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
                return Regex.Replace(email, expresion, string.Empty).Length == 0;
            else
                return false;
        }
    }
}
