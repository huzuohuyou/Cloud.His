using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using Capinfo.Authorization.Authoritys;
using Capinfo.Authorization.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capinfo.His
{
    public class AuthorityAppService : IAuthorityAppService
    {
        private readonly UserManager _userManager;
        //public IAbpSession AbpSession { get; set; }
        ////通过构造函数注入IPersonRepository，也可通过属性注入，详情查看学习资料或官方文档
        public readonly IRepository<Authority> _authorityRepository;
        public readonly IRepository<MoudleGroup> _moudleGroupRepository;

        public AuthorityAppService(IRepository<Authority> repository, IRepository<MoudleGroup> repository2, UserManager userManager)
        {
            _userManager = userManager;
            _authorityRepository = repository;
            _moudleGroupRepository = repository2;
            authoritys = _authorityRepository.GetAllList();
        }
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Authority, AuthorityDto>()).CreateMapper();
        private AuthorityTreeDto CreateTree(List<Authority> list, AuthorityTreeDto tree)
        {
            var temp = list.Where(r => r.Father == tree.Id).ToList();
            if (temp.Count == 0)
            {
               return tree;
            }
            else
            {
                
                temp.ForEach(r =>
                {
                    var c = new AuthorityTreeDto { title = r.Title, Id = r.Id };
                    tree.children.Add(CreateTree(authoritys, c));
                });
            }
            return tree;
        }
        List<Authority>  authoritys =  new List<Authority> ();
        //List<Authority> authoritys = null;
        List<AuthorityTreeDto> result = new List<AuthorityTreeDto>();
        public async Task<List<AuthorityTreeDto>> GetAll()
        {
            
            var moudlegroups = await _moudleGroupRepository.GetAllListAsync();
            moudlegroups.ForEach(r =>
            {
                var tree = new AuthorityTreeDto { title = r.GroupName, Id = r.Id };
                result.Add(CreateTree(authoritys, tree));
            });
            return result;
        }
    }
}
