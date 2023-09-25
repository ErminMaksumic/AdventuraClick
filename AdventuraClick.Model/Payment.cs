namespace AdventuraClick.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public DateTime Date { get; set; }

        public float Amount { get; set; }

        public int? TravelId { get; set; }

        public virtual Travel? Travel { get; set; }
    }
}