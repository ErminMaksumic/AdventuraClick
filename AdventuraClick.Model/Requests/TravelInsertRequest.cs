﻿using AdventuraClick.Model.Requests;

namespace AdventuraClick.Model
{
    public class TravelInsertRequest
    {
        public string Name { get; set; } = null!;
        public byte[]? Image { get; set; } = null!;
        public string ImageString { get; set; } = null!;
        public int NumberOfNights {  get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public string? Status { get; set; }
        public int[]? IncludedItemIds { get; set; }
        public int? TravelTypeId { get; set; }
        public LocationUpsertRequest Location { get; set; }
        public List<TravelInformationUpsertRequest> TravelInformations { get; set; }

    }
}
