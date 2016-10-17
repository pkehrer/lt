using System.Collections.Generic;
using System.IO;
using System.Linq;
using LondonTube.Models;

namespace LondonTube
{
    internal class StationMapBuilder
    {
        internal static IDictionary<string, Station> BuildStationMap(string dataFilePath)
        {
            var lines = File.ReadAllLines(dataFilePath);
            var tubeLines = new List<TubeLineData>();

            foreach (var line in lines.Skip(1))
            {
                var data = line.Split(',');
                tubeLines.Add(new TubeLineData(data[0], data[1], data[2]));
            }

            var stations = new Dictionary<string, Station>();

            foreach (var tubeLineRow in tubeLines)
            {
                AddConnection(stations, tubeLineRow);
            }

            return stations;
        }


        private static void AddConnection(IDictionary<string, Station> stations, TubeLineData tubeLineRow)
        {
            //if (!new[] { "District", "Hammersmith and City", "Jubilee" }.Contains(tubeLineRow.Line))
            //{
            //    return;
            //}

            Station station;
            if (!stations.TryGetValue(tubeLineRow.FromStation, out station))
            {
                stations[tubeLineRow.FromStation] = new Station(tubeLineRow.FromStation);
                station = stations[tubeLineRow.FromStation];
            }
            station.Connections.Add(new Connection(tubeLineRow.Line, tubeLineRow.ToStation));

            if (!stations.TryGetValue(tubeLineRow.ToStation, out station))
            {
                stations[tubeLineRow.ToStation] = new Station(tubeLineRow.ToStation);
                station = stations[tubeLineRow.ToStation];
            }
            station.Connections.Add(new Connection(tubeLineRow.Line, tubeLineRow.FromStation));
        }
    }
}
