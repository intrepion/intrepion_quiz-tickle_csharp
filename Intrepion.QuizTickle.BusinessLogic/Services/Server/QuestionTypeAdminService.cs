﻿using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class QuestionTypeAdminService(ApplicationDbContext applicationDbContext) : IQuestionTypeAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<QuestionTypeAdminDto?> AddAsync(QuestionTypeAdminDto questionTypeAdminDto)
    {
        if (string.IsNullOrWhiteSpace(questionTypeAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => questionTypeAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(questionTypeAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var questionType = QuestionTypeAdminDto.ToQuestionType(user, questionTypeAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.TableNamePlaceholder.AddAsync(questionType);
        var databaseQuestionTypeAdminDto = QuestionTypeAdminDto.FromQuestionType(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseQuestionTypeAdminDto;
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

        var databaseQuestionType = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (databaseQuestionType == null)
        {
            return false;
        }

        databaseQuestionType.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseQuestionType);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<QuestionTypeAdminDto?> EditAsync(QuestionTypeAdminDto questionTypeAdminDto)
    {
        if (string.IsNullOrWhiteSpace(questionTypeAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => questionTypeAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseQuestionType = await _applicationDbContext.TableNamePlaceholder.FindAsync(questionTypeAdminDto.Id);

        if (databaseQuestionType == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(questionTypeAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseQuestionType.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder
        // databaseQuestionType.Title = questionTypeAdminDto.Title;
        // databaseQuestionType.NormalizedTitle = questionTypeAdminDto.Title.ToUpperInvariant();
        // databaseQuestionType.ToDoList = questionTypeAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return questionTypeAdminDto;
    }

    public async Task<List<QuestionType>?> GetAllAsync(string userName)
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

    public async Task<QuestionTypeAdminDto?> GetByIdAsync(string userName, Guid id)
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

        return QuestionTypeAdminDto.FromQuestionType(result);
    }
}
