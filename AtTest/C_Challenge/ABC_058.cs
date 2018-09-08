using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_058
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var alphabets = new int[26];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                var alphaTemp = new int[26];
                for(int j = 0; j < s.Length; j++)
                {
                    alphaTemp[s[j] - 'a']++;
                }
                for(int j = 0; j < 26; j++)
                {
                    if (i == 0 || alphaTemp[j] < alphabets[j])
                    {
                        alphabets[j] = alphaTemp[j];
                    }
                }
            }
            for(int i = 0; i < 26; i++)
            {
                for(int j = 0; j < alphabets[i]; j++)
                {
                    Console.Write((char)('a' + i));
                }
            }
            Console.WriteLine("");
        }
    }
}
