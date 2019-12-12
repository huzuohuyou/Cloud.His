using Abp.Authorization;
using Capinfo.Authorization.Roles;
using Capinfo.Authorization.Users;

namespace Capinfo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
