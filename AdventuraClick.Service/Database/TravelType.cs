namespace AdventuraClick.Service.Database;
public partial class TravelType
{
    public int TravelTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();
}
