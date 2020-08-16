using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Aising_2020
{
    class D
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
            string x = Read();

            int popCnt = 0;
            for(int i = 0; i < n; i++)
            {
                if (x[i] == '1')
                {
                    popCnt++;
                }
            }

            if (popCnt == 0)
            {
                for(int i = 0; i < n; i++)
                {
                    WriteLine(1);
                }
                return;
            }
            if (popCnt == 1)
            {
                for(int i = 0; i < n; i++)
                {
                    if (x[n - 1] == '1')
                    {
                        if (x[i] == '1')
                        {
                            WriteLine(0);
                        }
                        else
                        {
                            WriteLine(2);
                        }
                    }
                    else
                    {
                        if (i == n - 1)
                        {
                            WriteLine(2);
                        }
                        else if (x[i] == '1')
                        {
                            WriteLine(0);
                        }
                        else
                        {
                            WriteLine(1);
                        }
                    }
                }
                return;
            }

            int[] modsPlus = new int[n];
            int[] modsMinus = new int[n];
            modsPlus[0] = 1 % (popCnt + 1);
            modsMinus[0] = 1 % (popCnt - 1);
            int baseModPlus = 0;
            int baseModMinus = 0;
            if (x[n - 1] == '1')
            {
                baseModPlus += modsPlus[0];
                baseModMinus += modsMinus[0];
            }
            for (int i = 1; i < n; i++)
            {
                modsPlus[i] = (modsPlus[i - 1]*2) % (popCnt + 1);
                modsMinus[i] = (modsMinus[i - 1]*2) % (popCnt - 1);

                if (x[n - 1 - i] == '1')
                {
                    baseModPlus += modsPlus[i];
                    baseModPlus %= popCnt + 1;
                    baseModMinus += modsMinus[i];
                    baseModMinus %= popCnt - 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int mod;
                if (x[i] == '1')
                {
                    mod = baseModMinus + (popCnt - 1 - modsMinus[n - 1 - i]);
                    mod %= popCnt - 1;
                }
                else
                {
                    mod = baseModPlus + modsPlus[n - 1 - i];
                    mod %= popCnt + 1;
                }

                int cnt = 1;
                while (mod > 0)
                {
                    int popCntTmp = 0;
                    int div = 1;
                    while (div <= mod)
                    {
                        if ((mod & div) > 0)
                        {
                            popCntTmp++;
                        }
                        div *= 2;
                    }

                    mod %= popCntTmp;
                    cnt++;
                }

                WriteLine(cnt);
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
