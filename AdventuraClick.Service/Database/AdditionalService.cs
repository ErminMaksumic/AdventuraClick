using System;
using System.Collections.Generic;

namespace AdventuraClick.Service.Database;

public partial class AdditionalService
{
    public int AddServiceId { get; set; }

    public string? Name { get; set; }

    public float Price { get; set; }

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();
}
