using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventuraClick.Service.Implementation
{
    public class TravelInformationService : CRUDService<Model.TravelInformation, TravelInformationSearchObject, Database.TravelInformation,
        TravelInformationUpsertRequest, TravelInformationUpsertRequest>, ITravelInformationService
    {
        public TravelInformationService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }

        public override IQueryable<TravelInformation> AddInclude(IQueryable<TravelInformation> query, TravelInformationSearchObject searchObject = null)
        {
            var includedQuery = base.AddInclude(query, searchObject);

            if (searchObject.IncludeTravel)
            {
                includedQuery = includedQuery.Include("Travel");
            }

            return includedQuery;
        }
    }
}
