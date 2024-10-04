using System.Net.Http.Json;
using Intrepion.QuizTickle.BusinessLogic.Entities;
using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

namespace Intrepion.QuizTickle.BusinessLogic.Services.Client;

public class QuestionTypeClientAdminService(HttpClient httpClient) : IQuestionTypeAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<QuestionTypeAdminDto?> AddAsync(QuestionTypeAdminDto questionTypeAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/questionTypeAdmin", questionTypeAdminDto);

        return await result.Content.ReadFromJsonAsync<QuestionTypeAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/questionTypeAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<QuestionTypeAdminDto?> EditAsync(QuestionTypeAdminDto questionTypeAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/questionTypeAdmin/{questionTypeAdminDto.Id}", questionTypeAdminDto);

        return await result.Content.ReadFromJsonAsync<QuestionTypeAdminDto>();
    }

    public async Task<List<QuestionType>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<QuestionType>>($"/api/admin/questionTypeAdmin?userName={userName}");

        return result;
    }

    public async Task<QuestionTypeAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<QuestionTypeAdminDto>($"/api/admin/questionTypeAdmin/{id}?userName={userName}");

        return result;
    }
}
