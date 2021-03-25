using System;
using System.Collections.Generic;
using System.IO;

namespace DijkstraAlgorithm
{
    public class FileHandler
    {
        public List<(string, string, string, string)> FlightsInformation(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                throw new Exception("No such file exists");
            }

            var flightsInfo = new List<(string, string, string, string)>();

            using (var sr = new StreamReader(pathToFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    flightsInfo.Add(FlightInformation(line));
                }
            }

            return flightsInfo;
        }

        private (string, string, string, string) FlightInformation(string line)
        {
            var parameters = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

            if (parameters.Length != 4)
            {
                throw new Exception("Invalid data format");
            }

            var city1 = parameters[0];

            var city2 = parameters[1];

            var cost1 = parameters[2];

            var cost2 = parameters[3];

            return (city1, city2, cost1, cost2);
        }
    }
}