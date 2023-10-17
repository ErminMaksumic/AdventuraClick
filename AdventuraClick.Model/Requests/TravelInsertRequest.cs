namespace AdventuraClick.Model
{
    public class TravelInsertRequest
    {
        public string Name { get; set; } = null!;
        public string? Image { get; set; }
        public int NumberOfNights {  get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public string? Status { get; set; }
    }
}
