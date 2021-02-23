using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            this.initial= content;
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
            StringBuilder sb = new StringBuilder(initial);
            var octaveReverse = input.Contains(OctaveReverse);
            var inter = input.Replace(OctaveReverse, string.Empty);
            foreach (char c in inter)
            {
                char d;
                switch (c)
                {
                    case '<':
                        d = octaveReverse ? '>' : '<';
                        break;
                    case '>':
                        d = octaveReverse ? '<' : '>';
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

        private const string OctaveReverse = "#OCTAVE REVERSE";
    }
}
