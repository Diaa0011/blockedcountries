namespace BlockedCountries.Dtos
{
    public class BlockedLogsData
    {
        public string ipAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public string CountryCode { get; set; }
        public bool BlockedStatus { get; set; }
        public string UserAgent { get; set; }
    }
}