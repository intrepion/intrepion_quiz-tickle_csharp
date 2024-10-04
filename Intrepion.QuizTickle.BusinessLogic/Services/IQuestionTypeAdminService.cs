using Intrepion.QuizTickle.BusinessLogic.Entities;
using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

namespace Intrepion.QuizTickle.BusinessLogic.Services;

public interface IQuestionTypeAdminService
{
    Task<QuestionTypeAdminDto?> AddAsync(QuestionTypeAdminDto questionType);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<QuestionTypeAdminDto?> EditAsync(QuestionTypeAdminDto questionType);
    Task<List<QuestionType>?> GetAllAsync(string userName);
    Task<QuestionTypeAdminDto?> GetByIdAsync(string userName, Guid id);
}
