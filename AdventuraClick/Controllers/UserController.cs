using AdventuraClick.Model;
using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Components;

namespace AdventuraClick.Controllers
{
    [Route("api/[controller]")]

    public class UserController : CRUDController<Model.User, UserSearchObject, UserInsertRequest,
      UserUpdateRequest>
    {
        public UserController(IUserService service) : base(service)
        { }
    }
}
