using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            //ReadLine();
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            for (int i = 0; i < t; i++)
            {
                int[] nbf = ReadInts();
                int n = nbf[0];
                int b = nbf[1];
                int f = nbf[2];
                bool[][] nums = new bool[5][];
                bool[][] inputs = new bool[5][];
                int cnt = 32;
                for(int j = 0; j < 5; j++)
                {
                    nums[j] = new bool[n];
                    char[] output = new char[n];
                    for(int k = 0; k < n; k++)
                    {
                        if (k % cnt < cnt / 2)
                        {
                            output[k] = '1';
                            nums[j][k] = true;
                        }
                        else
                        {
                            output[k] = '0';
                            nums[j][k] = false;
                        }
                    }
                    inputs[j] = new bool[n - b];
                    WriteLine(output);
                    string input = Read();
                    for(int k =0; k < n-b; k++)
                    {
                        inputs[j][k] = input[k] == '1';
                    }
                    cnt /= 2;
                }
                int now = 0;
                for(int j = 0; j < n; j++)
                {
                    bool ok = true;
                    if (now < n - b)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (nums[k][j] != inputs[k][now])
                            {
                                ok = false;
                                break;
                            }
                        }
                    }
                    else ok = false;
                    if (ok) now++;
                    else Write(j + " ");
                }
                WriteLine();
                ReadLine();
            }
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
