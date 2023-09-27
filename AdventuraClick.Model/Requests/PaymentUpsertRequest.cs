namespace AdventuraClick.Model.Requests
{
    public class PaymentUpsertRequest
    {
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
