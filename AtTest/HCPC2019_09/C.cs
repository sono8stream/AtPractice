using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_09
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s = Read();
            s += ' ';
            var dict = new SortedDictionary<string, bool>();
            bool isName = false;
            string now = "";
            for(int i = 0; i < s.Length; i++)
            {
                if (isName)
                {
                    if(s[i]==' ' || s[i] == '@')
                    {
                        if(now.Length>0
                            && !dict.ContainsKey(now))
                        {
                            dict.Add(now,true);
                        }
                        isName = false;
                    }
                    else
                    {
                        now += s[i];
                    }
                }

                if (s[i]=='@')
                {
                    isName = true;
                    now = "";
                }
            }

            foreach(string key in dict.Keys)
            {
                WriteLine(key);
            }
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
