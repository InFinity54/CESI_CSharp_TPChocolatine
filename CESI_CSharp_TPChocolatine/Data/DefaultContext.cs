using Microsoft.EntityFrameworkCore;
using CESI_CSharp_TPChocolatine.Models;

namespace CESI_CSharp_TPChocolatine.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext (DbContextOptions<DefaultContext> options)
            : base(options)
        {
        }

        public DbSet<Region> Region { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<CESI_CSharp_TPChocolatine.Models.Expression> Expression { get; set; }

        public DbSet<CESI_CSharp_TPChocolatine.Models.Vote> Vote { get; set; }
    }
}
