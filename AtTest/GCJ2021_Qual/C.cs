using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ2021_Qual
{
    class C
    {
        static void ain(string[] args)
        {
            //var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            //SetOut(sw);

            Method(args);

            //Out.Flush();
        }

        static void Method(string[] args)
        {
            int[] tnq = ReadInts();
            int t = tnq[0];
            int n = tnq[1];
            int q = tnq[2];
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                Solve(n);
            }
        }

        static void Solve(int n)
        {
            List<int> numbers = new List<int>();
            WriteLine("1 2 3");
            int med = ReadInt();
            if (med == 1)
            {
                numbers.AddRange(new int[3] { 2, 1, 3 });
            }
            if (med == 2)
            {
                numbers.AddRange(new int[3] { 1, 2, 3 });
            }
            if (med == 3)
            {
                numbers.AddRange(new int[3] { 1, 3, 2 });
            }

            for(int i = 4; i <= n; i++)
            {
                WriteLine($"{numbers[0]} {numbers[numbers.Count-1]} {i}");
                int med2 = ReadInt();
                if (med2 == numbers[0])
                {
                    numbers.Insert(0, i);
                }
                else if (med2 == numbers[numbers.Count - 1])
                {
                    numbers.Add(i);
                }
                else
                {
                    Insert(numbers, 0, numbers.Count - 1, i);
                }
            }

            for(int i = 0; i < n; i++)
            {
                Write(numbers[i] + " ");
            }
            WriteLine();
            Read();
        }

        static void Insert(List<int> list, int leftI, int rightI, int val)
        {
            if (leftI + 1 == rightI)
            {
                list.Insert(rightI, val);
                return;
            }

            int midI = (leftI + rightI) / 2;
            WriteLine($"{list[leftI]} {list[midI]} {val}");
            int med = ReadInt();
            if (med == val)
            {
                Insert(list, leftI, midI, val);
            }
            else
            {
                Insert(list, midI, rightI, val);
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
