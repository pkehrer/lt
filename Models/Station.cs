using System.Collections.Generic;

namespace LondonTube.Models
{
    class Station
    {
        public Station(string name)
        {
            Name = name;
            Connections = new List<Connection>();
        }
        public string Name { get; }
        public List<Connection> Connections { get; } 
    }
}
