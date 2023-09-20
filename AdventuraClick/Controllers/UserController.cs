using AdventuraClick.Authorization;
using AdventuraClick.Model;
using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]

    public class UserController : CRUDController<Model.User, UserSearchObject, UserInsertRequest,
      UserUpdateRequest>
    {
        private readonly IUserService _service;
        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("login")]
        public Model.User Login()
        {
            var credentials = CredentialsHelper.extractCredentials(Request);

            return _service.Login(credentials.Username, credentials.Password);
        }

        [AllowAnonymous]
        public override User Insert([FromBody] UserInsertRequest request)
        {
            return base.Insert(request);
        }
    }
}
