using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;

namespace AdventuraClick.Service.Interfaces
{
    public interface IIncludedItem : ICRUDService<Model.IncludedItem, IncludedItemSearchObject, IncludedItemUpsertRequest,
       IncludedItemUpsertRequest>
    { }
}
