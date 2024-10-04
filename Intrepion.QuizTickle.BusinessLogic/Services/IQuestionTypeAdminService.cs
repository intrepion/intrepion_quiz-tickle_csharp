using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IQuestionTypeAdminService
{
    Task<QuestionTypeAdminDto?> AddAsync(QuestionTypeAdminDto questionType);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<QuestionTypeAdminDto?> EditAsync(QuestionTypeAdminDto questionType);
    Task<List<QuestionType>?> GetAllAsync(string userName);
    Task<QuestionTypeAdminDto?> GetByIdAsync(string userName, Guid id);
}
