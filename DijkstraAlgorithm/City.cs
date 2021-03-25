using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class City
    {
        public List<Edge> Edges { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}