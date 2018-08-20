using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class CodeTest
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int x = 0, y = 0;
            (x, y) = (2, 2);
            Console.WriteLine(x.ToString() + y.ToString());
        }
    }
}
