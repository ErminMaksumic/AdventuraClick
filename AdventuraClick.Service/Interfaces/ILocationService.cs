using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;

namespace AdventuraClick.Service.Interfaces
{
    public interface ILocationService : ICRUDService<Model.Location, LocationSearchObject, LocationUpsertRequest,
    LocationUpsertRequest>
    { }
}
