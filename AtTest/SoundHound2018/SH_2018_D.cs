using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.SoundHound2018
{
    class SH_2018_D
    {
        static int n;
        static City[] cities;

        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int s = int.Parse(input[2])-1;
            int t = int.Parse(input[3])-1;
            cities = new City[n];
            for (int i = 0; i < m; i++)
            {
                string[] inp=Console.ReadLine().Split(' ');
                int c1 = int.Parse(inp[0])-1;
                int c2 = int.Parse(inp[1])-1;
                if (cities[c1] == null)
                {
                    cities[c1] = new City();
                }
                if (cities[c2] == null)
                {
                    cities[c2] = new City();
                }
                cities[c1].trains.Add(new Train(c2,
                    int.Parse(inp[2]), int.Parse(inp[3])));
                cities[c2].trains.Add(new Train(c1,
                    int.Parse(inp[2]), int.Parse(inp[3])));
            }
            Dijkstra(s, true);
            Dijkstra(t, false);

            long money = 1000000000000000;
            for(int i = 0; i < n; i++)
            {
                cities[i].minTotal = cities[i].minYen + cities[i].minSnk;
            }
            for (int i = 0; i < n; i++)
            {
                int min = 0;
                for (int j = i; j < n; j++)
                {
                    if (j == i || cities[j].minTotal < min)
                    {
                        min = cities[j].minTotal;
                    }
                }
                Console.WriteLine(money - min);
            }
        }

        static void Dijkstra(int start,bool isYen)
        {
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
        }
    }

    class City
    {
        public List<Train> trains;
        public int minYen, minSnk, minTotal;
        public City()
        {
            trains = new List<Train>();
            minYen = -1;
            minSnk = -1;
        }
    }

    class Train
    {
        public int goalCity;
        public int yen, snook;
        public Train(int goalIndex, int y, int s)
        {
            goalCity = goalIndex;
            yen = y;
            snook = s;
        }
    }
}
