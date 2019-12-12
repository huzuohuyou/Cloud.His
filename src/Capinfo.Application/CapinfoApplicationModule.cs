﻿using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Capinfo.Authorization;

namespace Capinfo
{
    [DependsOn(
        typeof(CapinfoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CapinfoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CapinfoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CapinfoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
