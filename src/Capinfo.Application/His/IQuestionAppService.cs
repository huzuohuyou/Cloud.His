using Abp.Application.Services;
using Capinfo.His.Dto;
using System.Collections.Generic;

namespace Capinfo.His
{
    public interface IQuestionAppService : IApplicationService
    {
        PageDto<QuestionDto> GetAllQuestion(string Keyword, int SkipCount, int MaxResultCount, string userId);

        WeekRecordDto GetThisWeekQuestion(bool week);

        bool AddRecord(QuestionDto dto);

        QuestionDto GetQuestion(int id);

        bool UpdateRecord(QuestionDto dto);

        List<QuestionDto> SearchQuestion(QuestionFilterDto dto);
    }
}
