using System.Collections.Generic;

namespace Capinfo.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
