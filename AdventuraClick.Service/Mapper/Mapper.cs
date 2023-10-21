using AdventuraClick.Model;
using AdventuraClick.Model.Requests;
using AutoMapper;

namespace AdventuraClick.Service.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // Travel Type
            CreateMap<Database.TravelType, Model.TravelType>().ReverseMap();
            // Travel
            CreateMap<Database.Travel, Model.Travel>().ForMember(x => x.IncludedItems, opts => opts.MapFrom(x => x.IncludedItemTravels.Select(x => x.IncludedItem).ToList()));
            CreateMap<Database.Travel, TravelInsertRequest>().ReverseMap();
            CreateMap<Database.Travel, TravelUpdateRequest>().ReverseMap();
            // User
            CreateMap<Database.User, Model.User>().ReverseMap();
            CreateMap<Database.User, UserInsertRequest>().ReverseMap();
            CreateMap<Database.User, UserUpdateRequest>().ReverseMap();
            // Reservation
            CreateMap<Database.Reservation, Model.Reservation>().ForMember(x => x.AdditionalServices,
                 opts => opts.MapFrom(x => x.AdditionalServicesReservations.Select(x => x.AdditionalService).ToList()));
            CreateMap<Database.Reservation, ReservationInsertRequest>().ReverseMap();
            // Role
            CreateMap<Database.Role, Model.Role>().ReverseMap();
            // Rating
            CreateMap<Database.Rating, Model.Rating>().ReverseMap();
            CreateMap<Database.Rating, RatingUpsertRequest>().ReverseMap();
            // Additional service
            CreateMap<Database.AdditionalService, Model.AdditionalService>().ReverseMap();
            CreateMap<Database.AdditionalService, AdditionalServiceUpsertRequest>().ReverseMap();
            // Location
            CreateMap<Database.Location, Model.Location>().ReverseMap();
            // Included Item
            CreateMap<Database.IncludedItem, Model.IncludedItem>().ReverseMap();
            CreateMap<Database.IncludedItem, IncludedItemUpsertRequest>().ReverseMap();
            // Payment
            CreateMap<Database.Payment, Model.Payment>().ReverseMap();
            CreateMap<Database.Payment, PaymentUpsertRequest>().ReverseMap();
            // AdditionalServiceReservation
            CreateMap<Database.AdditionalServiceReservation, Model.AdditionalServiceReservation>().ReverseMap();
            // Travel Information
            CreateMap<Database.TravelInformation, Model.TravelInformation>().ReverseMap();
            CreateMap<Database.TravelInformation, TravelInformationUpsertRequest>().ReverseMap();
            // Location
            CreateMap<Database.Location, Model.Location>().ReverseMap();
            CreateMap<Database.Location, LocationUpsertRequest>().ReverseMap();
        }
    }
}