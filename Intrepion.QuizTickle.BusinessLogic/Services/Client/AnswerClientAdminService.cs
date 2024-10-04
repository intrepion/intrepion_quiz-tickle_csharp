using System.Net.Http.Json;
using Intrepion.QuizTickle.BusinessLogic.Entities;
using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

namespace Intrepion.QuizTickle.BusinessLogic.Services.Client;

public class AnswerClientAdminService(HttpClient httpClient) : IAnswerAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<AnswerAdminDto?> AddAsync(AnswerAdminDto answerAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/answerAdmin", answerAdminDto);

        return await result.Content.ReadFromJsonAsync<AnswerAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/answerAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<AnswerAdminDto?> EditAsync(AnswerAdminDto answerAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/answerAdmin/{answerAdminDto.Id}", answerAdminDto);

        return await result.Content.ReadFromJsonAsync<AnswerAdminDto>();
    }

    public async Task<List<Answer>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Answer>>($"/api/admin/answerAdmin?userName={userName}");

        return result;
    }

    public async Task<AnswerAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<AnswerAdminDto>($"/api/admin/answerAdmin/{id}?userName={userName}");

        return result;
    }
}
