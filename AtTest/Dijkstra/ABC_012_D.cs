using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Dijkstra
{
    class ABC_012_D
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            for (int i = 0; i < m; i++)
            {
                string[] inp = Console.ReadLine().Split(' ');
                int n1 = int.Parse(input[0]);
                int n2 = int.Parse(input[1]);

            }
            Console.WriteLine("text");
        }

        static void Dijkstra(int start, bool isYen)
        {/*
            var queue = new Queue<int>();
            var fixArray = new bool[n];
            queue.Enqueue(start);
            if (isYen)
            {
                cities[start].minYen = 0;
            }
            else
            {
                cities[start].minSnk = 0;
            }


            while (queue.Count > 0)
            {
                int index = queue.Dequeue();
                City city = cities[index];
                fixArray[index] = true;

                for (int i = 0; i < city.trains.Count; i++)
                {
                    if (fixArray[city.trains[i].goalCity]) continue;

                    City nextCity = cities[city.trains[i].goalCity];
                    if (isYen)
                    {
                        int nextYen = city.minYen + city.trains[i].yen;
                        if (nextCity.minYen == -1 || nextCity.minYen > nextYen)
                        {
                            nextCity.minYen = nextYen;
                            if (!queue.Contains(city.trains[i].goalCity))
                            {
                                queue.Enqueue(city.trains[i].goalCity);
                            }
                        }
                    }
                    else
                    {
                        int nextSnk = city.minSnk + city.trains[i].snook;
                        if (nextCity.minSnk == -1 || nextCity.minSnk > nextSnk)
                        {
                            nextCity.minSnk = nextSnk;
                            if (!queue.Contains(city.trains[i].goalCity))
                            {
                                queue.Enqueue(city.trains[i].goalCity);
                            }
                        }
                    }
                }
            }
            */
        }
    }

    class Node
    {
        public int distance;
        public bool isFixed;
        public List<Edge> edges;

        public Node()
        {
            distance = -1;
            isFixed = false;
            edges = new List<Edge>();
        }
    }

    class Edge
    {
        public int toIndex;
        public int distance;

        public Edge(int to,int dist)
        {
            toIndex = to;
            distance = dist;
        }
    }
}
