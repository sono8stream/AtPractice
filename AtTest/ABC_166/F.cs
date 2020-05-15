using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_166
{
    class F
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
            int[] nabc = ReadInts();
            int n = nabc[0];
            long a = nabc[1];
            long b = nabc[2];
            long c = nabc[3];
            string[] ss = new string[n];
            for(int i = 0; i < n; i++)
            {
                ss[i] = Read();
            }
            if (a == 0 && b == 0 && c == 0)
            {
                WriteLine("No");
                return;
            }
            if (ss[0] == "AB" && a == 0 && b == 0)
            {
                WriteLine("No");
                return;
            }
            if (ss[0] == "AC" && a == 0 && c == 0)
            {
                WriteLine("No");
                return;
            }
            if (ss[0] == "BC" && b == 0 && c == 0)
            {
                WriteLine("No");
                return;
            }

            long sum = a + b + c;
            if (sum == 1)
            {
                int pos = 0;
                if (b > 0)
                {
                    pos = 1;
                }
                if (c > 0)
                {
                    pos = 2;
                }
                char[] res = new char[n];

                for (int i = 0; i < n; i++)
                {
                    if (ss[i] == "AB")
                    {
                        if (pos == 2)
                        {
                            WriteLine("No");
                            return;
                        }
                        if (pos == 0)
                        {
                            pos = 1;
                            res[i] = 'B';
                        }
                        else
                        {
                            pos = 0;
                            res[i] = 'A';
                        }
                    }
                    if (ss[i] == "AC")
                    {
                        if (pos == 1)
                        {
                            WriteLine("No");
                            return;
                        }
                        if (pos == 0)
                        {
                            pos = 2;
                            res[i] = 'C';
                        }
                        else
                        {
                            pos = 0;
                            res[i] = 'A';
                        }
                    }
                    if (ss[i] == "BC")
                    {
                        if (pos == 0)
                        {
                            WriteLine("No");
                            return;
                        }
                        if (pos == 1)
                        {
                            pos = 2;
                            res[i] = 'C';
                        }
                        else
                        {
                            pos = 1;
                            res[i] = 'B';
                        }
                    }
                }

                WriteLine("Yes");
                for (int i = 0; i < n; i++)
                {
                    WriteLine(res[i]);
                }
            }
            else
            {
                WriteLine("Yes");
                for (int i = 0; i < n; i++)
                {
                    if (ss[i] == "AB")
                    {
                        if (a == 0||
                            (a == 1&&b>0 && i + 1 < n && ss[i + 1] == "AC"))
                        {
                            WriteLine("A");
                            a++;
                            b--;
                        }
                        else
                        {
                            WriteLine("B");
                            a--;
                            b++;
                        }
                    }
                    if (ss[i] == "AC")
                    {
                        if (a == 0 ||
                            (a == 1 && c > 0 && i + 1 < n && ss[i + 1] == "AB"))
                        {
                            WriteLine("A");
                            a++;
                            c--;
                        }
                        else
                        {
                            WriteLine("C");
                            a--;
                            c++;
                        }
                    }
                    if (ss[i] == "BC")
                    {
                        if (b == 0 ||
                            (b == 1 && c > 0 && i + 1 < n && ss[i + 1] == "AB"))
                        {
                            WriteLine("B");
                            b++;
                            c--;
                        }
                        else
                        {
                            WriteLine("C");
                            b--;
                            c++;
                        }
                    }
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
