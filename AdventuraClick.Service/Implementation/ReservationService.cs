using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventuraClick.Service.Implementation
{
    public class ReservationService : CRUDService<Model.Reservation, ReservationSearchObject, Database.Reservation, ReservationInsertRequest,
        ReservationUpdateRequest>, IReservationService
    {
        public ReservationService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        {}

        public override IQueryable<Reservation> AddInclude(IQueryable<Reservation> query, ReservationSearchObject search = null)
        {
            var includedQuery = base.AddInclude(query, search);

            if (search.IncludeUser)
            {
                includedQuery = includedQuery.Include("User");
            }
            if (search.IncludeAdditionalServices)
            {
                includedQuery = includedQuery.Include(x=> x.AdditionalServicesReservations).ThenInclude(x=> x.AdditionalService);
            }
            if (search.IncludeTravel)
            {
                includedQuery = includedQuery.Include("Travel");
            }
            if (search.IncludePayment)
            {
                includedQuery = includedQuery.Include("Payment");
            }
            if (search.IncludeTravelInformation)
            {
                includedQuery = includedQuery.Include("TravelInformation");
            }

            return includedQuery;
        }

        public override Model.Reservation Insert(ReservationInsertRequest request)
        {

            return base.Insert(request);
        }
    }
}
