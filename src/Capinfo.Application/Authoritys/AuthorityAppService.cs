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
                    var c = MapToEntityDto(r);
                    tree.children.Add(CreateTree(authoritys, c));
                });
            }
            return tree;
        }
        List<AuthorityTreeDto> AllNodes = new List<AuthorityTreeDto>();
        private void GetAllNodes(List<AuthorityTreeDto> list)
        {
            list.ForEach(node =>
            {
                if (node.children.Count > 0)
                {
                    node.children.ForEach(r =>
                    {
                        GetAllNodes(node.children);
                    });
                }
                AllNodes.Add(node);
            });
        }

        protected  Authority MapToEntity(AuthorityTreeDto dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorityTreeDto, Authority>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<Authority>(dto);
            return po;
        }

        

        protected  AuthorityTreeDto MapToEntityDto(Authority po)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Authority, AuthorityTreeDto>());
            var mapper = config.CreateMapper();
            var dto = mapper.Map<AuthorityTreeDto>(po);
            return dto;
        }

        List<Authority>  authoritys =  new List<Authority> ();
        //List<Authority> authoritys = null;
        List<AuthorityTreeDto> globalResult = new List<AuthorityTreeDto>();
        public async Task<List<AuthorityTreeDto>> GetTree()
        {
            var moudlegroups = await _moudleGroupRepository.GetAllListAsync();
            moudlegroups.ForEach(r =>
            {
                var tree = new AuthorityTreeDto { title = r.GroupName, Id = r.Id };
                globalResult.Add(CreateTree(authoritys, tree));
            });
            return globalResult;
        }

        public async Task<List<AuthorityTreeDto>> GetMainMenu(string user)
        { return await GetTree(); }

        public async Task<PageDto<AuthorityTreeDto>> GetTreePage(string Keyword, int SkipCount, int MaxResultCount)
        {
            globalResult = await GetTree();
            var list = new List<AuthorityDto>();
            GetAllNodes(globalResult);

            //var moudlegroups = await _moudleGroupRepository.GetAllListAsync();
            //moudlegroups.ForEach(r =>
            //{
            //    var tree = new AuthorityTreeDto { title = r.GroupName, Id = r.Id };
            //    globalResult.Add(CreateTree(authoritys, tree));
            //});
            //List<AuthorityTreeDto> temp = null;
            ////return globalResult.Skip(SkipCount).Take(MaxResultCount).ToList();
            //if ((Keyword??"").Contains("#"))
            //{
            //    var father = int.Parse(Keyword.Replace("#", ""));
            //    temp = globalResult.Where(r => r.Father == father).ToList();
            //}
            var temp = AllNodes.Where(r => r.title==(Keyword ?? "")).ToList();
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

    }
}
