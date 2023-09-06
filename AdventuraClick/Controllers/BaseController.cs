using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
        [Route("api/[controller]")]
        [ApiController]

        public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
        {
            public readonly IBaseService<T, TSearch> _service;
            public BaseController(IBaseService<T, TSearch> service)
            {
                _service = service;
            }
            [HttpGet]
            virtual public async Task<IEnumerable<T>> Get([FromQuery] TSearch search)
            {
                return await _service.Get(search);
            }
            [HttpGet("{id}")]

            virtual public T GetById(int id)
            {
                return _service.GetById(id);
            }


        }
    }
