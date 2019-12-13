using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Capinfo.EntityFrameworkCore
{
    public static class CapinfoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CapinfoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CapinfoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
