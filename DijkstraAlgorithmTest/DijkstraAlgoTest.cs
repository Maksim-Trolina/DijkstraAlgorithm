using System;
using System.Collections.Generic;
using NUnit.Framework;
using DijkstraAlgorithm;

namespace DijkstraAlgorithmTest
{
    public class Tests
    {
        
        [Test]
        public void GetPath_NotExistPathToFile_Exception()
        {
            var algo = new DijkstraAlgo();

            var pathToFile = "NotExist.txt";

            var start = "First";

            var end = "Second";

            Assert.Throws<Exception>(() => algo.GetPath(pathToFile, start, end));
        }

        [Test]
        public void GetPath_InvalidDataFormat_Exception()
        {
            var algo = new DijkstraAlgo();

            var pathToFile = "invalid.txt";

            var start = "First";

            var end = "Second";

            Assert.Throws<Exception>(() => algo.GetPath(pathToFile, start, end));
        }

        [Test]
        public void GetPath_NotExistPath_Exception()
        {
            var algo = new DijkstraAlgo();

            var pathToFile = "input.txt";

            var start = "Владивосток";

            var end = "Москва";

            Assert.Throws<Exception>(() => algo.GetPath(pathToFile, start, end));
        }

        [Test]
        public void GetPath_ExistPath_Path()
        {
            var algo = new DijkstraAlgo();

            var pathToFile = "input.txt";

            var start = "Москва";

            var end = "Владивосток";

            var path = algo.GetPath(pathToFile, start, end);

            var coasts = new List<double>
            {
                20,
                20
            };

            var citiesName = new List<string>
            {
                "Владивосток",
                "Санкт-Петербург"
            };

            var expected = (citiesName, coasts);

            Assert.IsTrue(AreEqual(path,expected));
        }
        

        private bool AreEqual((List<string>, List<double>) tuple1, (List<string>, List<double>) tuple2)
        {
            var citiesName1 = tuple1.Item1;

            var coasts1 = tuple1.Item2;

            var citiesName2 = tuple2.Item1;

            var coasts2 = tuple2.Item2;

            if (citiesName1.Count != citiesName2.Count)
            {
                return false;
            }

            if (coasts1.Count != coasts2.Count)
            {
                return false;
            }

            for (var i = 0; i < coasts1.Count; i++)
            {
                if (coasts1[i] != coasts2[i] || citiesName1[i] != citiesName2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}