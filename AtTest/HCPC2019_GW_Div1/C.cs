using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_GW_Div1
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            List<string> res = new List<string>();
            while (true)
            {
                string jfen = Read();
                if(jfen[0]=='#')break;

                string[] row = jfen.Split('/');
                int[] abcd = ReadInts();
                int a = abcd[0] - 1;
                int b = abcd[1] - 1;
                int c = abcd[2] - 1;
                int d = abcd[3] - 1;

                int now = 0;
                for(int i = 0; i < row[a].Length; i++)
                {
                    if (row[a][i] == 'b') now++;
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
