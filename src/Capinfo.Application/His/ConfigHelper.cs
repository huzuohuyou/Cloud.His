using Capinfo.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.His
{
    public static class ConfigHelper
    {
        private static IConfigurationRoot _appConfiguration = AppConfigurations.Get(System.Environment.CurrentDirectory);

        //用法1(有嵌套)：GetAppSetting("Authentication", "JwtBearer:SecurityKey")
        //用法2：GetAppSetting("App", "ServerRootAddress")
        public static string GetAppSetting(string section, string key)
        {
            return _appConfiguration.GetSection(section)[key];
        }

        public static string GetConnectionString(string key)
        {
            return _appConfiguration.GetConnectionString(key);
        }


    }
}
