namespace AdventuraClick.Service.Database
{
    public class TravelInformation
    {
        public int TravelInformationId { get; set; }

        public DateTime DepartureTime { get; set; }

        public string CreatedBy { get; set; }

        public int TravelId { get; set; }

        public virtual Travel? Travel { get; set; }
    }
}
