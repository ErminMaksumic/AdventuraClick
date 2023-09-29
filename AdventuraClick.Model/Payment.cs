namespace AdventuraClick.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public string FullName { get; set; }

        public DateTime Date { get; set; }

        public float Amount { get; set; }

        public string TransactionNumber { get; set; }

    }
}