using System.Collections.Generic;

namespace LondonTube.Models
{
    /// <summary>
    /// Class for a station and all of it's connections to other stations
    /// </summary>
    internal class Station
    {
        public Station(string name)
        {
            Name = name;
            Connections = new List<Connection>();
        }
        internal string Name { get; }
        internal List<Connection> Connections { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
