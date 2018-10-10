using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_097
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Console.ReadLine();
            int k = ReadInt();
            var strList = new List<string>();
            var existDict = new Dictionary<string, bool>();
            for(int i = 0; i < s.Length; i++)
            {
                string temp = "";
                for(int j = 0; j < k && i + j < s.Length; j++)
                {
                    temp += s[i + j].ToString();
                    if (!existDict.ContainsKey(temp))
                    {
                        strList.Add(temp);
                        existDict.Add(temp, true);
                    }
                }
            }
            strList.Sort();

            Console.WriteLine(strList[k - 1]);
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
