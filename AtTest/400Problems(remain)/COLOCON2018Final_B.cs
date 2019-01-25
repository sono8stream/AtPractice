using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class COLOCON2018Final_B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            char[] marks = new char[6] { '+', '*', '-', '/', '(', ')' };
            string s = Read();
            List<char> res = new List<char>();
            Stack<char> opers= new Stack<char>();
            int nest = 0;
            for(int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        opers.Push(s[i]);
                        break;
                    case ',':
                        res.Add(opers.Peek());
                        break;
                    case ')':
                        opers.Pop();
                        res.Add(s[i]);
                        break;
                    default:
                        res.Add(s[i]);
                        break;
                }
            }
            Console.WriteLine(res.ToArray());
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
