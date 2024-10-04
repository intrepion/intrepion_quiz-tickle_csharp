using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;
using Intrepion.QuizTickle.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intrepion.QuizTickle.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class QuestionController(IQuestionAdminService questionAdminService) : ControllerBase
{
    private readonly IQuestionAdminService _questionAdminService = questionAdminService;

    [HttpPost]
    public async Task<ActionResult<QuestionAdminDto?>> Add(QuestionAdminDto questionAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(questionAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseQuestionAdminDto = await _questionAdminService.AddAsync(questionAdminDto);

        return Ok(databaseQuestionAdminDto);
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

        var result = await _questionAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<QuestionAdminDto?>> Edit(QuestionAdminDto questionAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(questionAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseQuestion = await _questionAdminService.EditAsync(questionAdminDto);

        return Ok(databaseQuestion);
    }

    [HttpGet]
    public async Task<ActionResult<QuestionAdminDto>?> GetAll(string userName)
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

        var questionAdminDtos = await _questionAdminService.GetAllAsync(userIdentityName);

        return Ok(questionAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionAdminDto?>> GetById(string userName, Guid id)
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

        var questionAdminDto = await _questionAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(questionAdminDto);
    }
}
