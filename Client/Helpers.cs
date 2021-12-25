using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JobJournal.Client
{
    public static class Helpers
    {
        public static string GetTelephoneDigits(string phoneNumber)
        {
            // Source: https://kaliko.com/blog/c-remove-all-non-numeric-characters/
            return Regex.Replace(phoneNumber, "[^.0-9]", "");
        }
    }
}
