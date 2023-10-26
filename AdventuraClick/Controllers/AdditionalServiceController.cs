using AdventuraClick.Model;
using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    public class AdditionalServiceController : CRUDController<Model.AdditionalService, AdditionalServiceSearchObject, AdditionalServiceUpsertRequest,
      AdditionalServiceUpsertRequest>
    {
        public AdditionalServiceController(IAdditionalService service) : base(service)
        { }

        [Authorize(Roles = "Admin")]
        public override AdditionalService Insert([FromBody] AdditionalServiceUpsertRequest request)
        {
            return base.Insert(request);
        }

        [Authorize(Roles = "Admin")]
        public override AdditionalService Update(int id, [FromBody] AdditionalServiceUpsertRequest request)
        {
            return base.Update(id, request);
        }
    }
}
