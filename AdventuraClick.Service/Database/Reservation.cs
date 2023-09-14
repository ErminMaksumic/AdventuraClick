﻿using System;
using System.Collections.Generic;

namespace AdventuraClick.Service.Database;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public string? Note { get; set; }

    public string? Status { get; set; }

    public string Date { get; set; } = null!;

    public int? TravelId { get; set; }

    public virtual Travel? Travel { get; set; }
}
