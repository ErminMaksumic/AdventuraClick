namespace AdventuraClick.Model.SearchObjects
{
    public class RatingSearchObject : BaseSearchObject
    {
        public string? TravelName { get; set; }
        public bool IncludeUser { get; set; }
        public bool IncludeTravel { get; set; }
    }
}
