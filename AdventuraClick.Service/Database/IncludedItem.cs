using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuraClick.Service.Database
{
    public class IncludedItem
    {
        public int IncludedItemId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<IncludedItemTravel> IncludedItemTravels { get; set; }
    }
}
