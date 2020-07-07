using Abp.Application.Services;
using Abp.Domain.Repositories;
using Capinfo.Authorization.Authoritys;

namespace Capinfo.His
{
    public class MouleGroupAppService : CrudAppService<MouleGroup, MouleGroupDto>, IMouleGroupAppService
    {
        public MouleGroupAppService(IRepository<MouleGroup, int> repository)
            :base(repository)
        {
            
        }

       
    }
}
