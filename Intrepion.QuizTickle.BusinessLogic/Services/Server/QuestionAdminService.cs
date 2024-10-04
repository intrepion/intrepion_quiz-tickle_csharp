using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class QuestionAdminService(ApplicationDbContext applicationDbContext) : IQuestionAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<QuestionAdminDto?> AddAsync(QuestionAdminDto questionAdminDto)
    {
        if (string.IsNullOrWhiteSpace(questionAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => questionAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(questionAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var question = QuestionAdminDto.ToQuestion(user, questionAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.Questions.AddAsync(question);
        var databaseQuestionAdminDto = QuestionAdminDto.FromQuestion(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseQuestionAdminDto;
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

        var databaseQuestion = await _applicationDbContext.Questions.FindAsync(id);

        if (databaseQuestion == null)
        {
            return false;
        }

        databaseQuestion.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseQuestion);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<QuestionAdminDto?> EditAsync(QuestionAdminDto questionAdminDto)
    {
        if (string.IsNullOrWhiteSpace(questionAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => questionAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseQuestion = await _applicationDbContext.Questions.FindAsync(questionAdminDto.Id);

        if (databaseQuestion == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(questionAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseQuestion.ApplicationUserUpdatedBy = user;

        databaseQuestion.QuestionType = questionAdminDto.QuestionType;
        databaseQuestion.Text = questionAdminDto.Text;
        // EditDatabasePropertyCodePlaceholder
        // databaseQuestion.Title = questionAdminDto.Title;
        // databaseQuestion.NormalizedTitle = questionAdminDto.Title.ToUpperInvariant();
        // databaseQuestion.ToDoList = questionAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return questionAdminDto;
    }

    public async Task<List<Question>?> GetAllAsync(string userName)
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

        return await _applicationDbContext.Questions.ToListAsync();
    }

    public async Task<QuestionAdminDto?> GetByIdAsync(string userName, Guid id)
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

        var result = await _applicationDbContext.Questions.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return QuestionAdminDto.FromQuestion(result);
    }
}
