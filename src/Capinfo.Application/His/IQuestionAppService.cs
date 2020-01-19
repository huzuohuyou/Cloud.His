using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.His
{
    public interface IQuestionAppService : IApplicationService
    {
        List<QuestionDto> GetAllQuestion();

        bool AddRecord(QuestionDto dto);

        QuestionDto GetQuestion(int id);

        bool UpdateRecord(QuestionDto dto);
    }
}
