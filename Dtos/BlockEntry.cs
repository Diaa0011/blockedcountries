namespace BlockedCountries.Dtos
{
    public record BlockEntry
    {
        public string code { get; set; }
        public string name { get; set; }
        public bool temporalBlocked { get; set; } = false;
        public int?  TemporalBlockTime { get; set; }
         }
}