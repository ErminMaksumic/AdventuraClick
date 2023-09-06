using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;

namespace AdventuraClick.Service.Implementation
{
    public class RoleService : BaseService<Model.Role, Role, BaseSearchObject>, IRoleService
    {
        public RoleService(AdventuraClickContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
