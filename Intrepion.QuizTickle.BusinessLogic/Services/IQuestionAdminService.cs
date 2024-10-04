using Intrepion.QuizTickle.BusinessLogic.Entities;
using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

namespace Intrepion.QuizTickle.BusinessLogic.Services;

public interface IQuestionAdminService
{
    Task<QuestionAdminDto?> AddAsync(QuestionAdminDto question);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<QuestionAdminDto?> EditAsync(QuestionAdminDto question);
    Task<List<Question>?> GetAllAsync(string userName);
    Task<QuestionAdminDto?> GetByIdAsync(string userName, Guid id);
}
