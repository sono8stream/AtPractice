using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class Otoshidama
    {
        public static void Method(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int n = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            int firstMan = n;
            if (y < 10000 * n)
            {
                firstMan = y / 10000;
            }
            for (int manI = firstMan; manI >= 0; manI--)
            {
                int firstGo = n - manI;
                if (y - 10000 * manI < 5000 * firstGo)
                {
                    firstGo = (y - 10000 * manI) / 5000;
                }
                for (int goI = firstGo; goI >= 0; goI--)
                {
                    int margin = y - 10000 * manI - 5000 * goI;
                    int senI = n - manI - goI;
                    if (margin == 1000 * senI)
                    {
                        Console.WriteLine(string.Format("{0} {1} {2}", manI, goI, senI));
                        Console.ReadLine();
                        return;
                    }
                }
            }
            Console.WriteLine("-1 -1 -1");
            Console.ReadLine();
        }
    }
}
