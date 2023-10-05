using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventuraClick.Service.Implementation
{
    public class RatingService : CRUDService<Model.Rating, RatingSearchObject, Database.Rating, RatingUpsertRequest,
      RatingUpsertRequest>, IRatingService
    {
        public RatingService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }

        public override IQueryable<Rating> AddFilter(IQueryable<Rating> query, RatingSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search.TravelName))
            {
                filteredQuery = filteredQuery.Where(x => x.Travel.Name.StartsWith(search.TravelName));
            }


            return filteredQuery;
        }

        public override IQueryable<Rating> AddInclude(IQueryable<Rating> query, RatingSearchObject search = null)
        {
            var includedQuery = base.AddInclude(query, search);

            if (search.IncludeTravel)
            {
                includedQuery = includedQuery.Include("Travel");
            }
            if (search.IncludeUser)
            {
                includedQuery = includedQuery.Include("User");
            }

            return includedQuery;
        }
    }
}
