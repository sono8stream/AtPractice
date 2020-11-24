using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1400
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
                int x = ReadInt();

                string res = "";
                bool ok = true;
                for (int j = 0; j < s.Length; j++)
                {
                    if (j - x >= 0 && j + x < s.Length)
                    {
                        if (s[j - x] == '0' && s[j + x] == '0')
                        {
                            res += '0';
                        }
                        if (s[j - x] == '0' && s[j + x] == '1')
                        {
                            if (j + 2 * x >= s.Length)
                            {
                                ok = false;
                                break;
                            }
                            res += '0';
                        }
                        if (s[j - x] == '1' && s[j + x] == '0')
                        {
                            if (j - 2 * x < 0 || res[j - 2 * x] == '0')
                            {
                                ok = false;
                                break;
                            }
                            res += '0';
                        }
                        if (s[j - x] == '1' && s[j + x] == '1')
                        {
                            res += '1';
                        }
                    }
                    else if (j - x >= 0)
                    {
                        if (s[j - x] == '0')
                        {
                            res += '0';
                        }
                        else
                        {
                            res += '1';
                        }
                    }
                    else if (j + x < s.Length)
                    {
                        if (s[j + x] == '0')
                        {
                            res += '0';
                        }
                        else
                        {
                            res += '1';
                        }
                    }
                    else
                    {
                        res += '0';
                    }
                }

                for(int j = 0; j < s.Length; j++)
                {
                    if (j - x < 0 && j + x >= s.Length && s[j] == '1')
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    WriteLine(res);
                }
                else
                {
                    WriteLine(-1);
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
