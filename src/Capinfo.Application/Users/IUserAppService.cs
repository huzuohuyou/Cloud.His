using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Capinfo.Roles.Dto;
using Capinfo.Users.Dto;

namespace Capinfo.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
