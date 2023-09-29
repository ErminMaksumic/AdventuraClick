namespace AdventuraClick.Service.Database;

public partial class Payment
{
    public int PaymentId { get; set; }
    public string FullName { get; set; }
    public DateTime Date { get; set; }
    public float Amount { get; set; }
    public string TransactionNumber { get; set; }
    public int? TravelId { get; set; }
    public virtual Travel? Travel { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }

}
