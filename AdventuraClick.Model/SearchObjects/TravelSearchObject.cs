namespace AdventuraClick.Model.SearchObjects
{
    public class TravelSearchObject : BaseSearchObject
    {
        public float? Price { get; set; }
        public string? Comparator { get; set; }
        public bool IncludeLocation { get; set; }
        public bool IncludeTravelType { get; set; }
        public bool IncludeTravelInformation { get; set; }
        public int? TravelTypeId { get; set; }

    }
}
