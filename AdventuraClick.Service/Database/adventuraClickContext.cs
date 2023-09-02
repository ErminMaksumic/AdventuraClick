using AdventuraClick.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventuraClick.Service.Database
{
    public class AdventuraClickContext : DbContext
    {
        public AdventuraClickContext(DbContextOptions<AdventuraClickContext> options) : base(options)
        {}
        public DbSet<Role> Roles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}
    }
}

