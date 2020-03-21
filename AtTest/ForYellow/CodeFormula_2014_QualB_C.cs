using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CodeFormula_2014_QualB_C
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
            string a = Read();
            string b = Read();

            List<char[]> diffs = new List<char[]>();
            int[] aCnts = new int[26];
            int[] bCnts = new int[26];
            for (int i = 0; i < a.Length; i++)
            {
                aCnts[a[i] - 'a']++;
                bCnts[b[i] - 'a']++;
                if (a[i] != b[i])
                {
                    diffs.Add(new char[2] { a[i], b[i] });
                }
            }

            for (int i = 0; i < 26; i++)
            {
                if (aCnts[i] != bCnts[i])
                {
                    WriteLine("NO");
                    return;
                }
            }
            bool doubled = aCnts.Where(val => val > 1).Any();

            if (diffs.Count > 6)
            {
                WriteLine("NO");
                return;
            }

            if (doubled)
            {
                diffs.Add(new char[2] { 'a', 'a' });
                diffs.Add(new char[2] { 'a', 'a' });
            }

            for (int i1 = 0; i1 < diffs.Count; i1++)
            {
                for (int i2 = i1 + 1; i2 < diffs.Count; i2++)
                {
                    for (int i3 = 0; i3 < diffs.Count; i3++)
                    {
                        for (int i4 = i3 + 1; i4 < diffs.Count; i4++)
                        {
                            for (int i5 = 0; i5 < diffs.Count; i5++)
                            {
                                for (int i6 = i5 + 1; i6 < diffs.Count; i6++)
                                {
                                    char[] tmp = new char[diffs.Count];
                                    for (int i = 0; i < diffs.Count; i++)
                                    {
                                        tmp[i] = diffs[i][1];
                                    }
                                    Swap(tmp, i1, i2);
                                    Swap(tmp, i3, i4);
                                    Swap(tmp, i5, i6);

                                    bool can = true;
                                    for(int i = 0; i < diffs.Count; i++)
                                    {
                                        if (tmp[i] != diffs[i][0])
                                        {
                                            can = false;
                                            break;
                                        }
                                    }

                                    if (can)
                                    {
                                        WriteLine("YES");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            WriteLine("NO");
        }

        static void Swap(char[] target, int i1,int i2)
        {
            char tmp = target[i1];
            target[i1] = target[i2];
            target[i2] = tmp;
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
