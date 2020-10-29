using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Rehabilitation
{
    class Tenka1_2013_QualB_B
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
            long[] ql = ReadLongs();
            int q = (int)ql[0];
            long l = ql[1];
            string[][] queries = new string[q][];
            for(int i = 0; i < q; i++)
            {
                queries[i] = Read().Split();
            }

            long len = 0;
            var stk = new List<(int, int)>();
            for(int i = 0; i < q; i++)
            {
                string[] query = queries[i];
                if (query[0] == "Push")
                {
                    int n = int.Parse(query[1]);
                    int m = int.Parse(query[2]);

                    if (len + n > l)
                    {
                        WriteLine("FULL");
                        return;
                    }

                    stk.Add((n, m));
                    len += n;
                }
                if (query[0] == "Pop")
                {
                    int n = int.Parse(query[1]);

                    if (len < n)
                    {
                        WriteLine("EMPTY");
                        return;
                    }

                    len -= n;
                    int remain = n;
                    while (remain > 0)
                    {
                        int top = stk.Count - 1;
                        if (stk[top].Item1 > remain)
                        {
                            stk[top] = (stk[top].Item1 - remain, stk[top].Item2);
                            remain = 0;
                        }
                        else
                        {
                            remain -= stk[top].Item1;
                            stk.RemoveAt(top);
                        }
                    }
                }
                if (query[0] == "Top")
                {
                    if (len == 0)
                    {
                        WriteLine("EMPTY");
                        return;
                    }

                    WriteLine(stk[stk.Count - 1].Item2);
                }
                if (query[0] == "Size")
                {
                    WriteLine(len);
                }
            }

            WriteLine("SAFE");
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
