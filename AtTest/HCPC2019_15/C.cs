using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_15
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s1=Read();
            string s2;
            List<int> res = new List<int>();
            while (s1[0] != '.')
            {
                s2 = Read();
                string[] s1s = s1.Split('\"');
                string[] s2s = s2.Split('\"');
                if (s1s.Length != s2s.Length)
                {
                    res.Add(2);
                }
                else
                {
                    int comDifCnt = 0;
                    int litelDifCnt = 0;
                    for(int i =0; i < s1s.Length; i++)
                    {
                        if (!s1s[i].Equals(s2s[i]))
                        {
                            if (i % 2 == 0) comDifCnt++;
                            else litelDifCnt++;
                        }
                    }

                    if (comDifCnt == 0 && litelDifCnt == 0) res.Add(0);
                    else if (comDifCnt == 0 && litelDifCnt == 1) res.Add(1);
                    else res.Add(2);
                }
                s1 = Read();
            }


            for(int i =0; i < res.Count; i++)
            {
                switch (res[i])
                {
                    case 0:
                        WriteLine("IDENTICAL");
                        break;
                    case 1:
                        WriteLine("CLOSE");
                        break;
                    case 2:
                        WriteLine("DIFFERENT");
                        break;
                }
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
