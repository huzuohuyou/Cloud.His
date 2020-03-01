using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Capinfo.Authorization.Roles;
using Abp.Threading;

namespace Capinfo.Authorization.Users
{
    public class UserManager : AbpUserManager<Role, User>
    {
        public UserManager(
            RoleManager roleManager,
            UserStore store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<User> passwordHasher, 
            IEnumerable<IUserValidator<User>> userValidators, 
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<User>> logger, 
            IPermissionManager permissionManager, 
            IUnitOfWorkManager unitOfWorkManager, 
            ICacheManager cacheManager, 
            IRepository<OrganizationUnit, long> organizationUnitRepository, 
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, 
            IOrganizationUnitSettings organizationUnitSettings, 
            ISettingManager settingManager)
            : base(
                roleManager, 
                store, 
                optionsAccessor, 
                passwordHasher, 
                userValidators, 
                passwordValidators, 
                keyNormalizer, 
                errors, 
                services, 
                logger, 
                permissionManager, 
                unitOfWorkManager, 
                cacheManager,
                organizationUnitRepository, 
                userOrganizationUnitRepository, 
                organizationUnitSettings, 
                settingManager)
        {
        }

        private static Dictionary<long?, User> dict;//保存用户信息，减少请求次数

        /// <summary>
        /// 保存登录用户信息
        /// </summary>
        /// <param name="user"></param>
        public void SaveUserToCache(User user)
        {
            if (dict == null) dict = new Dictionary<long?, User>();
            if (!dict.ContainsKey(user.Id))
            {
                dict.Add(user.Id, user);
            }
        }

        /// <summary>
        /// 获取当前登录用户信息
        /// </summary>
        /// <returns></returns>
        public User GetUser()
        {
            var userId = AbpSession.UserId;
            if (dict != null && dict.ContainsKey(userId))
                return dict[userId];

            var user = AsyncHelper.RunSync(() => GetUserByIdAsync(userId.Value));
            SaveUserToCache(user);

            return user;
        }

        /// <summary>
        /// 获取登录用户标识
        /// </summary>
        public long? UserId { get { return AbpSession.UserId; } }

        /// <summary>
        /// 获取登录用户名
        /// </summary>
        /// <returns></returns>
        public string UserName { get { return GetUser()?.UserName; } }
    }
}
