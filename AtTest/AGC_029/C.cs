using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AtTest.AGC_029
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
            int[] array = ReadInts();
            long bottom = 0;
            long top = int.MaxValue;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;
                var stack = new Stack<long[]>();
                bool can = true;
                stack.Push(new long[2] { 1, array[0] });
                for(int i = 1; i < n; i++)
                {
                    if (array[i - 1] < array[i])
                    {
                        stack.Push(new long[2] { 1, array[i] - array[i - 1] });
                    }
                    else
                    {
                        long sum = 0;
                        while (stack.Count > 0 
                            && sum + stack.Peek()[1] <= array[i - 1] - array[i])
                        {
                            sum += stack.Pop()[1];
                        }
                        stack.Peek()[1] -= array[i - 1] - array[i] - sum;

                        if (stack.Peek()[0] == mid)
                        {
                            if (stack.Count == 1)
                            {
                                can = false;
                                break;
                            }
                            long cnt = stack.Peek()[1];
                            stack.Pop();
                            Add(stack);
                            stack.Push(new long[2] { 1, cnt });
                        }
                        else
                        {
                            Add(stack);
                        }
                    }
                    Normalize(stack);
                }
                if (can) top = mid;
                else bottom = mid;
            }
            Console.WriteLine(top);
        }

        static void Normalize(Stack<long[]> stack)
        {
            if (stack.Count > 1)
            {
                long[] peek = stack.Pop();
                if (stack.Peek()[0] == peek[0])
                {
                    stack.Peek()[1] += peek[1];
                }
                else
                {
                    stack.Push(peek);
                }
            }
        }

        static void Add(Stack<long[]> stack)
        {
            if (stack.Peek()[1] == 1)
            {
                stack.Peek()[0]++;
            }
            else
            {
                stack.Peek()[1]--;
                stack.Push(new long[2] { stack.Peek()[0] + 1, 1 });
            }
            Normalize(stack);
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
