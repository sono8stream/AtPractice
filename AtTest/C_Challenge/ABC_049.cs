using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_049
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string input = Console.ReadLine();
            var keys = new string[4] { "dream", "dreamer", "erase", "eraser" };
            while (input.Length > 0)
            {
                bool canErase = false;
                for (int i = 0; i < 4; i++)
                {
                    if (input.Length < keys[i].Length) continue;
                    if(input.Substring(input.Length - keys[i].Length,keys[i].Length)
                        .Equals(keys[i]))
                    {
                        canErase = true;
                        input = input.Substring(0, input.Length - keys[i].Length);
                    }
                }
                if (!canErase)
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
