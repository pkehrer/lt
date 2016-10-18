namespace LondonTube.Models
{
    /// <summary>
    /// Model of a connection from one station to another.
    /// </summary>
    class Connection
    {
        public Connection(string line, Station toStation)
        {
            Line = line;
            ToStation = toStation;
        }
        public string Line { get; }

        public Station ToStation { get; }
    }
}