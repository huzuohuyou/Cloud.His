using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Capinfo.Authorization.Roles;
using Capinfo.Authorization.Users;
using Capinfo.MultiTenancy;

namespace Capinfo.EntityFrameworkCore
{
    public class CapinfoDbContext : AbpZeroDbContext<Tenant, Role, User, CapinfoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CapinfoDbContext(DbContextOptions<CapinfoDbContext> options)
            : base(options)
        {
        }
    }
}
