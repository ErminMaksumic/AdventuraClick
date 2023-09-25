using System.ComponentModel.DataAnnotations;

namespace AdventuraClick.Model.Requests
{
    public class RatingUpsertRequest
    {
        [Required, Range(1, 5)]
        public int? Rate { get; set; }
        [MaxLength(30)]
        public string Comment { get; set; }
        public int TravelId { get; set; }
        public int UserId { get; set; }

    }
}
