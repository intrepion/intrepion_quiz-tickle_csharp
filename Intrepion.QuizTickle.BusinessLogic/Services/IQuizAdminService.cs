using Intrepion.QuizTickle.BusinessLogic.Entities;
using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

namespace Intrepion.QuizTickle.BusinessLogic.Services;

public interface IQuizAdminService
{
    Task<QuizAdminDto?> AddAsync(QuizAdminDto quiz);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<QuizAdminDto?> EditAsync(QuizAdminDto quiz);
    Task<List<Quiz>?> GetAllAsync(string userName);
    Task<QuizAdminDto?> GetByIdAsync(string userName, Guid id);
}
