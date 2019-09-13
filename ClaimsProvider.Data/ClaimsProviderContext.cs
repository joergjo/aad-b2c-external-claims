using Microsoft.EntityFrameworkCore;
using System;

namespace ClaimsProvider.Data
{
    public class ClaimsProviderContext : DbContext
    {
        public ClaimsProviderContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
