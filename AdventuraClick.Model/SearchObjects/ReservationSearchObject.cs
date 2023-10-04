namespace AdventuraClick.Model.SearchObjects
{
    public class ReservationSearchObject : BaseSearchObject
    {
        public bool IncludeUser { get; set; }
        public bool IncludeAdditionalServices { get; set; }
        public bool IncludeTravel { get; set; }
        public bool IncludePayment { get; set; }
        public bool IncludeTravelInformation { get; set; }
        public int UserId { get; set; }
    }
}
