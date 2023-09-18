using AdventuraClick.Model.Requests;
using AutoMapper;

namespace AdventuraClick.Service.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // Travel
            CreateMap<Database.Travel, Model.Travel>().ReverseMap();
            CreateMap<Database.Travel, Model.TravelUpsertRequest>().ReverseMap();
            // User
            CreateMap<Database.User, Model.User>().ReverseMap();
            CreateMap<Database.User, UserInsertRequest>().ReverseMap();
            CreateMap<Database.User, UserUpdateRequest>().ReverseMap();
            // Reservation
            CreateMap<Database.Reservation, Model.Reservation>().ReverseMap();
            CreateMap<Database.Reservation, ReservationInsertRequest>().ReverseMap();
            CreateMap<ReservationInsertRequest, Database.Reservation>().ReverseMap();
            CreateMap<Database.Reservation, ReservationUpdateRequest>().ReverseMap();
            // Role
            CreateMap<Database.Role, Model.Role>().ReverseMap();
        }
    }
}