using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;
using Intrepion.QuizTickle.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intrepion.QuizTickle.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class QuestionTypeController(IQuestionTypeAdminService questionTypeAdminService) : ControllerBase
{
    private readonly IQuestionTypeAdminService _questionTypeAdminService = questionTypeAdminService;

    [HttpPost]
    public async Task<ActionResult<QuestionTypeAdminDto?>> Add(QuestionTypeAdminDto questionTypeAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(questionTypeAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseQuestionTypeAdminDto = await _questionTypeAdminService.AddAsync(questionTypeAdminDto);

        return Ok(databaseQuestionTypeAdminDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool?>> Delete(string userName, Guid id)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var result = await _questionTypeAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<QuestionTypeAdminDto?>> Edit(QuestionTypeAdminDto questionTypeAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(questionTypeAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseQuestionType = await _questionTypeAdminService.EditAsync(questionTypeAdminDto);

        return Ok(databaseQuestionType);
    }

    [HttpGet]
    public async Task<ActionResult<QuestionTypeAdminDto>?> GetAll(string userName)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var questionTypeAdminDtos = await _questionTypeAdminService.GetAllAsync(userIdentityName);

        return Ok(questionTypeAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionTypeAdminDto?>> GetById(string userName, Guid id)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var questionTypeAdminDto = await _questionTypeAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(questionTypeAdminDto);
    }
}
