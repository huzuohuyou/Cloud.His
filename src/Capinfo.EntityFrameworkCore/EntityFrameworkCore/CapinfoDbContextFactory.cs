using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Capinfo.Configuration;
using Capinfo.Web;

namespace Capinfo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CapinfoDbContextFactory : IDesignTimeDbContextFactory<CapinfoDbContext>
    {
        public CapinfoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CapinfoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CapinfoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CapinfoConsts.ConnectionStringName));

            return new CapinfoDbContext(builder.Options);
        }
    }
}
