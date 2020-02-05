using Abp.Application.Services;
using Capinfo.His.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.His
{
    public interface IQuestionAppService : IApplicationService
    {
        List<QuestionDto> GetAllQuestion();

        List<QuestionDto> GetThisWeekQuestion();

        bool AddRecord(QuestionDto dto);

        QuestionDto GetQuestion(int id);

        bool UpdateRecord(QuestionDto dto);

        List<QuestionDto> SearchQuestion(QuestionFilterDto dto);
    }
}
