namespace AdventuraClick.Model
{
    public partial class Travel
    {
        public int TravelId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Date { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public float Price { get; set; }

        public string? Status { get; set; }

        public int? TravelTypeId { get; set; }

        public int? LocationId { get; set; }

        public virtual TravelType? TravelType { get; set; }

        public virtual Location? Location { get; set; }


    }
}