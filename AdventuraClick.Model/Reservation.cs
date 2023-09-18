using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuraClick.Model
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public string? Note { get; set; }

        public string? Status { get; set; }

        public string Date { get; set; } = null!;

        public int? TravelId { get; set; }

        public virtual Travel? Travel { get; set; }
    }
}
