using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.UtilArray
{
    class UtilArray<T> where T : IComparable
    {
        Ordered<T>[] indexed;
        Ordered<T>[] ordered;
        Dictionary<T, Ordered<T>> valued;

        public UtilArray(T[] array)
        {
            indexed = new Ordered<T>[array.Length];
            valued = new Dictionary<T, Ordered<T>>();
            for (int i = 0; i < array.Length; i++)
            {
                indexed[i] = new Ordered<T>(array[i], i);
                if (!valued.ContainsKey(array[i]))
                {
                    valued.Add(array[i], indexed[i]);
                }
            }

            ordered = indexed.OrderBy(a => a.Value).ToArray();
            int order = 0;
            ordered[0].Order = order;
            for (int i = 1; i < array.Length; i++)
            {
                if (ordered[i - 1].Value.CompareTo(ordered[i].Value) == -1)
                {
                    order++;
                }
                ordered[i].Order = order;
            }
        }

        public Ordered<T> GetByIndex(int index)
        {
            return indexed[index];
        }

        public Ordered<T> GetByOrder(int order)
        {
            return ordered[order];
        }

        public Ordered<T> GetByValue(T value)
        {
            return valued[value];
        }

        public void SwapIndex(int indexA, int indexB)
        {
            Ordered<T> tmp = GetByIndex(indexA);
            indexed[indexA] = GetByIndex(indexB);
            indexed[indexB] = tmp;

            indexed[indexA].Index = indexA;
            indexed[indexB].Index = indexB;
        }
    }

    class Ordered<T>
    {
        public T Value { get; private set; }
        public int Index { get; set; }
        public int Order { get; set; }

        public Ordered(T value, int index)
        {
            Value = value;
            Index = index;
        }
    }
}
