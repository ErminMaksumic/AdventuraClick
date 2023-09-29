using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuraClick.Model
{
    public class TravelUpsertRequest
    {
        public string Name { get; set; } = null!;

        public DateTime Date { get; set; }

        public string? Image { get; set; }

        public int NumberOfNights {  get; set; }

        public string? Description { get; set; }

        public float Price { get; set; }

        public string? Status { get; set; }

    }
}
