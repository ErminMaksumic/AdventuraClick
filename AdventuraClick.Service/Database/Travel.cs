﻿namespace AdventuraClick.Service.Database;

public class Travel
{
    public int TravelId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public float Price { get; set; }

    public string? Status { get; set; }

    public int? TravelTypeId { get; set; }

    public int? LocationId { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual TravelType? TravelType { get; set; }

    public virtual ICollection<AdditionalService> AddServices { get; set; } = new List<AdditionalService>();
}