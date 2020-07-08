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
        public readonly IRepository<MoudleGroup> _personRepository;

        public MoudleGroupAppService(IRepository<MoudleGroup> repository, UserManager userManager)
        {
            _userManager = userManager;
            _personRepository = repository;
        }
        [HttpPost]
        public bool Create(MoudleGroupDto dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MoudleGroupDto, MoudleGroup>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<MoudleGroup>(dto);

            po.CreatorUserId = _userManager.UserId.Value;
            po.CreationTime = DateTime.Now;

            var ok = _personRepository.Insert(po) != null;
            return ok;
        }

    }
}
