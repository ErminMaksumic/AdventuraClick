using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using AutoMapper;

namespace AdventuraClick.Service.Implementation
{
    public class RoleService : BaseService<Model.Role, Database.Role, BaseSearchObject>, IRoleService
    {
        public RoleService(Database.AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
