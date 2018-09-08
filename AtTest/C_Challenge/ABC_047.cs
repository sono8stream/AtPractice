using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_047
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string input = Console.ReadLine();
            bool isBlack = input[0] == 'B';
            int cnt = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if ((isBlack && input[i] == 'W')
                    ||(!isBlack&&input[i]=='B'))
                {
                    cnt++;
                    isBlack= input[i] == 'B';
                }
            }
            Console.WriteLine(cnt);
        }
    }
}
