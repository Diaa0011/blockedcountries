namespace BlockedCountries.Dtos
{
    public class PaginationEntry
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? searchString{get;set;}
    }
}