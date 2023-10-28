using AdventuraClick.Service.Database;
using Microsoft.EntityFrameworkCore;

namespace AdventuraClick.DatabaseSeed
{
    public class DbHelper
    {
        public void Init(AdventuraClickInitContext context)
        {
            context.Database.Migrate();
        }

        public void InsertData(AdventuraClickInitContext context)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Database seed", "adventuraClick.sql");
            var query = File.ReadAllText(path);
            context.Database.ExecuteSqlRaw(query);
        }
    }
}