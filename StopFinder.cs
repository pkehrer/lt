using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LondonTube.Models;

namespace LondonTube
{
    class StopFinder
    {
        readonly IDictionary<string, Station> _stations;

        internal StopFinder(IDictionary<string, Station> stations)
        {
            _stations = stations;
        }

        internal IEnumerable<string> GetStops(string fromStation, int distance, IList<string> visitedStops = null)
        {
            if (distance == 0)
            {
                return new[] { fromStation };
            }
            var stops = new List<string>();
            visitedStops = visitedStops ?? new List<string>(new[] { fromStation });

            foreach (var connection in _stations[fromStation].Connections.Where(c => !visitedStops.Contains(c.ToStation)))
            {
                visitedStops.Add(connection.ToStation);
                stops.AddRange(GetStops(connection.ToStation, distance - 1, visitedStops));
            }
            return stops;
        }
    }
}
