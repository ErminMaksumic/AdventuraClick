namespace AdventuraClick.Service.Database
{
    public class AdditionalServiceReservation
    {
        public int AdditionalServiceReservationId { get; set; }

        public int ReservationId { get; set; }

        public int AdditionalServiceId { get; set; }

        public virtual AdditionalService AdditionalService { get; set; } = null!;

        public virtual Reservation Reservation { get; set; } = null!;
    }
}
