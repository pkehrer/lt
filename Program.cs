using System;
using System.Collections.Generic;
using LondonTube.Models;

namespace LondonTube
{
    /// <summary>
    /// Entry point. Most of this class is just handling capturing user input.
    /// </summary>
    public class Program
    {
        const string DefaultStation = "East Ham";
        const int DefaultDistance = 4;

        public static void Main(string[] args)
        {
            var limitLines = new List<string>(); // Or set it to this to limit to 3 lines: new List<string> { "District", "Hammersmith and City", "Jubilee" };

            // Build the station map.
            var stations = StationMapBuilder.BuildStationMap("tubelinedata.csv", limitLines);

            // Get the stop finder object
            var stopFinder = new StopFinder();

            while (true)
            {
                Station station;
                int distance;

                if (TryGetUserInput(stations, out station, out distance))
                {
                    Console.WriteLine($"The following stations are {distance} stops away from {station}:");
                    foreach (var foundStation in stopFinder.GetStops(station, distance))
                    {
                        Console.WriteLine($" * {foundStation}");
                    }

                    Console.WriteLine();
                }
            }
        }

        private static bool TryGetUserInput(
            IDictionary<string, Station> stations, 
            out Station station, 
            out int distance)
        {
            station = null;
            distance = 0;

            Console.Write($"Enter station name [{DefaultStation}]:");
            var stationName = Console.ReadLine();
            Console.Write($"Enter number of stops [{DefaultDistance}]:");
            var distanceString = Console.ReadLine();
            Console.WriteLine();


            if (string.IsNullOrEmpty(stationName))
            {
                stationName = DefaultStation;
            }
            else if (!stations.ContainsKey(stationName))
            {
                Console.WriteLine($"{stationName} is not a valid station name.");
                return false;
            }
            station = stations[stationName];

            if (string.IsNullOrEmpty(distanceString))
            {
                distance = DefaultDistance;

            }
            else if (!int.TryParse(distanceString, out distance))
            {
                Console.WriteLine("You must enter an integer value for number of stops.");
                return false;
            }


            return true;
        }
    }
}
