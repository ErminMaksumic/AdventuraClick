namespace AdventuraClick.Model
{
    public class TravelUpdateRequest
    {
        public string Name { get; set; } = null!;
        public float Price { get; set; }
        public int NumberOfNights { get; set; }
    }
}
