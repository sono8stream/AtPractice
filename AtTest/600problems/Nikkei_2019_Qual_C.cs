using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._600problems
{
    class Nikkei_2019_Qual_C
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
            UtilArray<int> aArray = new UtilArray<int>(ReadInts());
            UtilArray<int> bArray = new UtilArray<int>(ReadInts());

            for(int i = 0; i < n; i++)
            {
                if (aArray.GetByOrder(i).Value > bArray.GetByOrder(i).Value)
                {
                    WriteLine("No");
                    return;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (aArray.GetByOrder(i).Index == bArray.GetByOrder(i).Index)
                {
                    WriteLine("Yes");
                    return;
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (aArray.GetByOrder(i+1).Value <= bArray.GetByOrder(i).Value)
                {
                    WriteLine("Yes");
                    return;
                }
            }

            int cnt = 0;
            for (int i = 0; i < n - 1; i++)
            {
                int aIndex = aArray.GetByOrder(i).Index;
                int bIndex = bArray.GetByOrder(i).Index;

                if (aIndex != bIndex)
                {
                    cnt++;
                    aArray.SwapIndex(aIndex, bIndex);
                }
            }
            WriteLine(cnt == n - 1 ? "No" : "Yes");
        }

        class UtilArray<T> where T : IComparable
        {
            Ordered<T>[] indexed;
            Ordered<T>[] ordered;
            Dictionary<T, Ordered<T>> valued;

            public UtilArray(T[] array)
            {
                indexed = new Ordered<T>[array.Length];
                valued = new Dictionary<T, Ordered<T>>();
                for (int i = 0; i < array.Length; i++)
                {
                    indexed[i] = new Ordered<T>(array[i], i);
                    if (!valued.ContainsKey(array[i]))
                    {
                        valued.Add(array[i], indexed[i]);
                    }
                }

                ordered = indexed.OrderBy(a => a.Value).ToArray();
                int order = 0;
                ordered[0].Order = order;
                for (int i = 1; i < array.Length; i++)
                {
                    if (ordered[i - 1].Value.CompareTo(ordered[i].Value) == -1)
                    {
                        order++;
                    }
                    ordered[i].Order = order;
                }
            }

            public Ordered<T> GetByIndex(int index)
            {
                return indexed[index];
            }

            public Ordered<T> GetByOrder(int order)
            {
                return ordered[order];
            }

            public Ordered<T> GetByValue(T value)
            {
                return valued[value];
            }

            public void SwapIndex(int indexA,int indexB)
            {
                Ordered<T> tmp = GetByIndex(indexA);
                indexed[indexA] = GetByIndex(indexB);
                indexed[indexB] = tmp;

                indexed[indexA].Index = indexA;
                indexed[indexB].Index = indexB;
            }
        }

        class Ordered<T>
        {
            public T Value { get; private set; }
            public int Index { get; set; }
            public int Order { get; set; }

            public Ordered(T value, int index)
            {
                Value = value;
                Index = index;
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
