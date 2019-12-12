using System.Threading.Tasks;
using Abp.Application.Services;
using Capinfo.Authorization.Accounts.Dto;

namespace Capinfo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
