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
                
                Console.Write("Enter path to file: ");

                var pathToFile = Console.ReadLine();
                
                Console.Write("From the city: ");

                var start = Console.ReadLine();
                
                Console.Write("To the city: ");

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