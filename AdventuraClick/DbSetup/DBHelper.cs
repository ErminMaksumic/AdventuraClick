using AdventuraClick.Service.Database;
using Microsoft.EntityFrameworkCore;

namespace TheLionsDen.DbSetup
{
    public class DbHelper
    {
        public void Init(AdventuraClickInitContext context)
        {
            context.Database.Migrate();
        }
    }
}