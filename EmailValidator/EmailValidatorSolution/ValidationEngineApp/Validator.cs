using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationEngineApp
{
    public class Validator
    {
        public bool IsValidEmailAddress(string email)
        {
            string expression = @"^(?("")("".+?(?<!\\)""@)|(([a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[a-z])@))" +
                                       @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([a-z][-\w]*[a-z]*\.)+[a-z][\-a-z]{0,22}[a-z]))$";

            if (String.IsNullOrEmpty(email))
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email, expression);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
