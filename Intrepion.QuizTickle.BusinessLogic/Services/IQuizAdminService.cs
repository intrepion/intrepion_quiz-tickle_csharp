using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IQuizAdminService
{
    Task<QuizAdminDto?> AddAsync(QuizAdminDto quiz);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<QuizAdminDto?> EditAsync(QuizAdminDto quiz);
    Task<List<Quiz>?> GetAllAsync(string userName);
    Task<QuizAdminDto?> GetByIdAsync(string userName, Guid id);
}
