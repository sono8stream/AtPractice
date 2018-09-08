using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_109
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var strs = new string[n];
            for (int i = 0; i < n; i++)
            {
                strs[i] = Console.ReadLine();
            }
            var dict = new Dictionary<string, bool>();
            dict.Add(strs[0], true);
            for(int i = 1; i < n; i++)
            {
                if (dict.ContainsKey(strs[i]))
                {
                    Console.WriteLine("No");
                    return;
                }
                else
                {
                    if (strs[i - 1][strs[i - 1].Length - 1] == strs[i][0])
                    {
                        dict.Add(strs[i], true);
                    }
                    else
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
            }
            Console.WriteLine("Yes");
        }
    }
}
