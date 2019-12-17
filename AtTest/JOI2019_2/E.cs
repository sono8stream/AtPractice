using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.JOI2019_2
{
    class E
    {
        static Dictionary<char, long[]> dict;
        static long mask = 1000000000 + 7;

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
            char res = Read()[0];
            dict = new Dictionary<char, long[]>();
            dict.Add('R', new long[3] { 1, 0, 0 });
            dict.Add('S', new long[3] { 0, 1, 0 });
            dict.Add('P', new long[3] { 0, 0, 1 });
            dict.Add('?', new long[3] { 1, 1, 1 });
            Queue<char> queue = new Queue<char>();
            Stack<char> sub = new Stack<char>();
            for (int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    queue.Enqueue(s[i]);
                }
                else
                {
                    if (s[i] == ')')
                    {
                        while (sub.Peek() != '(') queue.Enqueue(sub.Pop());
                        sub.Pop();
                    }
                    else if (s[i] == '+' || s[i] == '-')
                    {
                        while (sub.Count > 0&&sub.Peek()!='(')
                        {
                            queue.Enqueue(sub.Pop());
                        }
                        sub.Push(s[i]);
                    }
                    else
                    {
                        sub.Push(s[i]);
                    }
                }
            }
            while (sub.Count > 0) queue.Enqueue(sub.Pop());
            Stack<long[]> stack = new Stack<long[]>();
            long mask = 1000000000 + 7;
            while (queue.Count > 0)
            {
                char val = queue.Dequeue();
                if (val == '+' || val == '-' || val == '*')
                {
                    long[] first = stack.Pop();
                    long[] second = stack.Pop();
                    long[] next = new long[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int other = (i + 1) % 3;
                        int other2 = (i + 2) % 3;
                        switch(val)
                        {
                            case '+':
                                next[i] = first[i] * second[other]
                                    + first[other] * second[i];
                                break;
                            case '-':
                                next[i] = first[i] * second[other2]
                                    + first[other2] * second[i];
                                break;
                            case '*':
                                next[i] += first[other] * second[other2]
                                    + first[other2] * second[other];
                                break;
                        }
                        next[i] += first[i] * second[i];
                        next[i] %= mask;
                    }
                    stack.Push(next);
                }
                else
                {
                    stack.Push(dict[val]);
                }
            }
            switch (res)
            {
                case 'R':
                    WriteLine(stack.Peek()[0]);
                    break;
                case 'S':
                    WriteLine(stack.Peek()[1]);
                    break;
                case 'P':
                    WriteLine(stack.Peek()[2]);
                    break;
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
