﻿using AdventuraClick.Model;
using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]

    public class UserController : CRUDController<Model.User, UserSearchObject, UserInsertRequest,
      UserUpdateRequest>
    {
        private readonly IUserService _service;

        private readonly IConfiguration _configuration;
        public UserController(IUserService service, IConfiguration configuration) : base(service)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            var user = _service.Login(username, password);
            if (user == null)
            {
                return BadRequest("Not valid credentials!");
            }

            var token = _service.GenerateToken(user);
            return Ok(new { token = token });
        }

        [AllowAnonymous]
        public override User Insert([FromBody] UserInsertRequest request)
        {
            return base.Insert(request);
        }

        [HttpPut("profileUpdate/{id}")]
        public Model.User ProfileUpdate(int id, [FromBody] ProfileUpdateRequest req)
        {
            return _service.ProfileUpdate(id, req);
        }
    }
}
