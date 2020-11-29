using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1420
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
            int n = ReadInt();
            int[] array = ReadInts();
            int[] res = new int[n * (n - 1) / 2 + 1];
            res[0] = GetScore(array);

            List<int> blocks = new List<int>();
            // 0を追加
            if (array[0] == 1)
            {
                blocks.Add(0);
            }
            blocks.Add(1);
            for (int i=1;i<n;i++)
            {
                if (array[i - 1] == array[i])
                {
                    blocks[blocks.Count-1]++;
                }
                else
                {
                    blocks.Add(1);
                }
            }

            for(int i = 1; i < blocks.Count; i += 2)
            {

            }

            for(int i = 1; i < res.Length; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (array[j] == 0)
                    {
                        continue;
                    }

                    int left = 0;
                    if (j > 0 && array[j - 1] == 0)
                    {
                        array[j - 1] = 1;
                        array[j] = 0;
                        left = GetScore(array);
                        array[j - 1] = 0;
                        array[j] = 1;
                    }
                    int right = 0;
                    if (j < 1 && array[j + 1] == 0)
                    {
                        array[j + 1] = 1;
                        array[j] = 0;
                        right = GetScore(array);
                        array[j + 1] = 0;
                        array[j] = 1;
                    }
                    if (left > right && left > res[i - 1])
                    {
                        array[j - 1] = 1;
                        array[j] = 0;
                        break;
                    }
                    if (right > left && right > res[i - 1])
                    {
                        array[j + 1] = 1;
                        array[j] = 0;
                        break;
                    }
                }
                res[i] = GetScore(array);
            }

            for(int i = 0; i < res.Length; i++)
            {
                Write(res[i]);
                if (i + 1 < res.Length)
                {
                    Write(" ");
                }
            }
            WriteLine();
        }

        static int GetScore(int[] array)
        {
            int zeros = 0;
            int left = -1;
            int res = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    if (left == -1)
                    {
                        left = i;
                    }
                }
                else
                {
                    if (left >= 0)
                    {
                        res += zeros * (i - left);
                        zeros += i - left;
                        left = -1;
                    }
                }
            }
            if (left >= 0)
            {
                res += zeros * (array.Length - left);
            }

            return res;
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
