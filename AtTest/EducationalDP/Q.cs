using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;
using static System.Console;

namespace AtTest.EducationalDP
{
    class Q
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] hs = ReadInts();
            int[] array = ReadInts();

        }

        class SegmentTree
        {
            int[] tree;

            public SegmentTree(int[] array)
            {
                int n = 1;
                while (n < array.Length) n *= 2;

                tree = new int[n * 2 - 1];
                int tIndex = tree.Length - array.Length;
                for (int i = 0; i < array.Length; i++)
                {
                    tree[tIndex] = array[i];
                }
                for(int i = tIndex - 1; i >= 0; i--)
                {
                    InitializeNode(i);
                }
            }

            int[] GetChildren(int index)
            {
                int childIndex = index * 2 + 1;
                if (childIndex >= tree.Length) return null;
                return new int[2] { tree[childIndex], tree[childIndex + 1] };
            }

            void InitializeNode(int index)
            {
                int[] children = GetChildren(index);
                tree[index] = Min(children[0], children[1]);
            }

            //int GetMinIndex()
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
