namespace LondonTube.Models
{
    class TubeLineData
    {
        public TubeLineData(string line, string fromStation, string toStation)
        {
            Line = line;
            FromStation = fromStation;
            ToStation = toStation;
        }

        public string Line { get; }
        public string FromStation { get; }
        public string ToStation { get; }

        public override string ToString()
        {
            return $"Line: {Line} - From {FromStation} to {ToStation}";
        }
    }
}
