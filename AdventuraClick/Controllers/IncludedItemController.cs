using AdventuraClick.Model;
using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IncludedItemController : CRUDController<Model.IncludedItem, IncludedItemSearchObject, IncludedItemUpsertRequest,
      IncludedItemUpsertRequest>
    {
        public IncludedItemController(IIncludedItem service) : base(service)
        { }

        [Authorize(Roles = "Admin")]
        public override IncludedItem Insert([FromBody] IncludedItemUpsertRequest request)
        {
            return base.Insert(request);
        }

        [Authorize(Roles = "Admin")]
        public override IncludedItem Update(int id, [FromBody] IncludedItemUpsertRequest request)
        {
            return base.Update(id, request);
        }
    }
}
