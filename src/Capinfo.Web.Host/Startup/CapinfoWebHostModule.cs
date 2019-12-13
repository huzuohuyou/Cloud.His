using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Capinfo.Configuration;

namespace Capinfo.Web.Host.Startup
{
    [DependsOn(
       typeof(CapinfoWebCoreModule))]
    public class CapinfoWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CapinfoWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CapinfoWebHostModule).GetAssembly());
        }
    }
}
