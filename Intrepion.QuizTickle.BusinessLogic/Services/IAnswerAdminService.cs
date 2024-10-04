using Intrepion.QuizTickle.BusinessLogic.Entities;
using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

namespace Intrepion.QuizTickle.BusinessLogic.Services;

public interface IAnswerAdminService
{
    Task<AnswerAdminDto?> AddAsync(AnswerAdminDto answer);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<AnswerAdminDto?> EditAsync(AnswerAdminDto answer);
    Task<List<Answer>?> GetAllAsync(string userName);
    Task<AnswerAdminDto?> GetByIdAsync(string userName, Guid id);
}
