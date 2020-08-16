using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_037
{
    class B
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            long n = ReadLong();
            string s = Read();

            long mask = 998244353;
            long[] cnts = new long[8];
            cnts[0] = 1;
            long res = 1;
            for (int i = 0; i < 3 * n; i++)
            {
                if (s[i] == 'R')
                {
                    if (cnts[3] > 0)
                    {
                        res *= cnts[3];
                        cnts[3]--;
                        cnts[3 + 4]++;
                    }
                    else if (cnts[2] > 0)
                    {
                        res *= cnts[2];
                        cnts[2]--;
                        cnts[2 + 4]++;

                    }
                    else if (cnts[1] > 0)
                    {
                        res *= cnts[1];
                        cnts[1]--;
                        cnts[1 + 4]++;
                    }
                    else
                    {
                        res *= cnts[0];
                        cnts[0 + 4]++;
                    }
                }
                if (s[i] == 'G')
                {
                    if (cnts[5] > 0)
                    {
                        res *= cnts[5];
                        cnts[5]--;
                        cnts[5 + 2]++;
                    }
                    else if (cnts[4] > 0)
                    {
                        res *= cnts[4];
                        cnts[4]--;
                        cnts[4 + 2]++;

                    }
                    else if (cnts[1] > 0)
                    {
                        res *= cnts[1];
                        cnts[1]--;
                        cnts[1 + 2]++;
                    }
                    else
                    {
                        res *= cnts[0];
                        cnts[0 + 2]++;
                    }
                }
                if (s[i] == 'B')
                {
                    if (cnts[6] > 0)
                    {
                        res *= cnts[6];
                        cnts[6]--;
                        cnts[6 + 1]++;
                    }
                    else if (cnts[4] > 0)
                    {
                        res *= cnts[4];
                        cnts[4]--;
                        cnts[4 + 1]++;

                    }
                    else if (cnts[2] > 0)
                    {
                        res *= cnts[2];
                        cnts[2]--;
                        cnts[2 + 1]++;
                    }
                    else
                    {
                        res *= cnts[0];
                        cnts[0 + 1]++;
                    }
                }
                res %= mask;
            }

            for(int i = 1; i <= n; i++)
            {
                res *= i;
                res %= mask;
            }
            WriteLine(res);

            /*
            var index = new Dictionary<char, int>();
            index.Add('R', 0);
            index.Add('G', 1);
            index.Add('B', 2);
            long[][] indexes = new long[3][];
            for (int i = 0; i < n; i++) indexes[i] = new long[n];
            int[] nows = new int[3] { 0, 0, 0 };
            for (int i = 0; i < 3 * n; i++)
            {
                int color = index[s[i]];
                indexes[color][nows[color]]++;
                nows[color]++;
            }
            HashSet<long> mins = new HashSet<long>();
            HashSet<long> mids = new HashSet<long>();
            HashSet<long> maxs = new HashSet<long>();
            for (int i = 0; i < n; i++)
            {
                long[] vals = new long[3] {
                    indexes[0][i], indexes[1][i], indexes[2][i] };
                Array.Sort(vals);
                mins.Add(vals[0]);
                mids.Add( vals[1]);
                maxs.Add( vals[2]);
            }
            long res = 1;
            long[] minCnts = new long[3] { 0, 0, 0 };
            long[] maxCnts = new long[3] { 0, 0, 0 };
            for (int i = 0; i < 3 * n; i++)
            {
                if (maxs.Contains(i))
                {
                    maxCnts[index[s[i]]]++;
                }
            }
            for (int i = 0; i < 3 * n; i++)
            {
                if (mins.Contains(i))
                {
                    minCnts[index[s[i]]]++;
                }
                else if (mids.Contains(i))
                {
                    
                }
                else
                {
                    maxCnts[index[s[i]]]--;
                }
            }

            for(long i = 1; i <= n; i++)
            {
                res *= i;
                res %= mask;
            }
            WriteLine(res);
            */
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
