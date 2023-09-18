namespace AdventuraClick.Model.Requests
{
    public class ReservationInsertRequest
    {
        public string? Note { get; set; }

        public string? Status { get; set; }

        public string Date { get; set; } = null!;

        public int? TravelId { get; set; }

        public virtual Travel? Travel { get; set; }
    }
}
