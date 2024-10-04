using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class QuizController(IQuizAdminService quizAdminService) : ControllerBase
{
    private readonly IQuizAdminService _quizAdminService = quizAdminService;

    [HttpPost]
    public async Task<ActionResult<QuizAdminDto?>> Add(QuizAdminDto quizAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(quizAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseQuizAdminDto = await _quizAdminService.AddAsync(quizAdminDto);

        return Ok(databaseQuizAdminDto);
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

        var result = await _quizAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<QuizAdminDto?>> Edit(QuizAdminDto quizAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(quizAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseQuiz = await _quizAdminService.EditAsync(quizAdminDto);

        return Ok(databaseQuiz);
    }

    [HttpGet]
    public async Task<ActionResult<QuizAdminDto>?> GetAll(string userName)
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

        var quizAdminDtos = await _quizAdminService.GetAllAsync(userIdentityName);

        return Ok(quizAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuizAdminDto?>> GetById(string userName, Guid id)
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

        var quizAdminDto = await _quizAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(quizAdminDto);
    }
}
