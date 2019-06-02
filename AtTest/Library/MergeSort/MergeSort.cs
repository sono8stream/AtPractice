using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

/// <summary>
/// 非常に遅いので使わないこと
/// ソートの実行時間はArray.Sort<OrderBy.ToArray()<MergeSort
/// </summary>
namespace AtTest.Library.MergeSort
{
    class Tester
    {
        static void ain(string[] args)
        {
            Random rnd = new Random();
            var nums = new int[1000000];
            for (int count = 0; count < 10; count++)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = rnd.Next(1, 1000000);
                }

                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                var result = nums.MergeSort((a, b) => a - b);
                sw.Stop();
                Write(sw.Elapsed + " ");
                sw.Restart();
                var result2 = nums.OrderBy(n => n);
                sw.Stop();
                Write(sw.Elapsed+" ");
                sw.Restart();
                Array.Sort(nums);
                sw.Stop();
                WriteLine(sw.Elapsed);
                // かなり遅い
                // LINQのOrderByメソッドの結果と比較することで、MergeSortが正しく整列されているかを確認している
                bool isEqual = Enumerable.SequenceEqual(result,result2);
                WriteLine(isEqual);
            }
            ReadLine();
        }
    }

    static class Sorter
    {
        public static IEnumerable<T> MergeSort<T>(
            this IEnumerable<T> items, Comparison<T> compare)
        {
            if (items.Count() > 1)
            {
                int m = items.Count() / 2;
                var a1 = items.Take(m);
                var a2 = items.Skip(m);
                return Merge(MergeSort(a1, compare),
                    MergeSort(a2, compare), compare);
            }
            return items;
        }

        // 非再帰版　Mergeメソッド
        private static IEnumerable<T> Merge<T>(
            IEnumerable<T> a1, IEnumerable<T> a2, Comparison<T> compare)
        {
            var ite1 = a1.GetEnumerator();
            var ite2 = a2.GetEnumerator();
            var exists1 = ite1.MoveNext();
            var exists2 = ite2.MoveNext();
            while (exists1 == true && exists2 == true)
            {
                T x1 = ite1.Current;
                T x2 = ite2.Current;
                if (compare(x1, x2) < 0)
                {
                    yield return x1;
                    exists1 = ite1.MoveNext();
                }
                else
                {
                    yield return x2;
                    exists2 = ite2.MoveNext();
                }
            }
            while (exists1)
            {
                yield return ite1.Current;
                exists1 = ite1.MoveNext();
            }
            while (exists2)
            {
                yield return ite2.Current;
                exists2 = ite2.MoveNext();
            }
        }
    }
}
