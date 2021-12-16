using System;

namespace Home_Work_4
{
    class Program
    {
        static void Main(string[] args)
        {

            int City_of_Number = int.Parse(Console.ReadLine());

            int[,] Graph = new int[City_of_Number, City_of_Number];
            string[] City = new string[City_of_Number];

            Cityletter(City);
            InputCity(Graph);

            Console.WriteLine("Find the city >:) ");

            string final = Console.ReadLine();

            

            int U = 0;

            for (int i = 0; i < City.Length ; i++)
            {
                if( City[i] == final)
                {

                    U = i;

                }
            }

            GFG t = new GFG();

            t.dijkstra( Graph, U ,City_of_Number);

            for (int i = 0; i < Graph.GetLength(0); i++)
            {
                for (int j = 0; j < Graph.GetLength(1); j++) 
                {
                    
                    Console.Write (" " + Graph[i , j] ) ;
                    
                }
                    
            }    

        }

        

        static void InputCity(int[,] Graph)
        {
            for (int i = 0; i < Graph.GetLength(0); i++)
            {
                
                for (int j = 0; j < Graph.GetLength(1); j++)
                {

                    if (j > i)
                    {
                        Graph[i, j] = 0;
                    }
                    else if (j == i)
                    {
                        Graph[i, j] = -1;
                    }
                    else
                    {
                        Graph[i, j] = int.Parse(Console.ReadLine());
                    }


                }

            }
            for (int i = 0; i < Graph.GetLength(0); i++)
            {
                // column
                for (int j = 0; j < Graph.GetLength(1); j++)
                {
                    Graph[i, j] = Graph[j, i];

                }
            }
        }

        static void Cityletter(string[] cityArray)
        {
            for (int i = 0; i < cityArray.Length; i++)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                cityArray[i] = name;
            }
        }

        /*============================================*/


        class GFG
        {            
            int minDistance(int[] dist,bool[] sptSet, int V)
            {
                // Initialize min value
                int min = int.MaxValue, min_index = -1;

                for (int v = 0; v < V; v++)
                    if (sptSet[v] == false && dist[v] <= min)
                    {
                        min = dist[v];
                        min_index = v;
                    }

                return min_index;
            }


            void printSolution(int[] dist )
            {               
                Console.WriteLine(dist[0]);
            }


            public void dijkstra(int[,] graph, int src , int V)
            {
                int[] dist = new int[V];


                bool[] sptSet = new bool[V];


                for (int i = 0; i < V; i++)
                {
                    dist[i] = int.MaxValue;
                    sptSet[i] = false;
                }
                dist[src] = 0;

                for (int count = 0; count < V - 1; count++)
                {

                    int u = minDistance(dist, sptSet,V);


                    sptSet[u] = true;

                    
                    for (int v = 0; v < V; v++)

                        
                        if (!sptSet[v] && graph[u, v] != -1 &&
                             dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                            dist[v] = dist[u] + graph[u, v];
                }                
                printSolution(dist );
            }

        }
    }
}
