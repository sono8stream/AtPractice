using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1407
{
    class A
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
                int n = ReadInt();
                int[] array = ReadInts();
                int ones = 0;
                for(int j = 0; j < n; j++)
                {
                    if (array[j] == 1)
                    {
                        ones++;
                    }
                }

                if (ones <= n / 2)
                {
                    WriteLine(n-ones);
                    for(int j = 0; j < n - ones; j++)
                    {
                        Write(0);
                        if (j + 1 < n - ones)
                        {
                            Write(" ");
                        }
                    }
                }
                else
                {
                    if (ones % 2 == 1)
                    {
                        WriteLine(ones - 1);
                        for (int j = 0; j < ones - 1; j++)
                        {
                            Write(1);
                            if (j + 1 < ones - 1)
                            {
                                Write(" ");
                            }
                        }
                    }
                    else
                    {
                        WriteLine(ones);
                        for (int j = 0; j < ones; j++)
                        {
                            Write(1);
                            if (j + 1 < ones)
                            {
                                Write(" ");
                            }
                        }
                    }
                }
                WriteLine();
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
