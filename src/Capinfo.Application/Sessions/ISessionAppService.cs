using System.Threading.Tasks;
using Abp.Application.Services;
using Capinfo.Sessions.Dto;

namespace Capinfo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
