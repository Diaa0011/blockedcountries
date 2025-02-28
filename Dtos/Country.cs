namespace BlockedCountries.Dtos 
{
    public record Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool temporalBlocked { get; set; } = false;
        public int? TemporalBlockTime { get; set; }

    }
}