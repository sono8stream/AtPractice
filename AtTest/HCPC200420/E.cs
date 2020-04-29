using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC200420
{
    class E
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
            while (true)
            {
                int[] abc = ReadInts();
                int a = abc[0];
                int b = abc[1];
                int c = abc[2];
                if (a == 0)
                {
                    break;
                }

                int n = ReadInt();
                int[][] checks = new int[n][];
                for(int i = 0; i < n; i++)
                {
                    checks[i] = ReadInts();
                }

                int[] status = new int[a+b+c];
                for (int i = 0; i < a + b + c; i++)
                {
                    status[i] = -1;
                }
                while (true)
                {
                    int confirm = 0;
                    for (int i = 0; i < n; i++)
                    {
                        int aI = checks[i][0] - 1;
                        int bI = checks[i][1] - 1;
                        int cI = checks[i][2] - 1;
                        if (checks[i][3] == 1)
                        {
                            if (status[aI] == -1)
                            {
                                status[aI] = 1;
                                confirm++;
                            }
                            if (status[bI] == -1)
                            {
                                status[bI] = 1;
                                confirm++;
                            }
                            if (status[cI] == -1)
                            {
                                status[cI] = 1;
                                confirm++;
                            }
                        }
                        else
                        {
                            if (status[aI] == -1 &&
                                status[bI] == 1 &&
                                status[cI] == 1)
                            {
                                status[aI] = 0;
                                confirm++;
                            }
                            if (status[aI] == 1 &&
                                status[bI] == -1 &&
                                status[cI] == 1)
                            {
                                status[bI] = 0;
                                confirm++;
                            }
                            if (status[aI] == 1 &&
                                status[bI] == 1 &&
                                status[cI] == -1)
                            {
                                status[cI] = 0;
                                confirm++;
                            }
                        }
                    }

                    if (confirm == 0)
                    {
                        break;
                    }
                }

                for(int i = 0; i < a + b + c; i++)
                {
                    if (status[i] == -1)
                    {
                        WriteLine(2);
                    }
                    else
                    {
                        WriteLine(status[i]);
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
