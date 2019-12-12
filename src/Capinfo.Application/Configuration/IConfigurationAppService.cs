using System.Threading.Tasks;
using Capinfo.Configuration.Dto;

namespace Capinfo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
