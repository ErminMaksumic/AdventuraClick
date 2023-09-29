namespace AdventuraClick.Model
{
    public class IncludedItemTravel
    {
        public int IncludedItemTravelId { get; set; }
        public int? IncludedItemId { get; set; }
        public int? TravelId { get; set; }
        public virtual IncludedItem IncludedItem { get; set; } = null!;
        public virtual Travel Travel { get; set; } = null!;
    }
}
