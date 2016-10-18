namespace LondonTube.Models
{
    /// <summary>
    /// Just a class to hold the data from each row of the csv for building the station map.
    /// </summary>
    internal class TubeLineData
    {
        public TubeLineData(string line, string fromStation, string toStation)
        {
            Line = line;
            FromStation = fromStation;
            ToStation = toStation;
        }

        internal string Line { get; }
        internal string FromStation { get; }
        internal string ToStation { get; }

        public override string ToString()
        {
            return $"Line: {Line} - From {FromStation} to {ToStation}";
        }
    }
}
