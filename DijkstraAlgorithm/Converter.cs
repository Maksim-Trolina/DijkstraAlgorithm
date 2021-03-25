using System.Collections;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class Converter
    {
        public City[] ConvertToAdjacencyList(List<(string, string, string, string)> flightsInfo)
        {
            var adjacencyList = GetCities(flightsInfo);

            return adjacencyList;
        }

        private City[] GetCities(List<(string, string, string, string)> flightsInfo)
        {
            IComparer comparer = new StrComparer();

            var tree = new AVLTree<string, City>(comparer);

            foreach (var flightInfo in flightsInfo)
            {
                var city1 = GetCity(flightInfo.Item1, tree);

                var city2 = GetCity(flightInfo.Item2, tree);

                AddEdge(flightInfo.Item3, city2, city1);

                AddEdge(flightInfo.Item4, city1, city2);
            }

            var cities = tree.GetItems();

            return cities;
        }

        private City GetCity(string cityName, AVLTree<string, City> tree)
        {
            try
            {
                var city = tree.Find(cityName);

                return city;
            }
            catch
            {
                var city = new City
                {
                    Name = cityName,
                    Edges = new List<Edge>(),
                    Id = tree.Count
                };

                tree.Insert(city.Name, city);

                return city;
            }
        }

        private void AddEdge(string weight, City cityTo, City cityFrom)
        {
            if (weight == "N/A")
            {
                return;
            }

            var edge = new Edge
            {
                CityId = cityTo.Id,
                Weight = double.Parse(weight)
            };

            cityFrom.Edges.Add(edge);
        }
    }
}