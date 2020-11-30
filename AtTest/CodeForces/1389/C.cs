using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1389
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
                string s = Read();
                int[] cnts = new int[10];
                for(int j = 0; j < s.Length; j++)
                {
                    cnts[s[j] - '0']++;
                }

                int res = int.MaxValue;
                // kisuu
                for(int j = 0; j < 10; j++)
                {
                    res = Min(res, s.Length - cnts[j]);
                }

                // guusuu
                for(int j = 0; j < 10; j++)
                {
                    for(int k = 0; k < 10; k++)
                    {
                        bool jExist = false;
                        int cnt = 0;
                        for (int l = 0; l < s.Length; l++)
                        {
                            int now = s[l] - '0';
                            if (j == now)
                            {
                                if (jExist)
                                {
                                    cnt++;
                                }
                                else
                                {
                                    jExist = true;
                                }
                            }
                            else if (k == now)
                            {
                                if (jExist)
                                {
                                    jExist = false;
                                }
                                else
                                {
                                    cnt++;
                                }
                            }
                            else
                            {
                                cnt++;
                            }
                        }
                        if (jExist)
                        {
                            cnt++;
                        }

                        if (res > cnt)
                        {
                            res = cnt;
                        }
                    }
                }

                WriteLine(res);
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
