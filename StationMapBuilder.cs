using System.Collections.Generic;
using System.IO;
using System.Linq;
using LondonTube.Models;

namespace LondonTube
{
    /// <summary>
    /// Reads data from the .csv file and creates a dictionary of station objects keyed on name which contain
    /// all of the connections to other stations.
    /// </summary>
    internal class StationMapBuilder
    {
        internal static IDictionary<string, Station> BuildStationMap(string dataFilePath, ICollection<string> limitLines = null)
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
                AddConnections(stations, tubeLineRow, limitLines);
            }

            return stations;
        }

        /// <summary>
        /// Given a row of data from the .csv file, add the station (if not already added) and add
        /// the specified connection in both directions.
        /// </summary>
        private static void AddConnections(IDictionary<string, Station> stations, TubeLineData tubeLineRow,ICollection<string> limitLines)
        {
            // If we've chosen to restrict the lines to search, ignore this row if it is not in the list
            // of included lines to search.
            if (limitLines != null &&
                limitLines.Any() &&
                !limitLines.Contains(tubeLineRow.Line))
            {
                return;
            }

            // Add the connection in both directions.
            AddConnection(stations, tubeLineRow.FromStation, tubeLineRow.Line, tubeLineRow.ToStation);
            AddConnection(stations, tubeLineRow.ToStation, tubeLineRow.Line, tubeLineRow.FromStation);
        }

        // Handle create/update of dictionary entries
        private static void AddConnection(IDictionary<string, Station> stations, string fromStationName, string line, string toStationName)
        {
            Station fromStation;
            if (!stations.TryGetValue(fromStationName, out fromStation))
            {
                stations[fromStationName] = new Station(fromStationName);
                fromStation = stations[fromStationName];
            }

            Station toStation;
            if (!stations.TryGetValue(toStationName, out toStation))
            {
                stations[toStationName] = new Station(toStationName);
                toStation = stations[toStationName];
            }

            fromStation.Connections.Add(new Connection(line, toStation));
        }
    }
}
