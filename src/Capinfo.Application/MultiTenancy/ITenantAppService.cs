using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Capinfo.MultiTenancy.Dto;

namespace Capinfo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

