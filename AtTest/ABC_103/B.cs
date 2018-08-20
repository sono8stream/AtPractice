using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_103
{
    class B
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();
            for (int i = 0; i <= s.Length; i++)
            {
                if (s.Equals(t))
                {
                    Console.WriteLine("Yes");
                    return;
                }

                string sub = s.Substring(0, s.Length - 1);
                s = s.Substring(s.Length - 1);
                s += sub;
                //Console.WriteLine(s);
            }
            Console.WriteLine("No");
        }
    }
}
