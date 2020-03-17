using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Tenka1_2012_B
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
            string s = Read();
            int prefix = 0;
            int sufix = 0;
            List<char> res = new List<char>();
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] != '_')
                {
                    break;
                }
                prefix++;
                res.Add('_');
            }
            for(int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != '_')
                {
                    break;
                }
                sufix++;
            }

            if (prefix == s.Length)
            {
                WriteLine(s);
                return;
            }

            if (!IsLower(s[prefix]))
            {
                WriteLine(s);
                return;
            }

            if (IsSnake(s.Substring(prefix,s.Length-prefix-sufix)))
            {
                for(int i = prefix; i < s.Length - sufix; i++)
                {
                    if (s[i] == '_')
                    {
                        i++;
                        res.Add((char)(s[i] - 'a' + 'A'));
                    }
                    else
                    {
                        res.Add(s[i]);
                    }
                }
                for(int i = 0; i < sufix; i++)
                {
                    res.Add('_');
                }
                WriteLine(res.ToArray());
            }
            else if (IsCamel(s.Substring(prefix, s.Length - prefix - sufix)))
            {
                for(int i = prefix; i < s.Length - sufix; i++)
                {
                    if (IsUpper(s[i]))
                    {
                        res.Add('_');
                        res.Add((char)(s[i] - 'A' + 'a'));
                    }
                    else
                    {
                        res.Add(s[i]);
                    }
                }
                for(int i = 0; i < sufix; i++)
                {
                    res.Add('_');
                }
                WriteLine(res.ToArray());
            }
            else
            {
                WriteLine(s);
            }
        }

        static bool IsSnake(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '_' && !IsLower(s[i + 1]))
                {
                    return false;
                }
                if (IsUpper(s[i]))
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsCamel(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '_')
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsUpper(char c)
        {
            return 'A' <= c && c <= 'Z';
        }

        static bool IsLower(char c)
        {
            return 'a' <= c && c <= 'z';
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
