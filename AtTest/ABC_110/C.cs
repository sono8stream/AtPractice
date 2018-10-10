using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_110
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();
            var changeDict = new Dictionary<char, char>();
            for(int i = 0; i < s.Length; i++)
            {
                if (changeDict.ContainsKey(s[i]))
                {
                    if (changeDict[s[i]] != t[i])
                    {
                        Console.WriteLine("No");
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    changeDict.Add(s[i], t[i]);
                }
            }
            //keyの重複チェック
            var checkDict = new Dictionary<char, bool>();
            foreach (KeyValuePair<char, char> pair in changeDict)
            {
                if (checkDict.ContainsKey(pair.Value))
                {
                    Console.WriteLine("No");
                    return;
                }
                else
                {
                    checkDict.Add(pair.Value, true);
                }
            }

            Console.WriteLine("Yes");
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
