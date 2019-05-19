using System;
using System.Collections.Generic;

namespace DIP
{
    class MainClass
    {
        static void ain()
        {
            IMaxHolder maxHolder = new Group();
            maxHolder.Add(100);
            maxHolder.Add(-100);
            Console.WriteLine(maxHolder.Max);
        }
    }

    interface IMaxHolder
    {
        void Add(int value);
        int Max { get; }
    }

    class Group : IMaxHolder
    {
        List<int> list;

        public int Max { get; private set; }

        public Group()
        {
            list = new List<int>();
        }

        public void Add(int item)
        {
            list.Add(item);
            Max = Math.Max(Max, item);
        }
    }
}
