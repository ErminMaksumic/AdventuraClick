using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;

namespace AdventuraClick.Service.Implementation
{
    public class AdditionalService : CRUDService<Model.AdditionalService, AdditionalServiceSearchObject, Database.AdditionalService, AdditionalServiceUpsertRequest,
      AdditionalServiceUpsertRequest>, IAdditionalService
    {
        public AdditionalService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }

        public override IQueryable<Database.AdditionalService> AddFilter(IQueryable<Database.AdditionalService> query, AdditionalServiceSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Name.StartsWith(search.Name));
            }

            return filteredQuery;
        }
    }
}
