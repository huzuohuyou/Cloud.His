using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using Capinfo.Authorization.Authoritys;
using Capinfo.Authorization.Users;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Capinfo.His
{
    public class MoudleGroupAppService : IMoudleGroupAppService
    {
        private readonly UserManager _userManager;
        public readonly IRepository<MouleGroup> _personRepository;

        public MoudleGroupAppService(IRepository<MouleGroup> repository, UserManager userManager)
        {
            _userManager = userManager;
            _personRepository = repository;
        }
        [HttpPost]
        public bool Create(MouleGroupDto dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MouleGroupDto, MouleGroup>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<MouleGroup>(dto);

            po.CreatorUserId = _userManager.UserId.Value;
            po.CreationTime = DateTime.Now;

            var ok = _personRepository.Insert(po) != null;
            return ok;
        }

    }
}
