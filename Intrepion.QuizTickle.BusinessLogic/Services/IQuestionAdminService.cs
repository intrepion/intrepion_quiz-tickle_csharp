using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IQuestionAdminService
{
    Task<QuestionAdminDto?> AddAsync(QuestionAdminDto question);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<QuestionAdminDto?> EditAsync(QuestionAdminDto question);
    Task<List<Question>?> GetAllAsync(string userName);
    Task<QuestionAdminDto?> GetByIdAsync(string userName, Guid id);
}
