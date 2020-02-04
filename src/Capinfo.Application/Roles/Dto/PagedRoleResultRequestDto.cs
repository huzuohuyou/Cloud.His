using Abp.Application.Services.Dto;

namespace Capinfo.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

