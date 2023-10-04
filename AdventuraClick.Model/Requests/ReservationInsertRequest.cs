using System.ComponentModel.DataAnnotations;

namespace AdventuraClick.Model.Requests
{
    public class ReservationInsertRequest
    {
        public string Status { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Range(1, 10)]
        public int NumberOfPassengers { get; set; }
        public int? UserId { get; set; }
        public int? TravelId { get; set; }
        public List<int> AdditionalServices { get; set; } = new List<int>();
        public PaymentUpsertRequest Payment { get; set; }
        public int? TravelInformationId { get; set; }
    }
}
