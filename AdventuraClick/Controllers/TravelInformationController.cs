using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TravelInformationController : CRUDController<Model.TravelInformation, TravelInformationSearchObject, TravelInformationUpsertRequest,
     TravelInformationUpsertRequest>
    {
        public TravelInformationController(ITravelInformationService service) : base(service)
        { }
    }
}
