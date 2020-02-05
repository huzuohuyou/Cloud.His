using Abp.Domain.Repositories;
using AutoMapper;
using Capinfo.His.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [HttpPost]
        public bool AddRecord(QuestionDto dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDto, Questions>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<Questions>(dto);
            var ok = _personRepository.Insert(po) != null;
            return ok;
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

        [HttpGet]
        public QuestionDto GetQuestion(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Questions, QuestionDto>());
            var mapper = config.CreateMapper();

            var po = _personRepository.Get(id);
            var dto = mapper.Map<QuestionDto>(po);
            return dto;
        }

        public List<QuestionDto> GetThisWeekQuestion()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Questions, QuestionDto>());
            var mapper = config.CreateMapper();

            List<QuestionDto> resultSet = new List<QuestionDto>();
            List<Questions> people = _personRepository.GetAll().ToList().Where(r => r.Date.DayOfWeek == DateTime.Now.DayOfWeek).ToList();//.OrderBy(r=>r.Date).ToList();//.GetAllPatient();
            foreach (Questions item in people)
            {
                var dto = mapper.Map<QuestionDto>(item);
                resultSet.Add(dto);
            }
            return resultSet;
        }

        [HttpPost]
        public List<QuestionDto> SearchQuestion(QuestionFilterDto questionFilter)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Questions, QuestionDto>());
            var mapper = config.CreateMapper();

            List<QuestionDto> resultSet = new List<QuestionDto>();
            List<Questions> questions = _personRepository
                .GetAll().ToList().Where(
                r => r
                .GetType()
                .GetProperty(questionFilter.Select)
                .GetValue(r)
                .ToString()
                .Contains(questionFilter.Value)).ToList();//.GetAllPatient();
            foreach (Questions item in questions)
            {
                var dto = mapper.Map<QuestionDto>(item);
                resultSet.Add(dto);
            }
            return resultSet;
        }

        [HttpPost]
        public bool UpdateRecord(QuestionDto dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDto, Questions>());
            var mapper = config.CreateMapper();
            var po = mapper.Map<Questions>(dto);
            var ok = _personRepository.Update(po);

            return ok != null;
        }
    }
}
