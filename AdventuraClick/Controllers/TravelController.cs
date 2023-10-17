using AdventuraClick.Model;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Components;

namespace AdventuraClick.Controllers
{
    [Route("api/[controller]")]

    public class TravelController : CRUDController<Model.Travel, TravelSearchObject, TravelInsertRequest,
      TravelUpdateRequest>
    {
        public TravelController(ITravelService service) : base(service)
        { }
    }
}
