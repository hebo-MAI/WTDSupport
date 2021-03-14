using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WTDSupport
{
    /// <summary>
    /// MML Reader class.
    /// </summary>
    public class MMLReader
    {
        public MMLReader(StreamReader sr)
        {
            initial = sr.ReadToEnd();
        }

        public MMLReader(string content)
        {
            this.initial = content;
        }

        public string GetMMLString()
        {
            if (!cached)
            {
                intermediate = Compile(initial);
                cached = true;
            }

            return intermediate;
        }

        private string Compile(string input)
        {
            var sb = new StringBuilder();
            var reverse = input.Contains(Reverse);
            var inter = input.Replace(Reverse, string.Empty)
                .Replace("@lfo", "m");
            inter = Regex.Replace(inter, "/\\*[\\s\\S]*\\*/", "");
            inter = Regex.Replace(inter, "//[^\r\n]*(\r\n|[\r\n])?", "$1");
            foreach (char c in inter)
            {
                char d;
                switch (c)
                {
                    case '<':
                        d = reverse ? '>' : '<';
                        break;
                    case '>':
                        d = reverse ? '<' : '>';
                        break;
                    case '(':
                        d = reverse ? ')' : '(';
                        break;
                    case ')':
                        d = reverse ? '(' : ')';
                        break;
                    default:
                        d = c;
                        break;
                }

                sb.Append(d);
            }

            return sb.ToString();
        }

        private string initial;
        private string intermediate;
        private bool cached;

        private const string Reverse = "#REVERSE";
    }
}
