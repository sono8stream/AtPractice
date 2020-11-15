using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_049
{
    class B
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
            string s = Read();
            string t = Read();

            Queue<int> posS = new Queue<int>();
            Queue<int> posT = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                if (s[i] == '1')
                {
                    posS.Enqueue(i);
                }
                if (t[i] == '1')
                {
                    posT.Enqueue(i);
                }
            }

            long res = 0;
            while (posT.Count > 0)
            {
                while (true)
                {
                    if (posS.Count == 0)
                    {
                        WriteLine(-1);
                        return;
                    }

                    if (posS.Peek() >= posT.Peek())
                    {
                        res += posS.Dequeue() - posT.Dequeue();
                        break;
                    }
                    else
                    {
                        if (posS.Count < 2)
                        {
                            WriteLine(-1);
                            return;
                        }
                        else
                        {
                            res += -(posS.Dequeue()- posS.Dequeue());
                        }
                    }
                }
            }
            if (posS.Count % 2 == 1)
            {
                WriteLine(-1);
                return;
            }
            while (posS.Count > 0)
            {
                res += -(posS.Dequeue() - posS.Dequeue());
            }
            WriteLine(res);
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
