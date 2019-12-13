using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Capinfo.Controllers
{
    public abstract class CapinfoControllerBase: AbpController
    {
        protected CapinfoControllerBase()
        {
            LocalizationSourceName = CapinfoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
