using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._600_Div2
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
            int n = ReadInt();
            int[] array = ReadInts();

            var used = new HashSet<int>();
            var exist = new HashSet<int>();
            List<int> cnts = new List<int>();
            int tmp = 0;
            for(int i = 0; i < n; i++)
            {
                if (array[i] > 0)
                {
                    if (used.Contains(array[i]))
                    {
                        WriteLine(-1);
                        return;
                    }
                    else
                    {
                        used.Add(array[i]);
                        exist.Add(array[i]);
                        tmp++;
                    }
                }
                else
                {
                    if (exist.Contains(-array[i]))
                    {
                        exist.Remove(-array[i]);
                        tmp++;
                    }
                    else
                    {
                        WriteLine(-1);
                        return;
                    }
                }

                if (exist.Count == 0)
                {
                    cnts.Add(tmp);
                    tmp = 0;
                    used = new HashSet<int>();
                }
            }
            if (exist.Count > 0)
            {
                WriteLine(-1);
                return;
            }

            WriteLine(cnts.Count);
            for(int i=0;i<cnts.Count; i++)
            {
                Write(cnts[i]);
                if (i + 1 < cnts.Count)
                {
                    Write(" ");
                }
            }
            WriteLine();
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
