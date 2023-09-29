using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;

namespace AdventuraClick.Service.Interfaces
{
    public interface ITravelInformationService : ICRUDService<Model.TravelInformation, TravelInformationSearchObject, TravelInformationUpsertRequest,
        TravelInformationUpsertRequest>
    { }
}
