using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;

namespace AdventuraClick.Controllers
{
    public class AdditionalServiceController : CRUDController<Model.AdditionalService, AdditionalServiceSearchObject, AdditionalServiceUpsertRequest,
      AdditionalServiceUpsertRequest>
    {
        public AdditionalServiceController(IAdditionalService service) : base(service)
        { }
    }
}
