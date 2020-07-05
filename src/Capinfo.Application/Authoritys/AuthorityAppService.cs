using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using Capinfo.Authorization.Authoritys;
using Capinfo.Authorization.Users;
using Capinfo.His.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Capinfo.His.Questions;

namespace Capinfo.His
{
    public class AuthorityAppService : IAuthorityAppService
    {
        private readonly UserManager _userManager;
        //public IAbpSession AbpSession { get; set; }
        ////通过构造函数注入IPersonRepository，也可通过属性注入，详情查看学习资料或官方文档
        public readonly IRepository<Authority> _personRepository;

        public AuthorityAppService(IRepository<Authority> repository, UserManager userManager)
        {
            _userManager = userManager;
            _personRepository = repository;
            //AbpSession = NullAbpSession.Instance;
        }
       
    }
}
