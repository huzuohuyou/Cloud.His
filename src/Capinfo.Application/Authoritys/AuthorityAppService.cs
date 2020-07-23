using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AutoMapper;
using Capinfo.Authoritys.Dto;
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
        List<AuthorityTreeDto> globalResult = new List<AuthorityTreeDto>();
        List<Authority> authoritys = new List<Authority>();
        private readonly UserManager _userManager;
        ////通过构造函数注入IPersonRepository，也可通过属性注入，详情查看学习资料或官方文档
        public readonly IRepository<Authority> _authorityRepository;
        public readonly IRepository<AuthorityRole> _authorityRoleRepository;

        public AuthorityAppService(
            IRepository<Authority> repository
            , IRepository<AuthorityRole> urepository
            , UserManager userManager)
        {
            _userManager = userManager;
            _authorityRepository = repository;
            _authorityRoleRepository = urepository;
            authoritys = _authorityRepository.GetAllList();
        }

       

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
        MapperConfiguration entityConfig = new MapperConfiguration(cfg => cfg.CreateMap<AuthorityTreeDto, Authority>());

        protected Authority MapToEntity(AuthorityTreeDto dto)
        {
            var mapper = entityConfig.CreateMapper();
            var po = mapper.Map<Authority>(dto);
            return po;
        }


        MapperConfiguration dtoConfig = new MapperConfiguration(cfg => cfg.CreateMap<Authority, AuthorityTreeDto>());

        protected AuthorityTreeDto MapToEntityDto(Authority po)
        {
            var mapper = dtoConfig.CreateMapper();
            var dto = mapper.Map<AuthorityTreeDto>(po);
            return dto;
        }



        public async Task<List<AuthorityTreeDto>> GetTree()
        {
            var result = new List<AuthorityTreeDto>();
            var authoritys=await _authorityRepository.GetAllListAsync();
            var roots = authoritys.Where(r => r.Father == null);
            roots.ToList().ForEach(r =>
            {
                var tree = MapToEntityDto(r);
                result.Add(CreateTree(authoritys, tree));
            });
            return result;
        }

        private void SetChecked(AuthorityTreeDto AuthorityTree, List<AuthorityRole> RoleAuthoritys)
        {
            if (RoleAuthoritys.Count(s => s.AuthorityId == AuthorityTree.Id) > 0)
            {
                AuthorityTree.Checked = true;
            }
            if (AuthorityTree.children.Count > 0)
            {
                AuthorityTree.children.ForEach(r =>
                {
                    SetChecked(r, RoleAuthoritys);
                });
            }
        }
        public async Task<List<AuthorityTreeDto>> GetRolePermissions(int RoleId)
        {
            var result = new List<AuthorityTreeDto>();
            var roleAuthoritys = await _authorityRoleRepository.GetAllListAsync(r => r.RoleId == RoleId);
            var authoritys = await _authorityRepository.GetAllListAsync();
            var roots = authoritys.Where(r => r.Father == null);
            roots.ToList().ForEach(r =>
            {
                var tree = MapToEntityDto(r);
                result.Add(CreateTree(authoritys, tree));
            });
            result.ForEach(r=> {
                SetChecked(r, roleAuthoritys);
            });
            return result;
            //var roleResult = new List<AuthorityTreeDto>();
            //var roleAuthoritys= await _authorityRoleRepository.GetAllListAsync(r => r.RoleId == input.Id);
            //var mainAuthoritys = await _authorityRepository.GetAllListAsync(r => r.Father == null);

            //mainAuthoritys.ForEach(r =>
            //{
            //    var tree = MapToEntityDto(r);
            //    if (roleAuthoritys.Count(s=>s.AuthorityId==r.Id)>0)
            //    {
            //        tree.expand = true;
            //    }
            //    roleResult.Add(CreateTree(authoritys, tree));
            //});
            //return roleResult;
        }

        public async Task<List<AuthorityTreeDto>> GetContinerMenu(long father)
        {
            var continerlResult = new List<AuthorityTreeDto>();
            var continerAuthoritys = await _authorityRepository.GetAllListAsync(r => r.Father == father);
            continerAuthoritys.ForEach(r =>
            {
                continerlResult.Add(CreateTree(authoritys, MapToEntityDto(r)));
            });
            return continerlResult;
        }


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
            var po = MapToEntity(dto);
            po.CreatorUserId = _userManager.UserId.Value;
            po.CreationTime = DateTime.Now;

            var ok = _authorityRepository.Insert(po) != null;
            return ok;
        }

        
        [HttpPost]
        public async Task<bool> SetRolePermissions(UserAuthorityTreeDto input)
        {
            var oldRoleAuthoritys = await _authorityRoleRepository.GetAllListAsync(r => r.RoleId == input.RoleId);
            var newRoleAuthoritys =  input.Authoritys.ToList().Select(s => new AuthorityRole
            {
                RoleId = input.RoleId,
                AuthorityId = s.Id,
            }).ToList();
            bool ok = true;
            
            var deleteList = oldRoleAuthoritys.Except(newRoleAuthoritys);
            var addList = newRoleAuthoritys.Except(oldRoleAuthoritys);
            //新权限插入
            addList.ToList().ForEach(po =>
            {
                po.CreatorUserId = _userManager.UserId.Value;
                po.CreationTime = DateTime.Now;
                newRoleAuthoritys.Add(po);
                ok = ok && _authorityRoleRepository.Insert(po) != null;
            });
            //老权限删除
            deleteList.ToList().ForEach(po =>
            {
                po.CreatorUserId = _userManager.UserId.Value;
                po.CreationTime = DateTime.Now;
                newRoleAuthoritys.Add(po);
                _authorityRoleRepository.Delete(po) ;
            });
            return ok;
        }

        [HttpPut]
        public bool Update(AuthorityTreeDto dto)
        {

            var po = MapToEntity(dto);
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
