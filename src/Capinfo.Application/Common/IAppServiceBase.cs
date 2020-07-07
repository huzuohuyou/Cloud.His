using Abp.Application.Services.Dto;
using Capinfo.His.Dto;
using System.Threading.Tasks;

namespace Capinfo.Common
{
    public interface IAppServiceBase<TEntity, TEntityDto, TPrimaryKey> where TEntity : class
    {
        TEntityDto GetbyPrimaryKey(TPrimaryKey primaryKey);
        TEntityDto GetbyEntity(TEntityDto entity);
        Task DeleteAsync(EntityDto<int> input);
        bool DeletebyPrimaryKey(TPrimaryKey primaryKey);
        PageDto<TEntityDto> GetAll(string Keyword, int SkipCount, int MaxResultCount, string userId = "0");
        bool Update(TEntityDto dto);
        bool Create(TEntityDto dto);
    }
}
