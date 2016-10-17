namespace LondonTube.Models
{
    class Connection
    {
        public Connection(string line, string toStation)
        {
            Line = line;
            ToStation = toStation;
        }
        public string Line { get; }
        public string ToStation { get; }
    }
}