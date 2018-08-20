using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_104
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
            string s = Console.ReadLine();

            if (s[0] != 'A')
            {
                Console.WriteLine("WA");
                return;
            }

            bool hasC = false;
            int cIndex = -1;
            for(int i = 2; i <= s.Length-2; i++)
            {
                if (s[i] == 'C')
                {
                    if (hasC)
                    {
                        Console.WriteLine("WA");
                        return;
                    }
                    else
                    {
                        hasC = true;
                        cIndex = i;
                    }
                }
            }

            if (hasC == false)
            {
                Console.WriteLine("WA");
                return;
            }
            string newS = s.Substring(1, cIndex - 1);
            newS += s.Substring(cIndex + 1);

            for(int i = 0; i < newS.Length; i++)
            {
                if (!char.IsLower(newS[i]))
                {
                    Console.WriteLine("WA");
                    return;
                }
            }
            Console.WriteLine("AC");

            /*bool hasC = false;
            for(int i = 0; i < s.Length; i++)
            {
                if (i == 0)
                {
                    if (s[i] != 'A')
                    {
                        Console.WriteLine("WA");
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (i >= 2 && i < s.Length - 2
                    &&s[i]=='C')
                {
                    if (hasC)
                    {
                        Console.WriteLine("WA");
                        return;
                    }
                    else
                    {
                        hasC = true;
                    }
                }
                else if (!char.IsLower(s[i]))
                {
                    Console.WriteLine("WA");
                    return;
                }
            }

            if (!hasC)
            {
                Console.WriteLine("WA");
            }
            else
            {
                Console.WriteLine("AC");
            }*/
        }
    }
}
