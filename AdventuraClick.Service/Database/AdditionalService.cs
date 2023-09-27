namespace AdventuraClick.Service.Database;

public partial class AdditionalService
{
    public int AddServiceId { get; set; }

    public string? Name { get; set; }

    public float Price { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
