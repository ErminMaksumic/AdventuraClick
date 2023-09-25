using AdventuraClick.Model;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;

namespace AdventuraClick.Service.Implementation
{
    public class TravelService : CRUDService<Model.Travel, TravelSearchObject, Database.Travel, TravelUpsertRequest,
        TravelUpsertRequest>, ITravelService
    {
        public TravelService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}