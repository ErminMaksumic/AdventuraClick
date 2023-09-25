using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;

namespace AdventuraClick.Service.Interfaces
{
    public interface IRatingService : ICRUDService<Model.Rating, RatingSearchObject, RatingUpsertRequest,
        RatingUpsertRequest>
    { }
}
