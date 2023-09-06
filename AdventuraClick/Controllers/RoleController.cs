using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : BaseController<Model.Role, BaseSearchObject>
    {
        public RoleController(IBaseService<Model.Role, BaseSearchObject> service) : base(service)
        { }
    }
}
