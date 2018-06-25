using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class Hakuchumu
    {
        public static void Method(string[] args)
        {
            string input = Console.ReadLine();
            string t = "";
            int index = input.Length - 1;
            while (index > 1)
            {
                string s = "   ";
                switch (input[index])
                {
                    case 'm':
                        s = "dream";
                        break;
                    case 'e':
                        s = "erase";
                        break;
                    case 'r':
                        if (input[index - 2] == 'm')
                        {
                            s = "dreamer";
                        }
                        else
                        {
                            s = "eraser";
                        }
                        break;
                }
                t = t.Insert(0, s);
                index -= s.Length;
            }

            if (input.Equals(t))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
