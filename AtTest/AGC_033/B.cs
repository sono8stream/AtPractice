using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_033
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] hwn = ReadInts();
            int h = hwn[0];
            int w = hwn[1];
            int n = hwn[2];
            int[] spos = ReadInts();
            string s = Read();
            string t = Read();

            int x = spos[1];
            for(int i = 0; i < n; i++)
            {
                if (s[i] == 'R') x++;
                if (x > w)
                {
                    WriteLine("NO");
                    return;
                }
                if (x > 1 && t[i] == 'L') x--;
            }
            x = spos[1];
            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'L') x--;
                if (x < 1)
                {
                    WriteLine("NO");
                    return;
                }
                if (x < h && t[i] == 'R') x++;
            }

            int y = spos[0];
            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'D') y++;
                if (y>h)
                {
                    WriteLine("NO");
                    return;
                }
                if (y > 1 && t[i] == 'U') y--;
            }
            y = spos[0];
            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'U') y--;
                if (y < 1)
                {
                    WriteLine("NO");
                    return;
                }
                if (y < h && t[i] == 'D') y++;
            }

            WriteLine("YES");
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
