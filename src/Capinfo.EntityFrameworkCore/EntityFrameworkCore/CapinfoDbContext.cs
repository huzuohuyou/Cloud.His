using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Capinfo.Authorization.Roles;
using Capinfo.Authorization.Users;
using Capinfo.MultiTenancy;
using Capinfo.His;
using Capinfo.Authorization.Authoritys;

namespace Capinfo.EntityFrameworkCore
{
    public class CapinfoDbContext : AbpZeroDbContext<Tenant, Role, User, CapinfoDbContext>
    {
        public DbSet<AuthorityRole> AbpAuthorityRoles { get; set; }
        public DbSet<Authority> AbpAuthoritys { get; set; }
        /* Define a DbSet for each entity of the application */
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public CapinfoDbContext(DbContextOptions<CapinfoDbContext> options)
            : base(options)
        {
        }
    }
}
