using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class QuizAdminService(ApplicationDbContext applicationDbContext) : IQuizAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<QuizAdminDto?> AddAsync(QuizAdminDto quizAdminDto)
    {
        if (string.IsNullOrWhiteSpace(quizAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => quizAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(quizAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var quiz = QuizAdminDto.ToQuiz(user, quizAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.TableNamePlaceholder.AddAsync(quiz);
        var databaseQuizAdminDto = QuizAdminDto.FromQuiz(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseQuizAdminDto;
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseQuiz = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (databaseQuiz == null)
        {
            return false;
        }

        databaseQuiz.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseQuiz);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<QuizAdminDto?> EditAsync(QuizAdminDto quizAdminDto)
    {
        if (string.IsNullOrWhiteSpace(quizAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => quizAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseQuiz = await _applicationDbContext.TableNamePlaceholder.FindAsync(quizAdminDto.Id);

        if (databaseQuiz == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(quizAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseQuiz.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder
        // databaseQuiz.Title = quizAdminDto.Title;
        // databaseQuiz.NormalizedTitle = quizAdminDto.Title.ToUpperInvariant();
        // databaseQuiz.ToDoList = quizAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return quizAdminDto;
    }

    public async Task<List<Quiz>?> GetAllAsync(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        return await _applicationDbContext.TableNamePlaceholder.ToListAsync();
    }

    public async Task<QuizAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var result = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return QuizAdminDto.FromQuiz(result);
    }
}
