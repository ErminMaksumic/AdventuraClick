using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RatingController : CRUDController<Model.Rating, RatingSearchObject, RatingUpsertRequest,
      RatingUpsertRequest>
    {
        public RatingController(IRatingService service) : base(service)
        { }
    }
}
