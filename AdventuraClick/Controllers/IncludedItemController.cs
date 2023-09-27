using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
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
    }
}
