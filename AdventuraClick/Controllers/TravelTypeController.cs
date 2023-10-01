using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TravelTypeController : BaseController<Model.TravelType, BaseSearchObject>
    {
        public TravelTypeController(IBaseService<Model.TravelType, BaseSearchObject> service) : base(service)
        { }
    }
}
