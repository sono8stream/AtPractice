using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CF1182
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string[] ss = new string[n];
            for (int i = 0; i < n; i++) ss[i] = Read();

            List<int>[,] sets = new List<int>[100000 + 10, 5];
            for(int i = 0; i < sets.GetLength(0); i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    sets[i, j] = new List<int>();
                }
            }
            var vowels = new Dictionary<char, int>();
            vowels.Add('a', 0);
            vowels.Add('i', 1);
            vowels.Add('u', 2);
            vowels.Add('e', 3);
            vowels.Add('o', 4);
            for (int i = 0; i < n; i++)
            {
                int cnt = 0;
                int lastID = 0;
                for(int j = 0; j < ss[i].Length; j++)
                {
                    char c = ss[i][j];
                    if(vowels.ContainsKey(c))
                    {
                        cnt++;
                        lastID = vowels[c];
                    }
                }
                sets[cnt, lastID].Add(i);
            }

            List<int[]> pairIndexes = new List<int[]>();
            Queue<int> secondable = new Queue<int>();
            Queue<int> firstable = new Queue<int>();
            for (int i = 0; i < sets.GetLength(0); i++)
            {
                Queue<int> remain = new Queue<int>();
                for (int j = 0; j < 5; j++)
                {
                    if (sets[i, j].Count % 2 == 1)
                    {
                        remain.Enqueue(sets[i, j][sets[i, j].Count - 1]);
                    }
                    for (int k = 0; k < sets[i, j].Count - 1; k += 2)
                    {
                        secondable.Enqueue(sets[i, j][k]);
                        secondable.Enqueue(sets[i, j][k + 1]);
                    }
                }
                while (remain.Count >= 2)
                {
                    firstable.Enqueue(remain.Dequeue());
                    firstable.Enqueue(remain.Dequeue());
                }
            }

            int m = 0;
            if (firstable.Count < secondable.Count)
            {
                m = (firstable.Count + secondable.Count) / 2;
            }
            else
            {
                m = secondable.Count;
            }
            m /= 2;
            WriteLine(m);
            while (secondable.Count>0)
            {
                string s1 = "";
                string s2 = "";
                if (firstable.Count > 0)
                {
                    s1 += ss[firstable.Dequeue()];
                    s2 += ss[firstable.Dequeue()];
                }
                else
                {
                    s1 += ss[secondable.Dequeue()];
                    s2 += ss[secondable.Dequeue()];
                }
                s1 += " ";
                s2 += " ";
                if (secondable.Count > 0)
                {
                    s1 += ss[secondable.Dequeue()];
                    s2 += ss[secondable.Dequeue()];
                    WriteLine(s1);
                    WriteLine(s2);
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
