using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class QuestionClientAdminService(HttpClient httpClient) : IQuestionAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<QuestionAdminDto?> AddAsync(QuestionAdminDto questionAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/questionAdmin", questionAdminDto);

        return await result.Content.ReadFromJsonAsync<QuestionAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/questionAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<QuestionAdminDto?> EditAsync(QuestionAdminDto questionAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/questionAdmin/{questionAdminDto.Id}", questionAdminDto);

        return await result.Content.ReadFromJsonAsync<QuestionAdminDto>();
    }

    public async Task<List<Question>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Question>>($"/api/admin/questionAdmin?userName={userName}");

        return result;
    }

    public async Task<QuestionAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<QuestionAdminDto>($"/api/admin/questionAdmin/{id}?userName={userName}");

        return result;
    }
}
