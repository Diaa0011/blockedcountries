namespace BlockedCountries.Dtos
{
    public class PaginationEntry
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }=250;
        public string? searchString{get;set;} = null;
    }
}