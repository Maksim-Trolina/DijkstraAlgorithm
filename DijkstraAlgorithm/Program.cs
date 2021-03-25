using System;

namespace DijkstraAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var algo = new DijkstraAlgo();

                var pathToFile = Console.ReadLine();

                var start = Console.ReadLine();

                var end = Console.ReadLine();

                var (citiesName, coastFlight) = algo.GetPath(pathToFile, start, end);

                var curCity = (string) start;

                double sumCoast = 0;

                for (var i = citiesName.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine($"From {curCity} to {citiesName[i]}: {coastFlight[i]}");

                    sumCoast += coastFlight[i];

                    curCity = citiesName[i];
                }
                
                Console.WriteLine($"Total cost: {sumCoast}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}