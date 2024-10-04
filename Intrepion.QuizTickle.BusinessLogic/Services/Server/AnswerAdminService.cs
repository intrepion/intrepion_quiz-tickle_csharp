using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class AnswerAdminService(ApplicationDbContext applicationDbContext) : IAnswerAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<AnswerAdminDto?> AddAsync(AnswerAdminDto answerAdminDto)
    {
        if (string.IsNullOrWhiteSpace(answerAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => answerAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(answerAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var answer = AnswerAdminDto.ToAnswer(user, answerAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.TableNamePlaceholder.AddAsync(answer);
        var databaseAnswerAdminDto = AnswerAdminDto.FromAnswer(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseAnswerAdminDto;
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

        var databaseAnswer = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (databaseAnswer == null)
        {
            return false;
        }

        databaseAnswer.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseAnswer);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<AnswerAdminDto?> EditAsync(AnswerAdminDto answerAdminDto)
    {
        if (string.IsNullOrWhiteSpace(answerAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => answerAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseAnswer = await _applicationDbContext.TableNamePlaceholder.FindAsync(answerAdminDto.Id);

        if (databaseAnswer == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(answerAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseAnswer.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder
        // databaseAnswer.Title = answerAdminDto.Title;
        // databaseAnswer.NormalizedTitle = answerAdminDto.Title.ToUpperInvariant();
        // databaseAnswer.ToDoList = answerAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return answerAdminDto;
    }

    public async Task<List<Answer>?> GetAllAsync(string userName)
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

    public async Task<AnswerAdminDto?> GetByIdAsync(string userName, Guid id)
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

        return AnswerAdminDto.FromAnswer(result);
    }
}
