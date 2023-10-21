using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;

namespace AdventuraClick.Service.Implementation
{
    public class LocationService : CRUDService<Model.Location, LocationSearchObject, Database.Location, LocationUpsertRequest,
      LocationUpsertRequest>, ILocationService
    {
        public LocationService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
