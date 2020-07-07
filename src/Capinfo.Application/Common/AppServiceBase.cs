using Abp;
using Abp.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.Common
{
    public abstract class AppServiceBase<TEntity, TEntityDto, TPrimaryKey> 
    {
        public readonly IRepository<TEntity> _personRepository;
        public TEntityDto GetbyPrimaryKey(TPrimaryKey primaryKey) {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TEntityDto>());
            var mapper = config.CreateMapper();

            var po = _personRepository.Get(primaryKey);
            var dto = mapper.Map<TEntityDto>(po);
            return dto;
        }
        TEntityDto GetbyEntity(TEntityDto entity);
        Task DeleteAsync(EntityDto<int> input);
        bool DeletebyPrimaryKey(TPrimaryKey primaryKey);
        PageDto<TEntityDto> GetAll(string Keyword, int SkipCount, int MaxResultCount, string userId = "0");
        bool Update(TEntityDto dto);
        bool Create(TEntityDto dto);
    }

    
}
