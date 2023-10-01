using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;

namespace AdventuraClick.Service.Implementation
{
    public class TravelTypeService : BaseService<Model.TravelType, Database.TravelType, BaseSearchObject>, ITravelTypeService
    {
        public TravelTypeService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
