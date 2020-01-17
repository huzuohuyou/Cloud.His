using Abp.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capinfo.His
{
    public class QuestionAppService : IQuestionAppService
    {
        //通过构造函数注入IPersonRepository，也可通过属性注入，详情查看学习资料或官方文档
        public readonly IRepository<Questions> _personRepository;

        public QuestionAppService(IRepository<Questions> repository)
         {
            _personRepository = repository;
         }
    //实现接口中的方法
    public List<QuestionDto> GetAllQuestion()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Questions, QuestionDto>());
            var mapper = config.CreateMapper();

            List<QuestionDto> resultSet = new List<QuestionDto>();
            List<Questions> people = _personRepository.GetAll().ToList();//.GetAllPatient();
            foreach (Questions item in people)
            {
                var dto = mapper.Map<QuestionDto>(item);
                resultSet.Add(dto);
            }
            return resultSet;
        }

    }
}
