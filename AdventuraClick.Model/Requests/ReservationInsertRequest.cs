using System.ComponentModel.DataAnnotations;

namespace AdventuraClick.Model.Requests
{
    public class ReservationInsertRequest
    {
        public string Status { get; set; }
        [MaxLength(30)]
        public string Note { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }
        public int? TravelId { get; set; }
        public List<int> AdditionalServices { get; set; } = new List<int>();
        public PaymentUpsertRequest Payment { get; set; }


    }
}
