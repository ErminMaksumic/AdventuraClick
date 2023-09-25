using AdventuraClick.Model;
using AdventuraClick.Model.SearchObjects;

namespace AdventuraClick.Service.Interfaces
{
    public interface ITravelService : ICRUDService<Travel, TravelSearchObject, TravelUpsertRequest, TravelUpsertRequest>
    {}
}
