using AdventuraClick.Model;

namespace AdventuraClick.Service.Database;

public partial class Rating
{
    public int RatingId { get; set; }

    public int Rate { get; set; }

    public string? Comment { get; set; }

    public int? TravelId { get; set; }

    public virtual Travel? Travel { get; set; }
}
