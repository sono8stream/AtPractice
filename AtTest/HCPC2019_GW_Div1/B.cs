using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_GW_Div1
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            List<Seed[]> res = new List<Seed[]>();
            while (true)
            {
                int n = ReadInt();
                if (n == 0) break;

                res.Add(new Seed[n]);
                for(int i = 0; i < n; i++)
                {
                    string[] input = Read().Split();
                    int p = int.Parse(input[1]);
                    int a = int.Parse(input[2]);
                    int b = int.Parse(input[3]);
                    int c = int.Parse(input[4]);
                    int d = int.Parse(input[5]);
                    int e = int.Parse(input[6]);
                    int f = int.Parse(input[7]);
                    int s = int.Parse(input[8]);
                    int m = int.Parse(input[9]);
                    double val = m * f * s - p;
                    val /= a + b + c + (d + e) * m;
                    res[res.Count - 1][i] = new Seed(input[0], val);
                }
            }

            for (int i = 0; i < res.Count; i++)
            {
                Array.Sort(res[i]);
                for (int j = 0; j<res[i].Length; j++)
                {
                    WriteLine(res[i][j].name);
                }
                WriteLine("#");
            }
        }

        class Seed : IComparable<Seed>
        {
            public string name;
            public double value;

            public Seed(string name,double value)
            {
                this.name = name;
                this.value = value;
            }
            
            public int CompareTo(Seed other)
            {
                if (value > other.value) return -1;
                if (value == other.value)
                {
                    return string.Compare(name, other.name);
                }
                else return 1;
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
