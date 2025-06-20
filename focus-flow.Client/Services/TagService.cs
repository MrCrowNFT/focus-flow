using System.Net.Http.Json;
using focus_flow.Shared.models;

public class TagService
{
    private readonly HttpClient _http;

    public TagService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<tag>> GetTagsAsync()
    {
        var response = await _http.GetAsync("tag");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<tag>>() ?? new List<tag>();
    }
    public async Task<tag?> GetTagAsync(int id)
    {
        var response = await _http.GetAsync($"tag/{id}"); // was "task/{id}"
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<tag>();
    }

    public async Task<tag> CreateTagAsync(tag tag)
    {
        var response = await _http.PostAsJsonAsync("tag", tag);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<tag>()
               ?? throw new InvalidOperationException("Failed to deserialize created tag");
    }

    public async Task<bool> DeleteTagAsync(int id)
    {
        var response = await _http.DeleteAsync($"tag/{id}"); // was "task/{id}"
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return false;
        response.EnsureSuccessStatusCode();
        return true;
    }
}