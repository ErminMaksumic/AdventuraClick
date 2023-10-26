using AdventuraClick.Model;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]

    public class TravelController : CRUDController<Model.Travel, TravelSearchObject, TravelInsertRequest,
      TravelUpdateRequest>
    {
        public TravelController(ITravelService service) : base(service)
        { }

        [Authorize(Roles = "Admin")]
        public override Travel Insert([FromBody] TravelInsertRequest request)
        {
            return base.Insert(request);
        }

        [Authorize(Roles = "Admin")]
        public override Travel Update(int id, [FromBody] TravelUpdateRequest request)
        {
            return base.Update(id, request);
        }

    }
}
