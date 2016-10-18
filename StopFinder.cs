using System.Collections.Generic;
using System.Linq;
using LondonTube.Models;

namespace LondonTube
{
    /// <summary>
    /// Handles the logic of finding the stops that are N stops away from a station.
    /// </summary>
    internal class StopFinder
    {
        /// <summary>
        /// Recursivley traverse the map in all directions from the starting point, throwing out
        /// any routes that hit an already-visited stop.
        /// </summary>
        /// <returns>The list of stations that are N stops away</returns>
        internal IEnumerable<Station> GetStops(Station fromStation, int distance, IList<Station> visitedStops = null)
        {
            if (distance == 0)
            {
                return new[] { fromStation };
            }

            var stops = new List<Station>();
            visitedStops = visitedStops ?? new List<Station>(new[] { fromStation });

            // only follow connections to stations we haven't seen yet.
            var connections = fromStation.Connections.Where(c => !visitedStops.Contains(c.ToStation));

            foreach (var connection in connections)
            {
                // update our visited stops to include the next station in the chain.
                var newVisitedStops = new List<Station>(visitedStops) { connection.ToStation };

                stops.AddRange(
                    GetStops(connection.ToStation, distance - 1, newVisitedStops));
            }

            // When multiple lines run between stations, it's easy to get duplicate routes
            // so eliminate them here.
            return stops.Distinct();
        }
    }
}
