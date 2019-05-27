using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_15
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s = Read();
            List<int[]> res = new List<int[]>();
            while (s[0] != '.')
            {
                Calc(s, "0028");
                var cnts = new int[20];
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            for (int l = 0; l < 10; l++)
                            {
                                string now = "";
                                now += (char)(i + '0');
                                now += (char)(j + '0');
                                now += (char)(k + '0');
                                now += (char)(l + '0');
                                cnts[Calc(s, now)]++;
                            }
                        }
                    }
                }

                int val = Calc(s, Read());
                res.Add(new int[2] { val, cnts[val] });
                s = Read();
            }

            for(int i = 0; i < res.Count; i++)
            {
                WriteLine(res[i][0] + " " + res[i][1]);
            }
        }

        static int Calc(string s, string num)
        {
            if (s.Length == 1)
            {
                return num[s[0] - 'a'] - '0';
            }

            char opr = s[1];
            int now = 2;
            int a = 0;
            if (s[now] >= 'a' && s[now] <= 'd')
            {
                a = num[s[now] - 'a'] - '0';
                now++;
            }
            else
            {
                int nest = 0;
                string blockA = "";
                for(;now<s.Length;now++)
                {
                    blockA += s[now];
                    if (s[now] == '[') nest++;
                    else if (s[now] == ']')
                    {
                        nest--;
                        if (nest == 0)
                        {
                            now++;
                            break;
                        }
                    }
                }
                a = Calc(blockA, num);
            }
            int b = 0;
            if (s[now] >= 'a' && s[now] <= 'd')
            {
                b = num[s[now] - 'a'] - '0';
                now++;
            }
            else
            {
                int nest = 0;
                string blockB = "";
                for (; now < s.Length; now++)
                {
                    blockB += s[now];
                    if (s[now] == '[') nest++;
                    else if (s[now] == ']')
                    {
                        nest--;
                        if (nest == 0)
                        {
                            now++;
                            break;
                        }
                    }
                }
                b = Calc(blockB, num);
            }

            int val = 0;
            switch (opr)
            {
                case '+':
                    val = a | b;
                    break;
                case '*':
                    val = a & b;
                    break;
                case '^':
                    val = a ^ b;
                    break;
            }
            return val;
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
