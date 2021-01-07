using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1348
{
    class C
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int[] nk = ReadInts();
                int n = nk[0];
                int k = nk[1];
                int[] cnts = new int[26];
                string s = Read();
                int lastIdx = 0;
                for(int j = 0; j < n; j++)
                {
                    cnts[s[j] - 'a']++;
                    lastIdx = Max(lastIdx, s[j] - 'a');
                }

                int firstLast = 0;
                int used = 0;
                int firstFirst = 30;
                int idx = 0;
                while (used < k)
                {
                    if (cnts[idx] == 0)
                    {
                        idx++;
                        continue;
                    }
                    else
                    {
                        cnts[idx]--;
                        firstFirst = Min(firstFirst, idx);
                        used++;
                        firstLast = Max(firstLast, idx);
                    }
                }

                if (firstFirst == firstLast)
                {
                    string res = "";
                    res += (char)(firstFirst + 'a');
                    while (idx < 26 && cnts[idx] == 0)
                    {
                        idx++;
                    }
                    if (idx == lastIdx)
                    {
                        int cnt = cnts[idx] / k;
                        if (cnts[idx] % k > 0)
                        {
                            cnt++;
                        }
                        for(int j = 0; j < cnt; j++)
                        {
                            res += (char)(idx + 'a');
                        }
                    }
                    else
                    {
                        for (; idx < 26; idx++)
                        {
                            for (int j = 0; j < cnts[idx]; j++)
                            {
                                res += (char)(idx + 'a');
                            }
                        }
                    }
                    WriteLine(res);
                }
                else
                {
                    WriteLine((char)(firstLast + 'a'));
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
