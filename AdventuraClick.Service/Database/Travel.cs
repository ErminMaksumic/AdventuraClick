namespace AdventuraClick.Service.Database;
public class Travel
{
    public int TravelId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Date { get; set; }
    public byte[] Image { get; set; }
    public int NumberOfNights { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public string? Status { get; set; }
    public int? TravelTypeId { get; set; }
    public int? LocationId { get; set; }
    public virtual Location? Location { get; set; }
    public virtual ICollection<TravelInformation> TravelInformations { get; set; }
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    public virtual ICollection<AdditionalServiceReservation> AdditionalServicesReservations { get; set; } = new List<AdditionalServiceReservation>();
    public virtual ICollection<IncludedItemTravel> IncludedItemTravels { get; set; }
    public virtual TravelType? TravelType { get; set; }

}
