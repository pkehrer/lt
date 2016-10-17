using System;

namespace LondonTube
{
    public class Program
    {

        const string DefaultStation = "East Ham";
        const int DefaultDistance = 4;

        public static void Main(string[] args)
        {
            var stations = StationMapBuilder.BuildStationMap("tubelinedata.csv");
            var stopFinder = new StopFinder(stations);

            while (true)
            {
                Console.Write($"Enter station name [{DefaultStation}]:");
                var station = Console.ReadLine();
                Console.Write($"Enter number of stops [{DefaultDistance}]:");
                var distanceString = Console.ReadLine();

                if (string.IsNullOrEmpty(station))
                {
                    station = DefaultStation;
                }
                else if (!stations.ContainsKey(station))
                {
                    Console.WriteLine($"{station} is not a valid station name.");
                    continue;
                }

                int distance;
                if (string.IsNullOrEmpty(distanceString))
                {
                    distance = DefaultDistance;
                }
                else if (!int.TryParse(distanceString, out distance))
                {
                    Console.WriteLine("You must enter an integer value for number of stops.");
                    continue;
                }

                foreach (var foundStation in stopFinder.GetStops(station, distance))
                {
                    Console.WriteLine(foundStation);
                }
                Console.WriteLine();
            }
        }
    }
}
