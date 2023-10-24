using AdventuraClick.Model;
using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;

namespace AdventuraClick.Service.Interfaces
{
    public interface IUserService : ICRUDService<Model.User, UserSearchObject, UserInsertRequest, UserUpdateRequest>, IJWTService
    {
        User Login(string username, string password);
        User ProfileUpdate(int id, ProfileUpdateRequest req);
        User UpdateUserAccount(int id, AdminUserUpdate req);
    }
}
