namespace AdventuraClick.Model.Requests
{
    public class TravelInformationUpsertRequest
    {
        public DateTime DepartureTime { get; set; }

        public string? CreatedBy { get; set; }

        public int TravelId { get; set; }
    }
}
