using System;
using System.Collections.Generic;
using System.Text;

namespace CLR_HW_Project
{
    public static class StringFormatHelper
    {
        public static string RemoveLastSeparator(StringBuilder str, int sepLen)
        {
            return str.Remove(str.Length - sepLen, sepLen).ToString();
        }
    }
}
