namespace AdventuraClick.Model
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public string? Status { get; set; }

        public string Date { get; set; } = null!;

        public int? TravelId { get; set; }

        public virtual Travel? Travel { get; set; }

        public int? UserId { get; set; }

        public virtual User? User { get; set; }

        public int? PaymentId { get; set; }

        public virtual Payment? Payment { get; set; }

        public List<AdditionalService> AdditionalServices { get; set; }
        public virtual ICollection<AdditionalServiceReservation> AdditionalServicesReservations { get; set; } = new List<AdditionalServiceReservation>();

    }
}
