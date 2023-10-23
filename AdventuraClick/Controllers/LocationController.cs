using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;

namespace AdventuraClick.Controllers
{
    public class LocationController : CRUDController<Model.Location, LocationSearchObject, LocationUpsertRequest,
      LocationUpsertRequest>
    {
        public LocationController(ILocationService service) : base(service)
        { }
    }
}
