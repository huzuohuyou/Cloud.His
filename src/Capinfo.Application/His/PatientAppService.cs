using Abp.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capinfo.His
{
    public class PatientAppService: IPatientAppService
    {
        //通过构造函数注入IPersonRepository，也可通过属性注入，详情查看学习资料或官方文档
        public readonly IRepository<Patient> _personRepository;

        public PatientAppService(IRepository<Patient> repository)
         {
            _personRepository = repository;
         }
    //实现接口中的方法
    public List<PatientDto> GetAllPatient()
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDto>());
            var mapper = config.CreateMapper();
            

            List<PatientDto> resultSet = new List<PatientDto>();
            List<Patient> people = _personRepository.GetAll().ToList();//.GetAllPatient();
            foreach (Patient item in people)
            {
                var dto = mapper.Map<PatientDto>(item);
                resultSet.Add(dto);
            }
            return resultSet;
        }

    }
}
