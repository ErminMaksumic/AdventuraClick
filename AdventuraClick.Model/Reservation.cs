namespace AdventuraClick.Model
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string? Status { get; set; }
        public DateTime? Date { get; set; } = null!;
        public int NumberOfPassengers { get; set; }
        public int? TravelId { get; set; }
        public virtual Travel? Travel { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        public int? PaymentId { get; set; }
        public virtual Payment? Payment { get; set; }
        public int? TravelInformationId { get; set; }
        public virtual TravelInformation? TravelInformation { get; set; }
        public List<AdditionalService> AdditionalServices { get; set; }
        public virtual ICollection<AdditionalServiceReservation> AdditionalServicesReservations { get; set; } = new List<AdditionalServiceReservation>();

    }
}
