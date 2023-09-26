using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;


namespace AdventuraClick.Service.Interfaces
{
    public interface IAdditionalService : ICRUDService<Model.AdditionalService, AdditionalServiceSearchObject, AdditionalServiceUpsertRequest,
        AdditionalServiceUpsertRequest>
    { }
}
