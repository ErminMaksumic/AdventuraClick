using AdventuraClick.Model;

namespace AdventuraClick.Service.Interfaces
{
    public interface IJWTService
    {
        string GenerateToken(User user);
    }
}
