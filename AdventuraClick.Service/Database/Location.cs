using System;
using System.Collections.Generic;

namespace AdventuraClick.Service.Database;

public partial class Location
{
    public int LocationId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();
}
