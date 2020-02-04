using Xunit;

namespace Capinfo.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        public MultiTenantFactAttribute()
        {
            if (!CapinfoConsts.MultiTenancyEnabled)
            {
                Skip = "MultiTenancy is disabled.";
            }
        }
    }
}
