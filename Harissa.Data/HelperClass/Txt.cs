using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Harissa.Data.HelperClass
{
    public class Txt
    {
        public static string TxtToLink(string txt)
        {
            string pattern = @"";
            Regex reg = new Regex(pattern);
                txt.Replace(txt, "<a href=\"" + txt + "\" target=\"_blank\" >" + txt + "</a>");

            return txt;
        }

    }
}
