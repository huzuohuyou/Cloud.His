using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using Capinfo.Authorization.Authoritys;
using Capinfo.Authorization.Users;
using Capinfo.His.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
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
        //public readonly IRepository<MoudleGroup> _moudleGroupRepository;

        public AuthorityAppService(IRepository<Authority> repository, UserManager userManager)
        {
            _userManager = userManager;
            _authorityRepository = repository;
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
                    var c = MapToEntityDto(r);
                    tree.children.Add(CreateTree(authoritys, c));
                });
            }
            return tree;
        }
        List<AuthorityTreeDto> AllNodes = new List<AuthorityTreeDto>();
        private AuthorityTreeDto GetAllNodes(AuthorityTreeDto node)
        {
            if (node.children.Count == 0)
            {
                AllNodes.Add(node);
            }
            else
            {
                AllNodes.Add(node);
                node.children.ForEach(r =>
                {
                    GetAllNodes(r);
                });
            }
            return node;
        }

        protected Authority MapToEntity(AuthorityTreeDto dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorityTreeDto, Authority>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<Authority>(dto);
            return po;
        }



        protected AuthorityTreeDto MapToEntityDto(Authority po)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Authority, AuthorityTreeDto>());
            var mapper = config.CreateMapper();
            var dto = mapper.Map<AuthorityTreeDto>(po);
            return dto;
        }

        List<Authority> authoritys = new List<Authority>();
        //List<Authority> authoritys = null;
        List<AuthorityTreeDto> globalResult = new List<AuthorityTreeDto>();
        public async Task<List<AuthorityTreeDto>> GetTree()
        {
            var mainAuthoritys = await _authorityRepository.GetAllListAsync(r => r.Father == null);
            mainAuthoritys.ForEach(r =>
            {
                var tree = new AuthorityTreeDto { title = r.Title, Id = r.Id, Icon = r.Icon };
                globalResult.Add(CreateTree(authoritys, tree));
            });
            return globalResult;
        }

        public async Task<List<AuthorityTreeDto>> GetContinerMenu(long father)
        {
            var continerlResult = new List<AuthorityTreeDto>();
            var continerAuthoritys = await _authorityRepository.GetAllListAsync(r => r.Father == father);
            continerAuthoritys.ForEach(r =>
            {
                continerlResult.Add(CreateTree(authoritys, new AuthorityTreeDto { title = r.Title, Id = r.Id, Icon = r.Icon, ComponentName = r.ComponentName }));
            });
            return continerlResult;
        }

        //public async Task<List<AuthorityTreeDto>> GetRouters()
        //{
        //    var continerlResult = new List<AuthorityTreeDto>();
        //    var continerAuthoritys = await _authorityRepository.GetAllListAsync(r => r.Continer == "SettingContiner");
        //    continerAuthoritys.Where(r => (r.Path
        //    ?? "") == "").ToList().ForEach(r =>
        //    {
        //        continerlResult.Add(CreateTree(authoritys, new AuthorityTreeDto { title = r.Title, Id = r.Id, Icon = r.Icon }));
        //    });
        //    return continerlResult;
        //}

        public async Task<List<AuthorityTreeDto>> GetMainMenu(string user)
        { return await GetTree(); }

        public async Task<PageDto<AuthorityTreeDto>> GetTreePage(string Keyword, int SkipCount, int MaxResultCount)
        {
            globalResult = await GetTree();
            var list = new List<AuthorityDto>();
            globalResult.ForEach(r =>
            {
                GetAllNodes(r);
            });

            var temp = AllNodes.Where(r => r.title.Contains(Keyword ?? "")).ToList();
            return new PageDto<AuthorityTreeDto>
            {
                totalCount = temp.Count,
                items = temp.Skip(SkipCount).Take(MaxResultCount).ToArray()
            };
        }

        [HttpPost]
        public bool Create(AuthorityTreeDto dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorityTreeDto, Authority>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<Authority>(dto);

            po.CreatorUserId = _userManager.UserId.Value;
            po.CreationTime = DateTime.Now;

            var ok = _authorityRepository.Insert(po) != null;
            return ok;
        }

        [HttpPut]
        public bool Update(AuthorityTreeDto dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorityTreeDto, Authority>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<Authority>(dto);
            var ok = _authorityRepository.Update(po);

            return ok != null;
        }

        [HttpPost]
        public bool CreateRoot(AuthorityTreeDto dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorityTreeDto, Authority>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<Authority>(dto);

            po.CreatorUserId = _userManager.UserId.Value;
            po.CreationTime = DateTime.Now;

            var ok = _authorityRepository.Insert(po) != null;
            return ok;
        }

        [HttpDelete]
        public async Task DeleteAsync(EntityDto<int> input)
        {
            var po = await _authorityRepository.GetAsync(input.Id);
            await _authorityRepository.DeleteAsync(po);
        }

    }
}
