using Intrepion.QuizTickle.BusinessLogic.Entities;
using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

namespace Intrepion.QuizTickle.BusinessLogic.Services;

public interface IApplicationRoleAdminService
{
    Task<ApplicationRoleAdminDto?> AddAsync(ApplicationRoleAdminDto applicationRoleAdminDto);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ApplicationRoleAdminDto?> EditAsync(ApplicationRoleAdminDto applicationRoleAdminDto);
    Task<List<ApplicationRole>?> GetAllAsync(string userName);
    Task<ApplicationRoleAdminDto?> GetByIdAsync(string userName, Guid id);
}
