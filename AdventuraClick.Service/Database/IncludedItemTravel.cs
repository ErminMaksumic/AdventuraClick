using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuraClick.Service.Database
{
    public class IncludedItemTravel
    {
        public int IncludedItemTravelId { get; set; }
        public int? IncludedItemId { get; set; }
        public int? TravelId { get; set; }
        public virtual IncludedItem IncludedItem { get; set; } = null!;
        public virtual Travel Travel { get; set; } = null!;
    }
}
