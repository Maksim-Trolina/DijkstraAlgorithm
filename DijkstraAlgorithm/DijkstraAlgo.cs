using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class DijkstraAlgo
    {
        public (List<string>, List<double>) GetPath(string pathToFile, string startCity, string endCity)
        {
            var fileHandler = new FileHandler();

            var converter = new Converter();

            var flightsInfo = fileHandler.FlightsInformation(pathToFile);

            var cities = converter.ConvertToAdjacencyList(flightsInfo);

            var (startIndex, endIndex) = GetStartAndEndCityIndex(startCity, endCity, cities);

            var path = GetPath(cities, startIndex);

            return GetCityAndCoast(cities, endIndex, path, startIndex);
        }

        private (int, int) GetStartAndEndCityIndex(string startCity, string endCity, City[] cities)
        {
            var startIndex = -1;

            var endIndex = -1;

            foreach (var city in cities)
            {
                if (city.Name == startCity)
                {
                    startIndex = city.Id;
                }

                if (city.Name == endCity)
                {
                    endIndex = city.Id;
                }
            }

            return (startIndex, endIndex);
        }

        private int[] GetPath(City[] cities, int startIndex)
        {
            var n = cities.Length;

            var coastsPath = new double[n];

            var path = new int[n];

            var used = new bool[n];

            for (var i = 0; i < n; i++)
            {
                coastsPath[i] = double.MaxValue;

                path[i] = -1;
            }

            coastsPath[startIndex] = 0;

            for (var i = 0; i < n; i++)
            {
                var vertex = -1;

                for (var j = 0; j < n; j++)
                {
                    if (!used[j] && (vertex == -1 || coastsPath[j] < coastsPath[vertex]))
                    {
                        vertex = j;
                    }
                }

                if (coastsPath[vertex] == double.MaxValue)
                {
                    break;
                }

                used[vertex] = true;

                for (var j = 0; j < cities[vertex].Edges.Count; j++)
                {
                    var to = cities[vertex].Edges[j].CityId;

                    var weight = cities[vertex].Edges[j].Weight;

                    if (coastsPath[vertex] + weight < coastsPath[to])
                    {
                        coastsPath[to] = coastsPath[vertex] + weight;

                        path[to] = vertex;
                    }
                }
            }

            return path;
        }

        private (List<string>, List<double>) GetCityAndCoast(City[] cities, int endIndex, int[] path, int startIndex)
        {
            if (path[endIndex] == -1 && startIndex != endIndex)
            {
                throw new Exception("There is no way");
            }

            var citiesName = new List<string>();

            var coasts = new List<double>();

            var curCity = endIndex;

            while (path[curCity] != -1)
            {
                citiesName.Add(cities[curCity].Name);

                var coast = GetCoastFlight(cities[path[curCity]], curCity);

                coasts.Add(coast);

                curCity = path[curCity];
            }

            return (citiesName, coasts);
        }

        private double GetCoastFlight(City city, int cityToId)
        {
            var edges = city.Edges;

            foreach (var edge in edges)
            {
                if (edge.CityId == cityToId)
                {
                    return edge.Weight;
                }
            }

            throw new Exception("Not found city Id");
        }
    }
}