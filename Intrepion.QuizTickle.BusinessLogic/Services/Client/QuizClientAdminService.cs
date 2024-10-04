using System.Net.Http.Json;
using Intrepion.QuizTickle.BusinessLogic.Entities;
using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

namespace Intrepion.QuizTickle.BusinessLogic.Services.Client;

public class QuizClientAdminService(HttpClient httpClient) : IQuizAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<QuizAdminDto?> AddAsync(QuizAdminDto quizAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/quizAdmin", quizAdminDto);

        return await result.Content.ReadFromJsonAsync<QuizAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/quizAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<QuizAdminDto?> EditAsync(QuizAdminDto quizAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/quizAdmin/{quizAdminDto.Id}", quizAdminDto);

        return await result.Content.ReadFromJsonAsync<QuizAdminDto>();
    }

    public async Task<List<Quiz>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Quiz>>($"/api/admin/quizAdmin?userName={userName}");

        return result;
    }

    public async Task<QuizAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<QuizAdminDto>($"/api/admin/quizAdmin/{id}?userName={userName}");

        return result;
    }
}
