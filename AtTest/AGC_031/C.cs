using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_031
{
    class C
    {
        static void Main(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nab = ReadInts();
            int n = nab[0];
            int a = nab[1];
            int b = nab[2];
            int delta = 0;
            int div = 1;
            for(int i = 0; i < n; i++)
            {
                if ((a & div) != (b & div)) delta++;
                div *= 2;
            }
            if (delta % 2 ==0)
            {
                WriteLine("NO");
                return;
            }
            WriteLine("YES");
            var dict = new Dictionary<int, bool>();
            dict.Add(a,true);
            dict.Add(b,true);
            int all = 1 << n;
            int val = a;
            int[] res = new int[all];
            res[0] = Min(a, b);
            res[all - 1] = Max(a, b);
            int phase = 0;
            if (res[0] == 0) phase = 1;
            for(int i = 1; i < all-1; i++)
            {
                int k = 1;
                for (int j = 0; j < n; j++)
                {
                    bool done = false;
                    switch (phase)
                    {
                        case 0:
                            if ((val & k) == 1 && !dict.ContainsKey(val - k))
                            {
                                val -= k;
                                done = true;
                                if (val == 0)
                                {
                                    if (res[all - 1] == all - 1) phase = 2;
                                    else phase = 1;
                                }
                            }
                            break;
                        case 1:
                            if ((val & k) == 0 && !dict.ContainsKey(val + k))
                            {
                                val += k;
                                done = true;
                                if(val==res)
                            }
                            break;
                    }
                    if (down || (!down&&!top))
                    {
                        if ((val & k) == 1 && !dict.ContainsKey(val - k))
                        {
                            val -= k;
                            break;
                        }
                    }
                    else if(top)
                    {
                        if ((val & k) == 0 && !dict.ContainsKey(val + k))
                        {
                            val += k;
                            break;
                        }
                    }
                    k *= 2;
                }
                res[i] = val;
                dict.Add(val, true);
                if (val == 0) down = false;
            }
            if (b < a) Array.Reverse(res);
            for(int i = 0; i < 1 << n; i++)
            {
                Write(res[i]);
                if (i + 1 < 1 << n) Write(" ");
            }
            WriteLine();
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
