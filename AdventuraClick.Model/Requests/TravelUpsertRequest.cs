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
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false), Range(1, 1000)]
        public decimal Price { get; set; }
        public string Status { get; set; }
        public byte[]? Image { get; set; }
    }
}
